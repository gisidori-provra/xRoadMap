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
    [Persistent(@"CSPRA.RDSENUM")]
    public partial class cspraEnum:XPCustomObject
    {
        public cspraEnum(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        int fENUM_ID;
        [Key]
        public int ENUM_ID
        {
            get { return fENUM_ID; }
            set { SetPropertyValue<int>(nameof(ENUM_ID), ref fENUM_ID, value); }
        }
        string fENUM_VAL;
        public string ENUM_VAL
        {
            get { return fENUM_VAL; }
            set { SetPropertyValue<string>(nameof(ENUM_VAL), ref fENUM_VAL, value); }
        }
        string fENUM_DESC;
        public string ENUM_DESC
        {
            get { return fENUM_DESC; }
            set { SetPropertyValue<string>(nameof(ENUM_DESC), ref fENUM_DESC, value); }
        }
        string fENUM_DOM;
        public string ENUM_DOM
        {
            get { return fENUM_DOM; }
            set { SetPropertyValue<string>(nameof(ENUM_DOM), ref fENUM_DOM, value); }
        }
    }

}
