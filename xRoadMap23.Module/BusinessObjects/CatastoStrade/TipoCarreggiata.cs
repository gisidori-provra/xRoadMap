using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;

namespace xRoadMap.Module.BusinessObjects
{

    [Persistent("carreggiata_tipo")]
    [NavigationItem("Impostazioni Catasto Strade")]
    [XafDefaultProperty(nameof(Descrizione))]
    public partial class TipoCarreggiata : CodedDomain<double>
    {
        public TipoCarreggiata(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
