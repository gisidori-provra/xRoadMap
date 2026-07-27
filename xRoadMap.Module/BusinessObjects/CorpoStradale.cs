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

    public class CorpoStradale:EventoLineare,IEventoOnRoad
    {
        public CorpoStradale(Session session):base(session)
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


        private TipoDelimitazione delimitazione;
        public TipoDelimitazione Delimitazione
        {
            get => delimitazione;
            set => SetPropertyValue(nameof(Delimitazione), ref delimitazione, value);
        }

        private TipologiaCorpoStradale tipoCorpoStradale;
        public TipologiaCorpoStradale TipoCorpoStradale
        {
            get => tipoCorpoStradale;
            set => SetPropertyValue(nameof(TipoCorpoStradale),ref tipoCorpoStradale,value);
        }

    }
}
