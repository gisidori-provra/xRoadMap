using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xRoadMap.Module.BusinessObjects;
using DevExpress.Persistent.Base;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]
    [NavigationItem("Catasto Strade")]
    public class OperaSostegno:EventoLineare,IEventoOnRoad
    {
        public OperaSostegno(Session session):base(session)
        {

        }

        [Association]
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada),ref strada,value);
        }

        public override void SetStrada(Strada value)
        {
            Strada = value;
        }


        private TipoOperaSostegno tipoOpera;
        public TipoOperaSostegno TipoOpera
        {
            get => tipoOpera;
            set => SetPropertyValue(nameof(TipoOpera), ref tipoOpera, value);
        }

        private TipologiaCostruttivaOperaSostegno tipoCostruzione;
        public TipologiaCostruttivaOperaSostegno TipoCostruzione
        {
            get => tipoCostruzione;
            set => SetPropertyValue(nameof(TipoCostruzione),ref tipoCostruzione, value);
        }

        TipoStatoConservazione stato;
        public TipoStatoConservazione Stato
        {
            get => stato;
            set => SetPropertyValue(nameof(Stato),ref stato,value);
        }


    }
}
