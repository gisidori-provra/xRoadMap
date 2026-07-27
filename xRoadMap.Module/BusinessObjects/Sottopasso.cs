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

    public class Sottopasso:EventoLineare,IEventoOnRoad
    {
        public Sottopasso(Session session):base(session)
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

        private TipoSottopasso tipoSottopasso;
        public TipoSottopasso TipoSottopasso
        {
            get => tipoSottopasso;
            set => SetPropertyValue(nameof(TipoSottopasso),ref tipoSottopasso,value);
        }

        private TipoIlluminazione illuminazione;
        public TipoIlluminazione Illuminazione
        {
            get => illuminazione;
            set => SetPropertyValue(nameof(Illuminazione), ref illuminazione, value);
        }

        TipoStatoConservazione stato;
        public TipoStatoConservazione Stato
        {
            get => stato;
            set => SetPropertyValue(nameof(Stato),ref stato,value);
        }
    }
}
