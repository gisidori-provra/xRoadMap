using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraMap;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.Win.Editors
{
    public partial class MapControl : DevExpress.XtraMap.MapControl
    {

        private VectorItemsLayer layer;
        Dictionary<string, string> dataSourceProperties = new Dictionary<string, string>();
        private object DataSource;
        private ITypeInfo objectTypeInfo;
        CartesianSourceCoordinateSystem cartesianSourceCoordinateSystem1;
        private VectorItemsLayer vectorItemsLayer1;
        UTMCartesianToGeoConverter utmCartesianToGeoConverter1;

        public MapControl():base()
        {
            cartesianSourceCoordinateSystem1 = new CartesianSourceCoordinateSystem();
            utmCartesianToGeoConverter1 = new UTMCartesianToGeoConverter();
            utmCartesianToGeoConverter1.UtmZone = 32;
            cartesianSourceCoordinateSystem1.CoordinateConverter = utmCartesianToGeoConverter1;
        }

        public MapItemsLayerBase Layer => layer;
        
        public void RefreshDataSource(object dataSource)
        {
            DataSource = dataSource;
            SuspendRender();

            SqlGeometryItemStorage storage = layer.Data as SqlGeometryItemStorage;
            storage.Items.Clear();
            if (dataSource is IBindingList bindingList)
            {
                foreach (IXPGeometry item in bindingList)
                {
                    if (item.Shape != null)
                    {
                        AddItem(item, storage,null); // storage.Items.Add(new SqlGeometryItem(item.Shape.ToString(), (int)item.Shape.SRID));
                    }
                    foreach (var pair in dataSourceProperties)
                    {
                        IBindingList list;
                        var vl = Layers[pair.Key] as VectorItemsLayer;
                        var stor = vl.Data as SqlGeometryItemStorage;
                        stor.Items.Clear();
                        var xpo = item as DevExpress.Xpo.XPBaseObject;
                        var mInfo = xpo.ClassInfo.GetMember(pair.Value);
                        if (typeof(IXPGeometry).IsAssignableFrom(mInfo.MemberType))
                        {
                            list = new BindingList<IXPGeometry>();
                            list.Add(mInfo.GetValue(xpo));
                        }
                        else
                            list = xpo.GetMemberValue(pair.Value) as IBindingList;
                       
                        foreach (IXPGeometry innerItem in list)
                        {
                            AddItem(innerItem, stor,pair.Key);
                        }
                    }

                }
            }

            ResumeRender();

        }

        public IList GetSelectedItems()
        {
            ArrayList selectedObjects = new ArrayList();
            foreach (var layerBase in Layers)
            {
                if (layerBase is MapItemsLayerBase layer)
                    foreach (MapItem item in layer.SelectedItems)
                    {
                        selectedObjects.Add(this.GetRow(item));
                    }
            }

            return selectedObjects.ToArray(typeof(object));

        }

        public void AddLayers(ITypeInfo objectTypeInfo, IModelNode info)
        {

            this.objectTypeInfo = objectTypeInfo;
            this.Layers.Clear();
            this.dataSourceProperties.Clear();

            layer = AddVectorLayer(info as IModelMapLayer);

            if (info is IModelMap mapInfo)
            {
                MapEditor.ShowEditorPanel = mapInfo.ShowToolbar;
                foreach (IModelMapLayer model in mapInfo.MapLayers.OrderBy(l => ((IModelNode)l).Index))
                {
                    LayerBase layer = null;
                    switch (model.LayerType)
                    {
                        case LayerType.WMSLayer:
                            layer = AddWMSLayer(model);
                            break;
                        case LayerType.BingMapLayer:
                            layer = AddBingMap(model);
                            break;
                        case LayerType.VectorLayer:
                            layer = AddVectorLayer(model);
                            break;
                    }
                    if (layer != null)
                        layer.Visible = model.Visible;
                }
            }
            layer.DataLoaded += this.Layer_DataLoaded;
            MapEditor.MapItemEdited += this.MapEditor_MapItemEdited;
            layer.Error += Layer_Error;

        }

        private void Layer_Error(object sender, MapErrorEventArgs e)
        {
            ;
        }

        private VectorItemsLayer AddVectorLayer(IModelMapLayer model)
        {
            var layer = new DevExpress.XtraMap.VectorItemsLayer();
            var storage = new DevExpress.XtraMap.SqlGeometryItemStorage();
            layer.Name = model?.LayerName;
            layer.Data = storage;
            storage.SourceCoordinateSystem = cartesianSourceCoordinateSystem1;
            string pattern = null;
            string dataSourceProperty = model?.DataSourceProperty;
            if (dataSourceProperty == null)
            {
                 pattern = objectTypeInfo.DefaultMember?.Name;
            }
            else
            {
                var mInfo = objectTypeInfo.FindMember(dataSourceProperty);

                if (mInfo.IsList)
                    pattern = mInfo.ListElementTypeInfo.DefaultMember?.Name;
                if (mInfo.IsAssociation)
                    pattern = mInfo.AssociatedMemberInfo.MemberTypeInfo.DefaultMember?.Name;
                if (pattern == null)
                    pattern = mInfo.ListElementTypeInfo.KeyMember.Name;
                dataSourceProperties.Add(model.LayerName, dataSourceProperty);
            }

            if (model.Pattern != null)
                layer.ShapeTitlesPattern = model.Pattern;
            else if (pattern != null)
                layer.ShapeTitlesPattern = "{"+pattern+"}";

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
            }
            Layers.Add(layer);
            return layer;

        }

        private LayerBase AddWMSLayer(IModelMapLayer model)
        {
            ImageLayer imageLayer = new ImageLayer();
            WmsDataProvider dataProvider = new WmsDataProvider();
            dataProvider.ServerUri = model.Uri;
            dataProvider.ActiveLayerName = model.LayerName;
            dataProvider.WebRequest += DataProvider_WebRequest;
            dataProvider.ResponseCapabilities += DataProvider_ResponseCapabilities;
            imageLayer.DataProvider = dataProvider;
            Layers.Add(imageLayer);
            return imageLayer;
        }

        private void DataProvider_ResponseCapabilities(object sender, CapabilitiesRespondedEventArgs e)
        {
            ;
        }

        private void DataProvider_WebRequest(object sender, MapWebRequestEventArgs e)
        {
            System.Console.WriteLine($"WebRequest:{e.Uri.ToString()}")
            ;
        }

        private LayerBase AddBingMap(IModelMapLayer model)
        {
            string bingKey = ((IModelMapOptions)((IModelApplication)((IModelNode)model).Root).Options).BingKey;
            var layer = new ImageLayer()
            {
                DataProvider = new BingMapDataProvider()
                {
                    BingKey = bingKey
                }
            };
            Layers.Add(layer);
            return layer;
        }

  
        struct ObjectHandle
        {
            public int oid;
            public string layerName;
            public ObjectHandle(int oid,string layerName)
            {
                this.oid = oid;
                this.layerName = layerName;
            }
        }

        Dictionary<ObjectHandle,IXPGeometry> objectRecords = new Dictionary<ObjectHandle,IXPGeometry>();

        private object GetXPGeometry(int oid,string layerName)
        {
            IXPGeometry result = null;
            var handle = new ObjectHandle(oid, layerName);
            objectRecords.TryGetValue(handle, out result);
            return result;
        }

        private object GetRow(MapItem item)
        {
            int oid = (int) item.Attributes[nameof(XPSTGeometry.Oid)].Value;
            return GetXPGeometry(oid,item.Layer.Name);
        }


        private SqlGeometryItem AddItem(IXPGeometry item, SqlGeometryItemStorage storage,string layerName)
        {
            SqlGeometryItem sqlStorageItem = null;
            if (item.Shape != null)
            {
                sqlStorageItem = new SqlGeometryItem(item.Shape.ToString(), (int)item.Shape.SRID);
                foreach (DevExpress.Xpo.Metadata.XPMemberInfo info in item.ClassInfo.PersistentProperties)
                {
                    sqlStorageItem.Attributes.Add(new MapItemAttribute() { Name = info.Name, Value = info.GetValue(item) });
                }
                storage.Items.Add(sqlStorageItem);
            }

            objectRecords[new ObjectHandle(item.Oid,layerName)] = item;

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

        private void Layer_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            ZoomToFitLayerItems();
        }


        private void InitializeComponent()
        {
            this.vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.Layers.Add(this.vectorItemsLayer1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
