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

        private OffsetCippo offsetCippo;
        [Browsable(false)]
        public OffsetCippo Offset
        {
            get
            {
                if (offsetCippo == null)
                    offsetCippo = Session.GetObjectByCode<OffsetCippo>(this.Oid,nameof(OffsetCippo.Cippo));
                return offsetCippo;
            }
        }
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

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public string Kilometro
        {
            get
            {
                var km = (int) (Misura / 1000);
                if (Misura %  1000 == 0)
                    return $"Km {km:N0}";
                var offset = (Misura - km * 1000);
                return $"Km {km:N0}+{offset:N0}";
            }
        }

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
