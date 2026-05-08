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
    [Persistent("ponti_elemento_attraversato")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoElementoAttraversato : CodedDomain<string>
    {
        public TipoElementoAttraversato(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
