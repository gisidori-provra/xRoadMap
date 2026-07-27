using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;

namespace xRoadMap.Module.BusinessObjects
{

    [MapInheritance(MapInheritanceType.OwnTable)]
    [NavigationItem("Catasto Strade")]
    public partial class Tombino : EventoPuntuale,IEventoOnRoad
    {
        public Tombino(Session session) : base(session) { }
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


        string fNome;
        public string Nome
        {
            get { return fNome; }
            set { SetPropertyValue<string>(nameof(Nome), ref fNome, value); }
        }
        double fLarghezza;
        [DevExpress.Xpo.DisplayName(@"Larghezza (mt.)")]
        public double Larghezza
        {
            get { return fLarghezza; }
            set { SetPropertyValue<double>(nameof(Larghezza), ref fLarghezza, value); }
        }
        TipoTombino fTipoTombino;
        [NoForeignKey]
        public TipoTombino TipoTombino
        {
            get { return fTipoTombino; }
            set { SetPropertyValue<TipoTombino>(nameof(TipoTombino), ref fTipoTombino, value); }
        }

    }

}
