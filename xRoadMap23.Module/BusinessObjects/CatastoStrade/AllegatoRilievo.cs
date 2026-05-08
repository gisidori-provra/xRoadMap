using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects
{

    [Persistent(@"RILIEVOPUNTUALE__ATTACH")]
    public partial class AllegatoRilievo: Allegato
    {
        public AllegatoRilievo(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        RilievoPuntuale fRilievo;
        [Persistent(@"REL_OBJECTID")]
        [Association]
        public RilievoPuntuale Rilievo
        {
            get { return fRilievo; }
            set { SetPropertyValue(nameof(Rilievo), ref fRilievo, value); }
        }


    }

}
