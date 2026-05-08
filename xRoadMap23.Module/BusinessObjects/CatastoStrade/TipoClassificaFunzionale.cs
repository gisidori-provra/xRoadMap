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
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoClassificaFunzionale : CodedValues<string>
    {
        public TipoClassificaFunzionale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

    }

}
