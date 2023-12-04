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
    public partial class ImpiantoPubblicitario : EventoPuntuale,IEventoOnRoad
    {
        public ImpiantoPubblicitario(Session session) : base(session) { }
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


        string fTesto;
        public string Testo
        {
            get { return fTesto; }
            set { SetPropertyValue<string>(nameof(Testo), ref fTesto, value); }
        }

        string fBifacciale;
        public string Bifacciale
        {
            get => fBifacciale;
            set => SetPropertyValue(nameof(Bifacciale), ref fBifacciale, value);
        }




    }

}
