using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects
{

    [MapInheritance(MapInheritanceType.OwnTable)]
    public partial class Banchina : EventoPuntuale, IEventoOnRoad
    {
        public Banchina(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

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

        double fLarghezza;
        [DevExpress.Xpo.DisplayName(@"Larghezza (mt.)")]
        public double Larghezza
        {
            get { return fLarghezza; }
            set { SetPropertyValue<double>(nameof(Larghezza), ref fLarghezza, value); }
        }

        TipoPavimentazione fTipoPavimentazione;
        [NoForeignKey]
        public TipoPavimentazione TipoPavimentazione
        {
            get { return fTipoPavimentazione; }
            set { SetPropertyValue(nameof(BusinessObjects.TipoPavimentazione), ref fTipoPavimentazione, value); }
        }

        TipoSuperficie fTipoSuperficie;
        [NoForeignKey]
        public TipoSuperficie TipoSuperficie
        {
            get => fTipoSuperficie;
            set => SetPropertyValue(nameof(TipoSuperficie),ref fTipoSuperficie, value);
        }

    }

}
