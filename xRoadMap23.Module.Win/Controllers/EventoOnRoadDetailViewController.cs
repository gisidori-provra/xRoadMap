using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Utils.Text.Internal;
using DevExpress.XtraMap;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Geometries;
using NetTopologySuite.LinearReferencing;
using xRoadMap.Module.BusinessObjects;
using xRoadMap.Module.Win.Editors;

namespace xRoadMap.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class EventoOnRoadDetailViewController : ObjectViewController<ObjectView,IEventoOnRoad>
    {
        MapUserControl mapUserControl;

        public EventoOnRoadDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.

        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            if (View is DetailView dv)
                dv.CustomizeViewItemControl<Editors.MapEditor>(this, CustomizeViewItemControl, nameof(IEventoOnRoad.Shape));


        }

        private void CustomizeViewItemControl(Editors.MapEditor viewItem)
        {
            mapUserControl = viewItem.MapControl;
            viewItem.ProcessSelectedItem += viewItem_ProcessSelectedItem;
            //mapUserControl.Map.MouseClick += MapControl_MouseClick;
        }

        private void viewItem_ProcessSelectedItem(object sender, EventArgs e)
        {
            var selectedItems = mapUserControl.GetSelectedItems();
            if (selectedItems.Count == 1)
            {
                var os = Application.CreateObjectSpace();
                var item = selectedItems[0];
                var view = Application.CreateDetailView(os, item, true);
                Frame.SetView(view);
            }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        //private void MapControl_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    var map = sender as MapControl;
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        if (ViewCurrentObject.Strada != null)
        //        {
        //            var point = map.ScreenPointToCoordPoint(e.Location);
        //            var coord = new NetTopologySuite.Geometries.Coordinate(point.GetX(), point.GetY());
        //            var etrs89 = RoutingHelper.ToETRS89(coord);
        //            var km = RoutingHelper.LocalizzaPuntualeSuXY(ViewCurrentObject.Strada, etrs89, out double m);
        //            mapUserControl.ShowMessage($"Progressiva chilometrica: {km}");
        //        }
        //    }
        //}

        private void simpleActionUpdateEvent_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            if (typeof(EventoPuntuale).IsAssignableFrom(View.ObjectTypeInfo.Type))
            {
                RoutingHelper.LocalizzaPuntualeSuKilometrica(e.SelectedObjects.Cast<EventoPuntuale>());
            }
            if (typeof(EventoLineare).IsAssignableFrom(View.ObjectTypeInfo.Type))
            {
                RoutingHelper.LocalizzaLineareSuKilometrica(e.SelectedObjects.Cast<EventoLineare>());
            }
            
        }

        private void simpleActionLocateRoad_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            double maxDistance = 30;
            var strade = View.ObjectSpace.GetObjects<Strada>();
            foreach (var item in e.SelectedObjects)
            {
                IEventoOnRoad ev = View.ObjectSpace.GetObject(item) as IEventoOnRoad;
                ev.Strada = RoutingHelper.FindNearest(ev.Shape, strade,maxDistance);
                if (ev.Strada != null)
                {
                    if (ev is EventoPuntuale ep)
                        RoutingHelper.LocalizzaPuntualeSuXY(ep);
                    else if (ev is EventoLineare el)
                        RoutingHelper.LocalizzaLineareSuXY(el);
                }
            }
            if (View is DevExpress.ExpressApp.ListView lv)
            {
                View.ObjectSpace.CommitChanges();
                lv.CollectionSource.Reload();
            }
        }

        private void simpleActionLocate_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            if (typeof(EventoPuntuale).IsAssignableFrom(View.ObjectTypeInfo.Type))
            {
                RoutingHelper.LocalizzaPuntualeSuXY(e.SelectedObjects.Cast<EventoPuntuale>());
            }
            if (typeof(EventoLineare).IsAssignableFrom(View.ObjectTypeInfo.Type))
            {
                RoutingHelper.LocalizzaLineareSuXY(e.SelectedObjects.Cast<EventoLineare>());
            }
        }

        private void actionGetIFrame_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var os = Application.CreateObjectSpace(typeof(IFrameContent));
            var ev = View.CurrentObject as IEvento;
            var centroidClass = new Centroid(ev.Shape);
            var centroid = centroidClass.GetCentroid();
            var latlong = RoutingHelper.ToWGS84(centroid);
            var iFrame =  GetIFrameContent(latlong.X, latlong.Y, 14);
            IFrameContent frm = os.CreateObject<IFrameContent>();
            frm.IFrame = iFrame;
            e.View = Application.CreateDetailView(os, frm, true);
        }

        public static string GetIFrameContent(double lon, double lat, int zoom)
        {
            string mapId = "c4e54fe105a74778830746c247b305d4";
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            var sLong = lon.ToString("F6",nfi);
            var sLat = lat.ToString("F6", nfi);
            var content =
            $@"src=""https://sitportal.provincia.ra.it/arcgis/apps/Embed/index.html?webmap={mapId}&center={sLong},{sLat}&zoom=true&previewImage=false&scale=true&disable_scroll=true&theme=light&level={zoom}""";
            return content;
        }

        private void actionGetIFrame_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }
    }
}
