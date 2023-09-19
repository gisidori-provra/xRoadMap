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
    [Persistent(@"CSPRA.EVETOMBINO")]
    public partial class cspraTombino:XPCustomObject
    {
        public cspraTombino(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }
        cspraEnum fTIPOO;
        public cspraEnum TIPOO
        {
            get { return fTIPOO; }
            set { SetPropertyValue<cspraEnum>(nameof(TIPOO), ref fTIPOO, value); }
        }
    }

}
