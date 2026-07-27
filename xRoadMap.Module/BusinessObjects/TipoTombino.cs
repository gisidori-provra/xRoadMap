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
    [Persistent("tombini")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoTombino : CodedDomain<double>
    {
        public TipoTombino(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
