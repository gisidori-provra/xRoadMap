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
    [Persistent("ponti_schema_statico")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoSchemaStatico : CodedDomain<double>
    {
        public TipoSchemaStatico(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
