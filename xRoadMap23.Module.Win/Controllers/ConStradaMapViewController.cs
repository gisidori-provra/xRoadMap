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
using DevExpress.Utils.Gesture;
using DevExpress.XtraMap;
using DevExpress.XtraPrinting.Native;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xRoadMap.Module.BusinessObjects;
using xRoadMap.Module.Win.Editors;
using xRoadMap.Module.BusinessObjects.RoadDataModel;
using DevExpress.Xpo;

namespace xRoadMap.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ConStradaMapViewController : ObjectViewController<ObjectView,IConStrada>
    {

        MapUserControl mapUserControl;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ConStradaMapViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }


        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            //this.Active["MapEditor"] = this.View.GetItems<Editors.MapEditor>().Count>0;
            if (View is DetailView dv)
            {
                dv.CustomizeViewItemControl<Editors.MapEditor>(this, CustomizeViewItemControl);
            }
            if (View is DevExpress.ExpressApp.ListView lv)
            {
                lv.ControlsCreated += lv_ControlsCreated;
            }

            this.View.CurrentObjectChanged += view_CurrentObjectChanged;
        }

        private void lv_ControlsCreated(object sender, EventArgs e)
        {
            if (View is DevExpress.ExpressApp.ListView lv && lv.Editor is MapListEditor mapEditor)
            {
                mapUserControl = mapEditor.Control as MapUserControl;
                SubscribeMapControl(mapUserControl);
            }
        }

        private void view_CurrentObjectChanged(object sender, EventArgs e)
        {
            var line = ViewCurrentObject?.Strada?.Shape as NetTopologySuite.Geometries.LineString;
            if (line != null)
            {
                var point = new DevExpress.XtraMap.CartesianPoint(line.StartPoint.X, line.StartPoint.Y);
                Coordinate etrs89 = new Coordinate(point.X,point.Y);
                if (mapUserControl != null)
                    MapUpdateETRS89(ViewCurrentObject.Strada, etrs89);
            }
        }

        private void CustomizeViewItemControl(Editors.MapEditor viewItem)
        {
            mapUserControl = viewItem.MapControl;
            SubscribeMapControl(mapUserControl);
        }

        private void SubscribeMapControl(MapUserControl mapUserControl)
        {
            mapUserControl.Map.MouseMove += map_MouseMove;
            mapUserControl.Map.MouseDown += map_MouseDown;
            mapUserControl.Map.MouseUp += map_MouseUp;
            mapUserControl.HeadingTrackBarControl.ValueChanged += trackBarControl_ValueChanged;
            mapUserControl.PitchTrackBarControl.ValueChanged += trackBarControl_ValueChanged;
            mapUserControl.ZoomInButton.Click += zoomInButton_Click;
            mapUserControl.ZoomOutButton.Click += zoomOutButton_Click;
            mapUserControl.Map.KeyDown += mapUserControl_KeyDown;
            mapUserControl.Map.KeyUp += mapUserControl_KeyUp;
            mapUserControl.SearchProvider.SearchCompleted += searchProvider_SearchCompleted;
            mapUserControl.InformationLayer.ViewportChanged += viewportChanged;
        }

        GeoPoint topLeft;
        GeoPoint bottomRight;
        private void viewportChanged(object sender, ViewportChangedEventArgs e)
        {
            topLeft = e.TopLeft as GeoPoint;
            bottomRight = e.BottomRight as GeoPoint;    
        }

        private void searchProvider_SearchCompleted(object sender, BingSearchCompletedEventArgs e)
        {
            var results = e.RequestResult.SearchResults.Cast<BingLocationInformation>().OrderByDescending(r=>r.Confidence);
            if (results != null && results.Count() > 0)
            {
                var res = results.ElementAt(0);
                mapUserControl.Map.SetCenterPoint(res.Location, true);
                Strada st = RoutingHelper.FindNearest(res.Location,this.ObjectSpace);
                MapUpdate(st,res.Location,res.Address.FormattedAddress);
                //mapUserControl.Map.Zoom(17);
            }

        }

        private void mapUserControl_KeyUp(object sender, KeyEventArgs e)
        {
            controlPressed = altPressed = false;
        }

        bool controlPressed;
        bool altPressed;
        int keyValue;
        private void mapUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            controlPressed = e.Control;
            altPressed = e.Alt;
            keyValue = e.KeyValue;
        }


        private void UnsubscribeMapControl(MapUserControl mapUserControl)
        {
            mapUserControl.Map.MouseMove -= map_MouseMove;
            mapUserControl.Map.MouseDown -= map_MouseDown;
            mapUserControl.Map.MouseUp -= map_MouseUp;
            mapUserControl.HeadingTrackBarControl.ValueChanged -= trackBarControl_ValueChanged;
            mapUserControl.PitchTrackBarControl.ValueChanged -= trackBarControl_ValueChanged;
            mapUserControl.ZoomInButton.Click -= zoomInButton_Click;
            mapUserControl.ZoomOutButton.Click -= zoomOutButton_Click;
            mapUserControl.Map.KeyDown -= mapUserControl_KeyDown;
            mapUserControl.Map.KeyUp -= mapUserControl_KeyUp;
            mapUserControl.SearchProvider.SearchCompleted -= searchProvider_SearchCompleted;
            mapUserControl.InformationLayer.ViewportChanged += viewportChanged;
        }

        private void map_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoving = false;
        }

        bool mouseMoving = false;
        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            mouseMoving = true;
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            if (fov < 120)
            {
                fov += 10;
                controlPressed = true;
                MapUpdate(currentLocation);
                controlPressed = false;
            }
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            if (fov > 10)
            {
                fov -= 10;
                controlPressed = true;
                MapUpdate(currentLocation);
                controlPressed = false;
            }
        }

        private void trackBarControl_ValueChanged(object sender, EventArgs e)
        {
            controlPressed= true;
            MapUpdate(currentLocation);
            controlPressed = false;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }

        private void map_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !mouseMoving) 
            {
                //var line = ViewCurrentObject.Shape;
                //var dist = NetTopologySuite.Operation.Distance.DistanceOp.Distance(line, point);
                MapUpdate(e.Location);
            }
        }

        System.Drawing.Point currentLocation;

        private void MapUpdate(System.Drawing.Point location)
        {
            if (ViewCurrentObject == null)
                return;

            currentLocation = location;

            var st = ViewCurrentObject.Strada;
            MapUpdate(st, location);
        }

        private void MapUpdate(Strada st, System.Drawing.Point location)
        {
            
            if (st?.Shape != null)
            {
                var map = mapUserControl.Map;
                //var os = Application.CreateObjectSpace(typeof(EventoPuntuale));
                var point = map.ScreenPointToCoordPoint(location);
                MapUpdate(st, point);
            }
        }

        private void MapUpdate(Strada st, DevExpress.Map.CoordPoint point,string address = null)
        {
            var coord = new Coordinate(point.GetX(), point.GetY());
            MapUpdateWGS84(st,coord,address);
        }

        int fov = 90;

        private void MapUpdateWGS84(Strada st, Coordinate coord,string address = null)
        {
            var etrs89 = RoutingHelper.ToETRS89(coord);
            MapUpdate(st,coord,etrs89,address);
        }

        private void MapUpdateETRS89(Strada st,Coordinate etrs89)
        {
            var coord = RoutingHelper.ToWGS84(etrs89);
            MapUpdate(st, coord, etrs89);
        }

        private void MapUpdate(Coordinate coord, Coordinate etrs89)
        {
            MapUpdate(ViewCurrentObject.Strada,coord, etrs89);
        }

        private void MapUpdate(Strada st, Coordinate coord,Coordinate etrs89,string location = null)
        {
            if (mapUserControl == null)
                return;
            string apikey = "AIzaSyDTqlEhGm0HdYtQm7fdsqH8kXvLu_yG4C4";
            var km = RoutingHelper.LocalizzaPuntualeSuXY(st, etrs89, out double m);
            double bearing = 0;
            double? heading = null;
            var lng = RoutingHelper.ToSessagesimale(coord.X);
            var lat = RoutingHelper.ToSessagesimale(coord.Y);
            string message = null;
            var latlong = $"Lat: {lat} Long: {lng}";
            mapUserControl.ClearPushpin();
            if (km != null)
            {
                var angle = ((RoutingHelper.GetBearing(st, etrs89) / Math.PI * 180) + 360) % 360;
                bearing = (90 - angle + 360) % 360;
                heading = (bearing + mapUserControl.HeadingTrackBarControl.Value) % 360;
                message = $"{st.Sigla} {st.Denominazione} - PK: {km} - {latlong}";
            }
            else
            {
                message = latlong;
            }
            if (location != null)
                message = $"{location} {message}";

            mapUserControl.ShowPushpin(message, coord,controlPressed ? heading : null);

            var pitch = mapUserControl.PitchTrackBarControl.Value.ToString();
            var height = 640;
            var width = 640;
            if (controlPressed)
                mapUserControl.WebBrowser.Url = new Uri($"https://maps.googleapis.com/maps/api/streetview?size={width}x{height}&location={coord.Y},{coord.X}&fov={fov}&heading={heading:F0}&pitch={pitch}&key={apikey}");

        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            if (mapUserControl != null)
                UnsubscribeMapControl(mapUserControl);
            base.OnDeactivated();
        }
    }
}
