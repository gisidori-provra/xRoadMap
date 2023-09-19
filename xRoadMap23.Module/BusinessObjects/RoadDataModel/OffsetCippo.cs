using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects
{

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [MemberDesignTimeVisibility(false)]
    public partial class OffsetCippo: XPCustomObject
    {
        public OffsetCippo(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        Cippo fCippo;
        [Key]
        [Persistent(@"INPUTOID")]
        public Cippo Cippo
        {
            get { return fCippo; }
            set { SetPropertyValue<Cippo>(nameof(Cippo), ref fCippo, value); }
        }
        double fMeasure;

        [Persistent("MEAS")]
        public double Measure
        {
            get { return fMeasure; }
            set { SetPropertyValue<double>(nameof(Measure), ref fMeasure, value); }
        }


    }

}
