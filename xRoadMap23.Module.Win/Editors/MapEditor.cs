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
            if (mapControl != null)
                mapControl = null;
            base.Dispose(disposing);
        }
        protected override object CreateControlCore()
        {
            mapControl = new MapUserControl();
            mapControl.AddLayers(this.ObjectTypeInfo,this.Model);
            return mapControl;
        }

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
