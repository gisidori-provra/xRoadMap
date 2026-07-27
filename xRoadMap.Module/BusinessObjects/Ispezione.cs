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

    public partial class Ispezione:XPCustomObject
    {
        public Ispezione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        int fOid;
        [Key(true)]
        [Persistent(@"OBJECTID")]
        [System.ComponentModel.Browsable(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        Ponte fPonte;
        [Association(@"IspezioneReferencesPonte"), NoForeignKey]
        public Ponte Ponte
        {
            get { return fPonte; }
            set { SetPropertyValue<Ponte>(nameof(Ponte), ref fPonte, value); }
        }
        DateTime fData;
        public DateTime Data
        {
            get { return fData; }
            set { SetPropertyValue<DateTime>(nameof(Data), ref fData, value); }
        }
        string fNote;
        [Size(SizeAttribute.Unlimited)]
        public string Note
        {
            get { return fNote; }
            set { SetPropertyValue<string>(nameof(Note), ref fNote, value); }
        }
    }

}
