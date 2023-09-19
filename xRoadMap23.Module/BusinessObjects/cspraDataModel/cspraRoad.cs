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
    [Persistent(@"CSPRA.NOMESTRADE")]
    public partial class cspraRoad:XPCustomObject
    {
        public cspraRoad(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        int fROAD_ID;
        [Key]
        public int ROAD_ID
        {
            get { return fROAD_ID; }
            set { SetPropertyValue<int>(nameof(ROAD_ID), ref fROAD_ID, value); }
        }
        string fSIGLA;
        public string SIGLA
        {
            get { return fSIGLA; }
            set { SetPropertyValue<string>(nameof(SIGLA), ref fSIGLA, value); }
        }
    }

}
