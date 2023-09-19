using DevExpress.Data.TreeList;
using DevExpress.ExpressApp.Validation;
using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects.RoadDataModel;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class EventoLineareSuStrada : EventoLineare, IEventoLineareOnRoad
    {
        public EventoLineareSuStrada(Session session) : base(session)
        {

        }

        [Association]
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada), ref strada, value);
        }

        private TipoEvento tipoEvento;
        public TipoEvento TipoEvento
        {
            get { return tipoEvento; }
            set
            {
                SetPropertyValue(nameof(TipoEvento), ref tipoEvento, value);
            }

        }

        string descrizione;
        public string Descrizione
        {
            get => descrizione;
            set => SetPropertyValue(nameof(Descrizione), ref descrizione, value);
        }


    }
}
