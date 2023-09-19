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
    [Persistent(@"CSPRA.RDSEVENTSONROAD")]
    public partial class cspraEventoOnRoad:XPCustomObject
    {
        public cspraEventoOnRoad(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        int fEOR_ID;
        public int EOR_ID
        {
            get { return fEOR_ID; }
            set { SetPropertyValue<int>(nameof(EOR_ID), ref fEOR_ID, value); }
        }
        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }
        cspraRoad fROAD_ID;
        public cspraRoad ROAD_ID
        {
            get { return fROAD_ID; }
            set { SetPropertyValue<cspraRoad>(nameof(ROAD_ID), ref fROAD_ID, value); }
        }
        double fF_MEVENTS;
        public double F_MEVENTS
        {
            get { return fF_MEVENTS; }
            set { SetPropertyValue<double>(nameof(F_MEVENTS), ref fF_MEVENTS, value); }
        }
        double fT_MEVENTS;
        public double T_MEVENTS
        {
            get { return fT_MEVENTS; }
            set { SetPropertyValue<double>(nameof(T_MEVENTS), ref fT_MEVENTS, value); }
        }
        double fE_OFFSET;
        public double E_OFFSET
        {
            get { return fE_OFFSET; }
            set { SetPropertyValue<double>(nameof(E_OFFSET), ref fE_OFFSET, value); }
        }
    }

}
