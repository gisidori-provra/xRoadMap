using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects.cspra
{

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [Persistent(@"CSPRA.RDSEVENTS")]
    public partial class cspraEvento: XPCustomObject
    {
        public cspraEvento(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }


        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }
        int fEVE_TYPE;
        public int EVE_TYPE
        {
            get { return fEVE_TYPE; }
            set { SetPropertyValue<int>(nameof(EVE_TYPE), ref fEVE_TYPE, value); }
        }
        double fF_XEVENTS;
        public double F_XEVENTS
        {
            get { return fF_XEVENTS; }
            set { SetPropertyValue<double>(nameof(F_XEVENTS), ref fF_XEVENTS, value); }
        }
        double fF_YEVENTS;
        public double F_YEVENTS
        {
            get { return fF_YEVENTS; }
            set { SetPropertyValue<double>(nameof(F_YEVENTS), ref fF_YEVENTS, value); }
        }
        double fF_ZEVENTS;
        public double F_ZEVENTS
        {
            get { return fF_ZEVENTS; }
            set { SetPropertyValue<double>(nameof(F_ZEVENTS), ref fF_ZEVENTS, value); }
        }
        double fT_XEVENTS;
        public double T_XEVENTS
        {
            get { return fT_XEVENTS; }
            set { SetPropertyValue<double>(nameof(T_XEVENTS), ref fT_XEVENTS, value); }
        }
        double fT_YEVENTS;
        public double T_YEVENTS
        {
            get { return fT_YEVENTS; }
            set { SetPropertyValue<double>(nameof(T_YEVENTS), ref fT_YEVENTS, value); }
        }
        double fT_ZEVENTS;
        public double T_ZEVENTS
        {
            get { return fT_ZEVENTS; }
            set { SetPropertyValue<double>(nameof(T_ZEVENTS), ref fT_ZEVENTS, value); }
        }
    }

}
