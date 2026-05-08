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
    [Persistent("ponti_materiale")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoMateriale : CodedDomain<string>
    {
        public TipoMateriale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
