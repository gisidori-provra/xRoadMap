using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace xRoadMap.Module.BusinessObjects
{

    public partial class GeometriaPuntuale:XPSTGeometry
    {
        public GeometriaPuntuale() : base() { }
        public GeometriaPuntuale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }




    }

}
