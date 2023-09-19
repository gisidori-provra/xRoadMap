using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects.cspra
{
    [Persistent("CSPRA.RDSEVENTSPOLYLINES")]
    public partial class CSPRA_RDSEVENTSPOLYLINES:XPSTGeometry
    {
        public CSPRA_RDSEVENTSPOLYLINES(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        int fID_EVE;
        public int ID_EVE
        {
            get { return fID_EVE; }
            set { SetPropertyValue<int>(nameof(ID_EVE), ref fID_EVE, value); }
        }
        short fEVE_TYPE;
        public short EVE_TYPE
        {
            get { return fEVE_TYPE; }
            set { SetPropertyValue<short>(nameof(EVE_TYPE), ref fEVE_TYPE, value); }
        }
        int fID_EOR;
        public int ID_EOR
        {
            get { return fID_EOR; }
            set { SetPropertyValue<int>(nameof(ID_EOR), ref fID_EOR, value); }
        }
    }

}
