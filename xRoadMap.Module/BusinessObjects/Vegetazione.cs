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
    public class Vegetazione:EventoLineare,IEventoOnRoad
    {
        public Vegetazione(Session session):base(session)
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


        private TipoVegetazione tipoVegetazione;
        public TipoVegetazione TipoVegetazione
        {
            get => tipoVegetazione;
            set => SetPropertyValue(nameof(TipoVegetazione), ref tipoVegetazione, value);
        }

        private FunzioneVegetazione funzione;
        public FunzioneVegetazione Funzione
        {
            get => funzione;
            set => SetPropertyValue(nameof(Funzione),ref funzione,value);
        }
    }
}
