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
    [Persistent(@"CSPRA.EVEIMPIANTI_PUBB")]
    public partial class cspraImpiantoPubblicitario:XPCustomObject
    {
        public cspraImpiantoPubblicitario(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }
        cspraEnum fBifacciale;
        public cspraEnum Bifacciale
        {
            get { return fBifacciale; }
            set { SetPropertyValue<cspraEnum>(nameof(Bifacciale), ref fBifacciale, value); }
        }

        private string testo;
        public string Testo
        {
            get => testo;
            set => SetPropertyValue(nameof(Testo), ref testo, value);
        }


    }

}
