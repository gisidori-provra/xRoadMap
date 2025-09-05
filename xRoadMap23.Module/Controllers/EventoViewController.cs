using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.Controllers
{
    public class EventoViewController : ObjectViewController<ObjectView,IEvento>
    {
        SingleChoiceAction actionConvertiCoordinate;
        public EventoViewController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
            actionConvertiCoordinate = new SingleChoiceAction(this, "ConvertiCoordinate", DevExpress.Persistent.Base.PredefinedCategory.RecordEdit);
            actionConvertiCoordinate.Execute += actionConvertiCoordinate_Execute;
            actionConvertiCoordinate.Items.Add(new ChoiceActionItem("Piane->Geografiche",0));
            actionConvertiCoordinate.Items.Add(new ChoiceActionItem("Geografiche->Piane", 1));

        }
        private void actionConvertiCoordinate_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            switch (e.SelectedChoiceActionItem.Data)
            {
                case 0:
                    foreach (IEvento ev in e.SelectedObjects)
                    {
                        var geom = new NetTopologySuite.Geometries.Coordinate(ev.X, ev.Y);
                        var geo = RoutingHelper.ToWGS84(geom);
                        ev.Latitudine = geo.Y;
                        ev.Longitudine = geo.X;
                        if (ev is IEventoLineare el)
                        {
                            geom = new NetTopologySuite.Geometries.Coordinate(el.XFine, el.YFine);
                            geo = RoutingHelper.ToWGS84(geom);
                            el.LatitudineFine = geo.Y;
                            el.LongitudineFine = geo.X;
                        }
                    }
                    break;
                case 1:
                    foreach (IEvento ev in e.SelectedObjects)
                    {
                        var geo = new NetTopologySuite.Geometries.Coordinate(ev.Longitudine,ev.Latitudine);
                        var geom = RoutingHelper.ToETRS89(geo);
                        ev.Y = geom.Y;
                        ev.X = geom.X;
                        if (ev is IEventoLineare el)
                        {
                            geo = new NetTopologySuite.Geometries.Coordinate(el.LongitudineFine, el.LatitudineFine);
                            geom = RoutingHelper.ToETRS89(geo);
                            el.XFine = geo.Y;
                            el.YFine= geo.X;
                        }
                    }
                    break;
            }
            ObjectSpace.CommitChanges();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }
}
