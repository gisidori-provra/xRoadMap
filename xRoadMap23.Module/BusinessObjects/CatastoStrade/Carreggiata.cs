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

    public class Carreggiata : EventoLineare, IEventoOnRoad
    {
        public Carreggiata(Session session) : base(session)
        {

        }

        [Association]
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada), ref strada, value);
        }

        public override void SetStrada(Strada value)
        {
            Strada = value;
        }

        private double larghezza;

        public double Larghezza
        {
            get => larghezza;
            set => SetPropertyValue(nameof(Larghezza), ref larghezza, value);
        }



        private TipoCarreggiata tipoCarreggiata;
        public TipoCarreggiata TipoCarreggiata
        {
            get => tipoCarreggiata;
            set => SetPropertyValue(nameof(TipoCarreggiata), ref tipoCarreggiata, value);
        }
    }
}
