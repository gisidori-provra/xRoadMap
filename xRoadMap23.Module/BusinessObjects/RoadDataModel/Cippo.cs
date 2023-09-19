using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;

namespace xRoadMap.Module.BusinessObjects
{
    [EditorAlias("MapListEditor")]
    [Persistent(@"CIPPO")]
    public partial class Cippo : XPSTGeometry
    {
        public Cippo() : base() { }
        public Cippo(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [Browsable(false)]
        public OffsetCippo Offset => Session.GetObjectByKey<OffsetCippo>(this.Oid);
        Strada fStrada;
        [Association(), NoForeignKey]
        public Strada Strada
        {
            get { return fStrada; }
            set { SetPropertyValue<Strada>(nameof(Strada), ref fStrada, value); }
        }
        double fMisura;
        public double Misura
        {
            get { return fMisura; }
            set { SetPropertyValue<double>(nameof(Misura), ref fMisura, value); }
        }

        [NonPersistent]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public string Kilometro => $"Km {(Misura / 1000):N0}";

        TipoCippo fTipoCippo;
        [NoForeignKey]
        public TipoCippo TipoCippo
        {
            get { return fTipoCippo; }
            set { SetPropertyValue<TipoCippo>(nameof(TipoCippo), ref fTipoCippo, value); }
        }
        double fZPos;
        [Persistent(@"Z")]
        public double ZPos
        {
            get { return fZPos; }
            set { SetPropertyValue<double>(nameof(ZPos), ref fZPos, value); }
        }
    }
}
