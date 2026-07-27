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

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoCippo : CodedValues<int>
    {
        public TipoCippo(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
