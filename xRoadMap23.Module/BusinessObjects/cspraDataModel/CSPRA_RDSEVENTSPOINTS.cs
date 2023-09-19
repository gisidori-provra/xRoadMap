using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects.cspra
{
    [Persistent("CSPRA.RDSEVENTSPOINTS")]
    public partial class CSPRA_RDSEVENTSPOINTS: XPSTGeometry
    {
        public CSPRA_RDSEVENTSPOINTS(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        int fID_EVE;
        public int ID_EVE
        {
            get { return fID_EVE; }
            set { SetPropertyValue<int>(nameof(ID_EVE), ref fID_EVE, value); }
        }
        int fEVE_TYPE;
        public int EVE_TYPE
        {
            get { return fEVE_TYPE; }
            set { SetPropertyValue<int>(nameof(EVE_TYPE), ref fEVE_TYPE, value); }
        }
        int fID_EOR;
        public int ID_EOR
        {
            get { return fID_EOR; }
            set { SetPropertyValue<int>(nameof(ID_EOR), ref fID_EOR, value); }
        }
    }

}
