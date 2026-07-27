using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.BusinessObjects.RoadDataModel
{
    [Persistent("EventTable")]
    [DeferredDeletion(false)]
    [OptimisticLocking(false)]
    public class EventTable:XPCustomObject
    {
        public EventTable(Session session):base(session)
        {

        }

        private int evento;
        public int Evento
        {
            get => evento;
            set => SetPropertyValue(nameof(Evento),ref evento,value);
        }

        private int oid;
        [Key(AutoGenerate = true), Browsable(false), DbType("int"), Persistent("OBJECTID")]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue<int>(nameof(Oid), ref oid, value);
        }

        private Strada strada;
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada),ref strada,value);
        }

        double m;
        [DevExpress.Xpo.DisplayName(@"Coord. M")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        public double M
        {
            get => m;
            set => SetPropertyValue(nameof(M), ref m, value);
        }

        double mFine;
        [DevExpress.Xpo.DisplayName(@"Coord. M Finale")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        public double MFine
        {
            get => mFine;
            set => SetPropertyValue(nameof(MFine), ref mFine, value);
        }

    }

    [Persistent("EventoLineare")]
    public class LayerEventoLineare:XPSTGeometry
    {
        public LayerEventoLineare(Session session):base(session)
        {

        }
        private int evento;
        public int Evento
        {
            get => evento;
            set => SetPropertyValue(nameof(Evento), ref evento, value);
        }
        private Strada strada;
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada), ref strada, value);
        }

    }

    [Persistent("EventoPuntuale")]
    public class LayerEventoPuntuale:XPSTGeometry
    {
        public LayerEventoPuntuale(Session session):base(session)
        {

        }
        private int evento;
        public int Evento
        {
            get => evento;
            set => SetPropertyValue(nameof(Evento), ref evento, value);
        }
        private Strada strada;
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada), ref strada, value);
        }
    }

}
