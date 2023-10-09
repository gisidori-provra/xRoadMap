using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraMap;
using NetTopologySuite.Geometries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.Win.Editors
{
    [ListEditor(typeof(IXPGeometry), false)]
    public class MapListEditor : ListEditor
    {
        private MapUserControl mapControl;

        public MapListEditor(IModelListView model):base(model)
        {

        }

        public override void Dispose()
        {
            UnsubscribeMapEvents();
            mapControl = null;
            base.Dispose();
        }

        public override void BreakLinksToControls()
        {
            base.BreakLinksToControls();
            UnsubscribeMapEvents();
        }
        public override SelectionType SelectionType => SelectionType.Full;


        public override IList GetSelectedObjects()
        {
            if (mapControl == null)
                return new List<object>();
            var list =  mapControl.GetSelectedItems();
            var items = new List<object>();
            foreach ( var item in list )
            {
                if (item != null)
                    if (item.GetType().IsAssignableFrom(this.Model.ModelClass.TypeInfo.Type))
                        items.Add(item);
            }
            return items;
        }

        public override void SaveModel()
        {
        }

        public override void Refresh()
        {
            mapControl.RefreshDataSource(controlDataSource);
        }


        public override object FocusedObject
        {
            get
            {
                var obj = mapControl?.FocusedObject;
                if (obj != null)
                    if (obj.GetType().IsAssignableFrom(Model.ModelClass.TypeInfo.Type))
                        return obj;
                return null;
            }
        }

        private object controlDataSource;

        protected override void AssignDataSourceToControl(object dataSource)
        {
            if (mapControl == null)
                return;

            if (controlDataSource != dataSource)
            {
                IBindingList oldBindable = controlDataSource as IBindingList;
                if (oldBindable != null)
                {
                    oldBindable.ListChanged -= new ListChangedEventHandler(dataSource_ListChanged);
                }
                controlDataSource = dataSource;
                IBindingList bindable = controlDataSource as IBindingList;
                if (bindable != null)
                {
                    bindable.ListChanged += dataSource_ListChanged;
                }
                Refresh();
            }


        }
        private void dataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            Refresh();
        }

        protected override object CreateControlsCore()
        {
            mapControl = new MapUserControl();

            mapControl.AddLayers(this.ObjectTypeInfo, this.Model);

            SubscribeMapEvents();

            return mapControl;
        }

        private void UnsubscribeMapEvents()
        {
            mapControl.Map.MapItemClick -= Map_MapItemClick;
            mapControl.Map.MapItemDoubleClick -= Map_MapItemDoubleClick;
            mapControl.Map.ObjectSelected -= Map_ObjectSelected;
        }

        private void SubscribeMapEvents()
        {
            mapControl.Map.MapItemClick += Map_MapItemClick;
            mapControl.Map.MapItemDoubleClick += Map_MapItemDoubleClick;
            mapControl.Map.ObjectSelected += Map_ObjectSelected;
        }

        private void Map_ObjectSelected(object sender, ObjectSelectedEventArgs e)
        {
            OnSelectionChanged();
            OnFocusedObjectChanged();
        }

        private void Map_MapItemClick(object sender, MapItemClickEventArgs e)
        {
            OnSelectionChanged();
        }

        private void Map_MapItemDoubleClick(object sender, MapItemClickEventArgs e)
        {
            //OnSelectionChanged();
            //this.OnProcessSelectedItem();
            //e.Handled = true;
        }

        protected override void OnSelectionChanged()
        {
            base.OnSelectionChanged();
        }

    }
}
