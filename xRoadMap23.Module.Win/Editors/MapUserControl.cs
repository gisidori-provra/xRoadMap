using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
using DevExpress.Map;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraMap;
using GeoAPI.CoordinateSystems.Transformations;
using NetTopologySuite.Geometries;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xRoadMap.Module.BusinessObjects;
using xRoadMap.Module.Xpo;

namespace xRoadMap.Module.Win.Editors
{
    public partial class MapUserControl : UserControl
    {

        private VectorItemsLayer layer;
        Dictionary<string, string> dataSourceProperties = new Dictionary<string, string>();
        private object DataSource;
        private ITypeInfo objectTypeInfo;
        CartesianSourceCoordinateSystem cartesianSourceCoordinateSystem1;
        UTMCartesianToGeoConverter utmCartesianToGeoConverter1;
        IXPGeometry focusedObject;

        public MapUserControl()
        {
            InitializeComponent();

            var checkContextButton = new CheckContextButton();
            checkContextButton.AlignmentOptions.Position = ContextItemPosition.Center;
            checkContextButton.Padding = new Padding(5);
            checkContextButton.AlignmentOptions.Panel = ContextItemPanel.Left;
            checkContextButton.Visibility = ContextItemVisibility.Visible;
            checkedListBoxControl1.ContextButtons.Add(checkContextButton);

            checkedListBoxControl1.ItemChecking += (s, e) => e.Cancel = true;


            //map.SearchPanelOptions.Visible = false;
            map.MapItemClick += map_MapItemClick;
            cartesianSourceCoordinateSystem1 = new CartesianSourceCoordinateSystem();
            utmCartesianToGeoConverter1 = new UTMCartesianToGeoConverter();
            utmCartesianToGeoConverter1.UtmZone = 32;
            cartesianSourceCoordinateSystem1.CoordinateConverter = utmCartesianToGeoConverter1;
            TOCVisibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            dockManager.ForceInitialize();
        }



        private void map_MapItemClick(object sender, MapItemClickEventArgs e)
        {
            focusedObject = GetRow(e.Item);
        }

        private void map_SelectionChanged(object sender, MapSelectionChangedEventArgs e)
        {
            
        }
        public BingSearchDataProvider SearchProvider => this.bingSearchDataProvider;

        public InformationLayer InformationLayer => this.informationLayer;
        
        public DevExpress.XtraMap.MapControl Map => map;

        public MapItemsLayerBase Layer => layer;

        public DevExpress.XtraBars.Docking.DockVisibility TOCVisibility
        {
            get => dockPanelTOC.Visibility;
            set => dockPanelTOC.Visibility = value;
        }

        public DevExpress.XtraBars.Docking.DockVisibility StreetViewVisibility
        {
            get => dockPanelStreetView.Visibility;
            set => dockPanelStreetView.Visibility = value;
        }

        public WebBrowser WebBrowser => webBrowser;

        public TrackBarControl HeadingTrackBarControl => headingTrackBarControl;

        public TrackBarControl PitchTrackBarControl => pitchTrackBarControl;

        public SimpleButton ZoomInButton => this.btnZoomIn;
        public SimpleButton ZoomOutButton => this.btnZoomOut;

        public void PanTo(IXPGeometry geometry)
        {
            if (geometry.Shape != null)
            {
                var env = geometry.Shape.EnvelopeInternal;
                if (geometry.Shape.Dimension == Dimension.Point)
                {
                    env.ExpandBy(100);
                }
                var topLeft = new CartesianPoint(env.MaxX, env.MinY);
                var bottomRight = new CartesianPoint(env.MinX, env.MaxY);
                var gtop = cartesianSourceCoordinateSystem1.CoordinateConverter.Convert(topLeft);
                var gbot = cartesianSourceCoordinateSystem1.CoordinateConverter.Convert(bottomRight);

                map.ZoomToRegion(gtop, gbot, 0.4);
            }
        }

        public void RefreshDataSource(object dataSource)
        {
            DataSource = dataSource;
            map.SuspendRender();
            SqlGeometryItemStorage storage = layer.Data as SqlGeometryItemStorage;
            storage.Items.Clear();
            objectRecords.Clear();

            if (dataSource is IBindingList bindingList)
            {
                foreach (IXPGeometry item in bindingList)
                {
                    if (item.Shape != null)
                    {
                        var p = AddItem(item, storage, layer.Name); // storage.Items.Add(new SqlGeometryItem(item.Shape.ToString(), (int)item.Shape.SRID));
                        RefreshColorizer(layer.Colorizer,bindingList);
                    }
                    foreach (var pair in dataSourceProperties)
                    {
                        IBindingList list = null;
                        var vl = map.Layers[pair.Key] as VectorItemsLayer;
                        var stor = vl.Data as SqlGeometryItemStorage;
                        //stor.Items.Clear();
                        var xpo = item as DevExpress.Xpo.XPBaseObject;
                        //var mInfo = xpo.ClassInfo.GetMember(pair.Value);
                        var dataMember = pair.Value;
                        if (dataMember.StartsWith("<"))
                        {
                            foreach (DevExpress.Xpo.Metadata.XPClassInfo ci in xpo.Session.Dictionary.Classes)
                            {
                                if ("<"+ci.FullName+">" == dataMember)
                                {
                                    var crit = CriteriaOperator.Parse("STContains(?,?)", viewport, item.Shape);
                                    list = new XPCollection(xpo.Session, ci,crit);
                                    break;
                                }
                            }
                            
                        }
                        else
                        {
                            var mInfo = xpo.GetNestedMemberInfo(dataMember);
                            if (mInfo != null)
                            {
                                if (typeof(IXPGeometry).IsAssignableFrom(mInfo.MemberType))
                                {
                                    list = new BindingList<IXPGeometry>();
                                    var i = xpo.GetNestedMemberValue(pair.Value);   // mInfo.GetValue(xpo);
                                    if (i != null)
                                        list.Add(i);
                                }
                                else
                                    list = xpo.GetNestedMemberValue(pair.Value) as IBindingList;
                            }
                        }
                        try
                        {
                            if (list != null)
                            {
                                //RefreshColorizer(vl.Colorizer, list);
                                foreach (IXPGeometry innerItem in list)
                                {
                                    AddItem(innerItem, stor, pair.Key);
                                }
                            }
                        }
                        catch (InvalidCastException ice)
                        {
                            throw new InvalidCastException("Invalid cast",ice);
                        }
                    }

                }
            }
            map.ResumeRender();
        }

        public IList GetSelectedItems()
        {
            ArrayList selectedObjects = new ArrayList();
            foreach (var layerBase in map.Layers)
            {
                if (layerBase is MapItemsLayerBase layer)
                    foreach (MapItem item in layer.SelectedItems)
                    {
                        if (item.Layer == null)
                            continue;
                        selectedObjects.Add(this.GetRow(item));
                    }
            }

            return selectedObjects.ToArray(typeof(object));

        }

        List<LegendItem> legend = new List<LegendItem>();

        public void AddLayers(ITypeInfo objectTypeInfo, IModelNode info)
        {

            this.objectTypeInfo = objectTypeInfo;
            //map.Layers.Clear();
            //map.Layers.Add(informationLayer);
            this.dataSourceProperties.Clear();
            legend.Clear();

            this.checkedListBoxControl1.Items.Clear();

            var modelRoot = info as IModelMapLayer;
            layer = AddVectorLayer(modelRoot);
            layer.Name = modelRoot.LayerName;
            layer.ViewportChanged += layer_ViewportChanged;

            legend.Add(new LegendItem(modelRoot));

            //var item = new CheckedListBoxItem(modelRoot, modelRoot.Titolo, CheckState.Checked, true);
            //this.checkedListBoxControl1.Items.Add(item);
            
            layer.DataLoaded += this.Layer_DataLoaded;
            layer.Error += Layer_Error;


            if (info is IModelMap mapInfo)
            {
                map.MapEditor.ShowEditorPanel = mapInfo.ShowToolbar;
                switch (mapInfo.TOCVisibility)
                {
                    case BusinessObjects.VisibilityMode.Auto:
                        TOCVisibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                        break;
                    case BusinessObjects.VisibilityMode.Visible:
                        TOCVisibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                        break;
                    case BusinessObjects.VisibilityMode.Hidden:
                        TOCVisibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                        break;
                    default:
                        break;
                }

                foreach (IModelMapLayer model in mapInfo.MapLayers.OrderBy(l => l.Index))
                {
                    LayerBase layer = null;
                    switch (model.LayerType)
                    {
                        case LayerType.WMSLayer:
                            layer = AddWMSLayer(model.Uri,model.LayerName,model.Transparency);
                            break;
                        case LayerType.BingMapLayer:
                            string bingKey = ((IModelMapOptions)((IModelApplication)info.Root).Options).BingKey;
                            layer = AddBingMap(model,bingKey);
                            break;
                        case LayerType.VectorLayer:
                            layer = AddVectorLayer(model);
                            break;
                    }
                    if (layer != null)
                    {
                        layer.Visible = model.Visible;
                        legend.Add(new LegendItem(model));
                        //this.checkedListBoxControl1.Items.Add(layer.Name, model.Titolo, model.Visible ? CheckState.Checked : CheckState.Unchecked, true);
                    }
                }
            }

            this.checkedListBoxControl1.DataSource = legend;
            this.checkedListBoxControl1.DisplayMember = nameof(LegendItem.Titolo);
            //this.checkedListBoxControl1.CheckMember = nameof(LegendItem.Visible);
            this.checkedListBoxControl1.ValueMember = nameof(LegendItem.LayerName);

            map.MapEditor.MapItemEdited += this.MapEditor_MapItemEdited;
        }

        Polygon viewport;
        private void layer_ViewportChanged(object sender, ViewportChangedEventArgs e)
        {
            
            var coordinates = new Coordinate[5];
            var topLeft =  e.TopLeft as GeoPoint;
            var bottomRight = e.BottomRight as GeoPoint;
            //var x = RoutingHelper.ToETRS89(new Coordinate(topLeft.Longitude,topLeft.Latitude));
            coordinates[0] = RoutingHelper.ToETRS89(new Coordinate(topLeft.Longitude, topLeft.Latitude));
            coordinates[1] = RoutingHelper.ToETRS89(new Coordinate(bottomRight.Longitude, topLeft.Latitude));
            coordinates[2] = RoutingHelper.ToETRS89(new Coordinate(bottomRight.Longitude, bottomRight.Latitude));
            coordinates[3] = RoutingHelper.ToETRS89(new Coordinate(topLeft.Longitude, bottomRight.Latitude));
            coordinates[4] = coordinates[0];
            try
            {
                var ring = new LinearRing(coordinates);
                if (ring.IsClosed)
                    viewport = new Polygon(new LinearRing(coordinates));
                //RefreshDataSource(this.DataSource);
            }
            catch { }
        }

        private void Layer_Error(object sender, MapErrorEventArgs e)
        {
            //this.barDockControlBottom.Text = e.Exception.Message;
        }


        public void AddVectorLayer(VectorItemsLayer layer)
        {
            
        }

        private VectorItemsLayer AddVectorLayer(IModelMapLayer model)
        {

            var layer = new DevExpress.XtraMap.VectorItemsLayer();
            var storage = new DevExpress.XtraMap.SqlGeometryItemStorage();
            layer.Name = model?.LayerName;
            layer.Data = storage;
            storage.SourceCoordinateSystem = cartesianSourceCoordinateSystem1;
            //string pattern = null;
            string dataSourceProperty = model?.DataSourceProperty;
            if (dataSourceProperty == null)
            {
                //pattern = objectTypeInfo.DefaultMember?.Name;
            }
            else
            {
                //var mInfo = objectTypeInfo.FindMember(dataSourceProperty);
                //if (mInfo == null)
                //{
                    
                //    return null;
                //}
                //if (mInfo.IsList)
                //    pattern = mInfo.ListElementTypeInfo.DefaultMember?.Name;
                //if (mInfo.IsAssociation)
                //    pattern = mInfo.AssociatedMemberInfo.MemberTypeInfo.DefaultMember?.Name;
                //if (pattern == null)
                //    pattern = mInfo.ListElementTypeInfo.KeyMember.Name;
                dataSourceProperties.Add(model.LayerName, dataSourceProperty);
            }

            //if (model.Pattern != null)
                layer.ShapeTitlesPattern = model.Pattern;
            //else if (pattern != null)
            //    layer.ShapeTitlesPattern = "{" + pattern + "}";

            if (model != null)
            {
                layer.ShapeTitlesVisibility = (DevExpress.XtraMap.VisibilityMode) model.TitleVisible;
                layer.ItemStyle.Font = new Font(layer.ItemStyle.Font, model.FontStyle.GetValueOrDefault());
                if (model.FillColor.HasValue)
                    layer.ItemStyle.Fill = model.FillColor.Value;
                if (model.StrokeColor.HasValue)
                    layer.ItemStyle.Stroke = model.StrokeColor.Value;
                if (model.StrokeWidth.HasValue)
                    layer.ItemStyle.StrokeWidth = model.StrokeWidth.Value;
                if (model.TextColor.HasValue)
                    layer.ItemStyle.TextColor = model.TextColor.Value;
                if (model.TextGlowColor.HasValue)
                    layer.ItemStyle.TextGlowColor = model.TextGlowColor.Value;
                switch (model.ColorizerType)
                {
                    case ColorizerType.None:
                        break;
                    case ColorizerType.Cloropleth:
                        break;
                    case ColorizerType.Graph:
                        break;
                    case ColorizerType.KeyColor:
                        layer.Colorizer = CreateKeyColorColorizer(model);
                        break;
                    default:
                        break;
                }
            }
            map.Layers.Add(layer);
            return layer;

        }
        private void RefreshColorizer(MapColorizer colorizer,IBindingList list)
        {
            if (colorizer is KeyColorColorizer kc)
                RefreshKeyColorColorizer(kc,list);
        }

        private void RefreshKeyColorColorizer(KeyColorColorizer colorizer,IBindingList list)
        {
            if (colorizer.Colors.Count > 0) return;

            colorizer.Colors.Clear();

            if (DataSource is IBindingList bindingList)
            {
                foreach (IXPGeometry item in list)
                {
                    var attribute = colorizer.ItemKeyProvider as AttributeItemKeyProvider;
                    var member = item.ClassInfo.GetPersistentMember(attribute.AttributeName);
                    object key = member.GetValue(item);
                    if (key != null)
                    {
                        ColorizerKeyItem keyItem = null;
                        foreach (var k in colorizer.Keys)
                        {
                            if (k.Key == key)
                            {
                                keyItem = k;
                                break;
                            }
                               
                        }
                        if (keyItem == null)
                        {
                            keyItem = new ColorizerKeyItem() { Key = key, Name = key.ToString() };
                            if (colorizer.Keys.Contains(keyItem) == false)
                                colorizer.Keys.Add(keyItem);
                        }
                    }
                }
            }
        }

        private KeyColorColorizer CreateKeyColorColorizer(IModelMapLayer model)
        {
            
            KeyColorColorizer colorizer = new KeyColorColorizer()
            {
                ItemKeyProvider = new AttributeItemKeyProvider() { AttributeName = model.AttributeName },
                PredefinedColorSchema = PredefinedColorSchema.Palette
            };
            return colorizer;
        }

        //private Dictionary<string,List<string>> wmsLayers= new Dictionary<string,List<string>>();

        private LayerBase AddWMSLayer(string uri,string activeLayerName,int? transparency=null, bool recurse = true)
        {
            ImageLayer imageLayer = new ImageLayer();
            imageLayer.Name = (recurse ? string.Empty : uri+"//") + activeLayerName;
            WmsDataProvider dataProvider = new WmsDataProvider();
            dataProvider.ServerUri = uri;
            dataProvider.ActiveLayerName = activeLayerName;
            if (uri.Contains("wms.cartografia.agenziaentrate.gov.it"))
                ;   // dataProvider.SetCoordinateConverter(new WMSPointConverter("25832"));

            //dataProvider.CustomParameters.Add("SR", "EPSG:25832");

            //if (activeLayerName == "Catasto")
            //    dataProvider.SetCoordinateConverter(new WMSPointConverter("EPSG:6706"));

            //wmsLayers[uri] = new List<string>();
            dataProvider.WebRequest += DataProvider_WebRequest;
            dataProvider.ResponseCapabilities += DataProvider_ResponseCapabilities;
            dataProvider.ActiveLayerName = activeLayerName;
            imageLayer.DataProvider = dataProvider;
            if (transparency != null && transparency.Value<=100 && transparency.Value>=0)
                imageLayer.Transparency = (byte) (transparency * 255 / 100);
            map.Layers.Add(imageLayer);
            //wmsLayers[uri].Add(imageLayer.Name);
            return imageLayer;

            void DataProvider_ResponseCapabilities(object sender, CapabilitiesRespondedEventArgs e)
            {
                if (recurse)
                {
                    foreach (var layer in e.Layers)
                    {
                        AddWMSLayer(uri, layer.Name,transparency, false);
                        //var ndx = this.checkedListBoxControl1.Items.Add(layer.Name, layer.Title, CheckState.Checked, true);
                    }
                }
            }


        }


        private delegate void LogMessageDelegate(string text    );

        private void DataProvider_WebRequest(object sender, MapWebRequestEventArgs e)
        {
            //this.BeginInvoke(new LogMessageDelegate(LogMessage), $"WebRequest: {e.Uri.Host}");
            System.Console.WriteLine(e.Uri.ToString());
        }

        private void LogMessage(string text)
        {
            //this.barDockControlBottom.Text = text;
            System.Console.WriteLine(text);
        }

        //private BingGeocodeDataProvider BingGeocodeDataProvider;

        private LayerBase AddBingMap(IModelMapLayer model,string bingKey)
        {
            var layer = map.Layers[model.LayerName];
            if (layer == null)
            {
                layer = new ImageLayer()
                {
                    DataProvider = new BingMapDataProvider()
                    {
                        BingKey = bingKey,
                        Kind = model.BingMapKind
                    }
                };
            }
            this.bingSearchDataProvider.BingKey = bingKey;
            //if (BingGeocodeDataProvider == null)
            //{
            //    BingGeocodeDataProvider = new BingGeocodeDataProvider() { BingKey = bingKey };
            //    BingGeocodeDataProvider.LocationInformationReceived += BingGeocodeDataProvider_LocationInformationReceived;
            //    BingGeocodeDataProvider.LayerItemsGenerating += BingGeocodeDataProvider_LayerItemsGenerating;
            //    //informationLayer.DataProvider = BingGeocodeDataProvider;
            //}

            
            map.Layers.Add(layer);
            layer.Name = model.LayerName;
            return layer;
        }

        //private void BingGeocodeDataProvider_LayerItemsGenerating(object sender, LayerItemsGeneratingEventArgs e)
        //{
        //    //map.ZoomToFit(e.Items, 0.4);
        //}

        //private void BingGeocodeDataProvider_LocationInformationReceived(object sender, LocationInformationReceivedEventArgs e)
        //{
        //    lboxResults.Items.Clear();
        //    informationLayer.ClearResults();
        //    if (e.Cancelled)
        //        return;
        //    if (e.Result.ResultCode != RequestResultCode.Success)
        //    {
        //        lboxResults.Items.Add($"Nessun risultato. ({e.Result.FaultReason})");
        //        return;
        //    }
        //    foreach (var item in e.Result.Locations)
        //    {
        //        var txt = $"{item.EntityType}: {item.DisplayName} - {item.Address.FormattedAddress} ({item.Location.Latitude} {item.Location.Longitude})";
        //        lboxResults.Items.Add(txt);
        //    }
        //}

        public void ShowMessage(string message)
        {
            lblStatus.Text = message;
        }

        public void ClearPushpin()
        {
            pushPinItemStorage.Items.Clear();
        }

        public void ShowPushpin(string message,Coordinate location,double? angle=null,string imageName = null)
        {
            MapPushpin mapPushpin = new MapPushpin();
            mapPushpin.Location = new DevExpress.XtraMap.CartesianPoint(location.X,location.Y);
            mapPushpin.ToolTipPattern = message;
            if (angle.HasValue)
            {
                mapPushpin.Angle = (Math.PI * (angle.Value) / 180);
            }
            mapPushpin.SvgImage = ImageLoader.Instance.GetImageInfo(imageName).CreateSvgImage();
            pushPinItemStorage.Items.Clear();
            pushPinItemStorage.Items.Add(mapPushpin);
            ShowMessage(message);
            //map.Layers.Add(vectorItemsLayer1);
        }

        //struct ObjectHandle
        //{
        //    public int oid;
        //    public string layerName;
        //    public ObjectHandle(int oid, string layerName)
        //    {
        //        this.oid = oid;
        //        this.layerName = layerName;
        //    }
        //}

        private string GetObjectHandle(int oid,string layerName)
        {
            return $"{oid}_{layerName}";
        }
        Dictionary<string, IXPGeometry> objectRecords = new Dictionary<string, IXPGeometry>();

        public IXPGeometry GetXPGeometry(int oid, string layerName)
        {
            IXPGeometry result = null;
            var handle = GetObjectHandle(oid, layerName);
            objectRecords.TryGetValue(handle, out result);
            return result;
        }

        public IXPGeometry GetRow(MapItem item)
        {
            var attr = item.Attributes[nameof(XPSTGeometry.Oid)];
            if (attr == null)
                return null;
            int oid = (int)attr.Value;
            return GetXPGeometry(oid, item.Layer.Name);
        }

        public IXPGeometry FocusedObject => focusedObject;

        private SqlGeometryItem AddItem(IXPGeometry item, SqlGeometryItemStorage storage, string layerName)
        {
            SqlGeometryItem sqlStorageItem = null;
            if (item.Shape != null)
            {
                //if (viewport != null && item.Shape.Intersects(viewport))
                {
                    sqlStorageItem = new SqlGeometryItem(item.Shape.ToString(), (int)item.Shape.SRID);
                    foreach (DevExpress.Xpo.Metadata.XPMemberInfo info in item.ClassInfo.Members)
                    {
                        if (info.IsPublic)
                            sqlStorageItem.Attributes.Add(new MapItemAttribute() { Name = info.Name, Value = info.GetValue(item) });
                    }
                    storage.Items.Add(sqlStorageItem);
                }
            }
            objectRecords[GetObjectHandle(item.Oid, layerName)] = item;
            return sqlStorageItem;

        }



        private void MapEditor_MapItemEdited(object sender, MapItemEditedEventArgs e)
        {
            foreach (var item in e.Items)
            {

                switch (e.Action)
                {
                    case MapEditorAction.None:
                        break;
                    case MapEditorAction.Move:
                        break;
                    case MapEditorAction.Rotate:
                        break;
                    case MapEditorAction.Resize:
                        break;
                    case MapEditorAction.PointUpdate:
                        break;
                    case MapEditorAction.PointAdd:
                        break;
                    case MapEditorAction.PointRemove:
                        break;
                    case MapEditorAction.Create:
                        IXPGeometry geom = (IXPGeometry)((IBindingList)DataSource).AddNew();
                        if (item is MapShape shp)
                        {
                            //SqlChars str = new SqlChars(new SqlString(shp.ExportToWkt()));
                            geom.Shape = GeometryConverter.FromWKT(shp.ExportToWkt(), 25832);
                        }
                        break;
                    case MapEditorAction.Remove:
                        break;
                    case MapEditorAction.Copy:
                        break;
                    default:
                        break;
                }
            }
        }

        public void PanTo(Coordinate point)
        {
            var cPoint = new GeoPoint(point.Y,point.X);
            //var anchorPoint = map.CoordPointToScreenPoint(cPoint);
            map.CenterPoint = cPoint;
            //map.Zoom(map.ZoomLevel, anchorPoint, true);
        }

        private void Layer_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            map.ZoomToFitLayerItems(new LayerBase[] { this.Layer });
            if (map.ZoomLevel == 1 || map.ZoomLevel>15)
                map.ZoomLevel = 15;
        }

        private void checkedListBoxControl1_SelectedValueChanged(object sender, System.EventArgs e)
        {
            ;
        }


        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            var m = legend[e.Index];
            LayerChecked(m.LayerName, e.State == CheckState.Checked);
        }

        private void LayerChecked(string layerName,bool check)
        {
            var layer = map.Layers[layerName];
            if (layer is ImageLayer img)
            {
                if (img.DataProvider is WmsDataProvider wms)
                {
                    foreach (var item in map.Layers)
                    {
                        if (item is ImageLayer iml2)
                            if (iml2.DataProvider is WmsDataProvider wms2)
                                if (wms2.ServerUri == wms.ServerUri)
                                    item.Visible = check;
                    }
                    return;
                }
            }
            layer.Visible = check;
        }

        private void map_Click(object sender, EventArgs e)
        {

        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void trackBarControl_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void dockPanelStreetView_MouseMove(object sender, MouseEventArgs e)
        {
            ;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser.Document.Body.MouseMove += Body_MouseMove;
            //webBrowser.Size = webBrowser.Document.Body.ScrollRectangle.Size;
        }

        private void Body_MouseMove(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Left)
            {
                ;//TODO
            }
        }

        private void CheckedListBoxControl1_ContextButtonClick(object sender, ContextItemClickEventArgs e)
        {
            var dataItem = legend.Where(i => Equals(i.LayerName, e.DataItem)).FirstOrDefault();
            if (dataItem == null)
                return;
            dataItem.Visible= !dataItem.Visible;
            LayerChecked(dataItem.LayerName,dataItem.Visible);
            (sender as Control).Refresh();
        }

        private void checkedListBoxControl1_CustomizeContextItem(object sender, DevExpress.XtraEditors.ViewInfo.ListBoxControlContextButtonCustomizeEventArgs e)
        {
            var checkContextButton = e.ContextItem as CheckContextButton;
            var dataItem = legend.Where(i => Equals(i.LayerName, e.Item)).FirstOrDefault();
            if (checkContextButton == null || dataItem == null)
                return;

            checkContextButton.Checked = dataItem.Visible;
        }

        //private void dockPanelBottom_Expanded(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        //{
        //    informationLayer.Visible = true;
        //}

        //private void dockPanelBottom_Collapsed(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
        //{
        //    informationLayer.Visible = false;
        //}

    }

    class WMSPointConverter : IWmsPointConverter
    {

        ICoordinateTransformation trans;
        string crsCode;
        public WMSPointConverter(string CRSCode)
        {
            crsCode = CRSCode;
            
            //EPSG=25832
            var fromWKT = "PROJCS[\"ETRS89 / UTM zone 32N\",GEOGCS[\"ETRS89\",DATUM[\"European_Terrestrial_Reference_System_1989\",SPHEROID[\"GRS 1980\",6378137,298.257222101,AUTHORITY[\"EPSG\",\"7019\"]],TOWGS84[0,0,0,0,0,0,0],AUTHORITY[\"EPSG\",\"6258\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.0174532925199433,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4258\"]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"latitude_of_origin\",0],PARAMETER[\"central_meridian\",9],PARAMETER[\"scale_factor\",0.9996],PARAMETER[\"false_easting\",500000],PARAMETER[\"false_northing\",0],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],AXIS[\"Easting\",EAST],AXIS[\"Northing\",NORTH],AUTHORITY[\"EPSG\",\"25832\"]]";
            
            //var fromWKT = "GEOGCS[\"GCS_ETRS_1989\",DATUM[\"D_ETRS_1989\",SPHEROID[\"GRS_1980\",6378137.0,298.257222101]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]]";

            CoordinateSystemFactory csFact = new CoordinateSystemFactory();
            CoordinateTransformationFactory ctFact = new CoordinateTransformationFactory();

            var from = csFact.CreateFromWkt(fromWKT);

            var to = GeographicCoordinateSystem.WGS84;  //csFact.CreateFromWkt(toWKT);

            trans = ctFact.CreateFromCoordinateSystems(from, to);

        }
        public string CRSCode => crsCode;

        public CoordPoint Convert(CoordPoint point)
        {

            if (point is DevExpress.XtraMap.GeoPoint gp)
            {
                if (gp.Latitude.CompareTo(double.NaN) != 0 && gp.Longitude.CompareTo(double.NaN) != 0)
                {
                    try
                    {
                        var p = trans.MathTransform.Transform(new double[] { gp.Longitude, gp.Latitude });
                        var c = new GeoPoint(p[1], p[0]);
                        return c;
                    }
                    catch { }
                }
            }
            return point;
        }
    }
}
