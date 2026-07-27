using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.Utils.About;
using DevExpress.XtraMap;
using DevExpress.XtraPrinting.Native;
using NetTopologySuite.Geometries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.Win.Editors
{
    [PropertyEditor(typeof(Geometry),true)]
    public class MapEditor:WinPropertyEditor
    {
        private MapUserControl mapControl;

        public MapEditor(Type objectType,IModelMemberViewItem info):base(objectType,info)
        {
        }

        public MapUserControl MapControl => mapControl;

        protected override void Dispose(bool disposing)
        {

            UnsubscribeMapEvents();
            if (mapControl != null)
                mapControl = null;
            base.Dispose(disposing);
        }
        protected override object CreateControlCore()
        {
            mapControl = new MapUserControl();
            mapControl.AddLayers(this.ObjectTypeInfo,this.Model);
            SubscribeMapEvents();
            return mapControl;
        }

        private void UnsubscribeMapEvents()
        {
            if (mapControl != null)
            {
                mapControl.Map.MapItemClick -= Map_MapItemClick;
                mapControl.Map.MapItemDoubleClick -= Map_MapItemDoubleClick;
                mapControl.Map.ObjectSelected -= Map_ObjectSelected;
            }
        }


        private void SubscribeMapEvents()
        {
            if (mapControl != null)
            {
                mapControl.Map.MapItemClick += Map_MapItemClick;
                mapControl.Map.MapItemDoubleClick += Map_MapItemDoubleClick;
                mapControl.Map.ObjectSelected += Map_ObjectSelected;
            }
        }

        private void Map_ObjectSelected(object sender, ObjectSelectedEventArgs e)
        {
        }

        private void Map_MapItemClick(object sender, MapItemClickEventArgs e)
        {
        }

        private void Map_MapItemDoubleClick(object sender, MapItemClickEventArgs e)
        {
            var row = mapControl.GetRow(e.Item);
            if (row != null)
            {
                OnProcessSelectedItem();                
                e.Handled = true;
            }
        }
        protected virtual void OnProcessSelectedItem()
        {
            if (this.ProcessSelectedItem != null)
            {
                this.ProcessSelectedItem(this, EventArgs.Empty);
            }
        }

        public event EventHandler ProcessSelectedItem;

        public IList GetSelectedItems()
        {
            return mapControl.GetSelectedItems();
        }

        protected override void OnControlCreated()
        {
            base.OnControlCreated();
            //var modelRoot = Model as IModelMapLayer;
            //switch (modelRoot.TOCVisibility)
            //{
            //    case BusinessObjects.VisibilityMode.Auto:
            //        mapControl.TOCVisibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            //        break;
            //    case BusinessObjects.VisibilityMode.Visible:
            //        mapControl.TOCVisibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            //        break;
            //    case BusinessObjects.VisibilityMode.Hidden:
            //        mapControl.TOCVisibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            //        break;
            //    default:
            //        break;
            //}
            ReadValue();
        }

        protected override void ReadValueCore()
        {
            if (mapControl != null)
            {
                BindingList<IXPGeometry> list = new BindingList<IXPGeometry>();
                if (CurrentObject is IXPGeometry geom)
                {
                    list.Add(geom);
                }
                mapControl.RefreshDataSource(list);
                
            }
        }

        protected override object GetControlValueCore()
        {
            return this.PropertyValue;
        }
    }
}
