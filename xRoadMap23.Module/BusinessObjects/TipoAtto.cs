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

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [DefaultProperty(nameof(Codice))]
    public partial class TipoAtto : XPCustomObject
    {
        public TipoAtto(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private int oid;
        [Key(true), VisibleInListView(false)]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue(nameof(Oid), ref oid, value);
        }

        private string codice;
        public string Codice
        {
            get => codice;
            set =>SetPropertyValue(nameof(Codice), ref codice, value);
        }

        private string descrizione;
        [VisibleInListView(true)]
        public string Descrizione
        {
            get => descrizione;
            set => SetPropertyValue<string>(nameof(Descrizione), ref descrizione, value);
        }

    }

}
