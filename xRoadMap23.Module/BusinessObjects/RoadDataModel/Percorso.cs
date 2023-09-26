using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects
{
    public partial class Percorso: XPSTGeometry
    {
        public Percorso() : base() { }
        public Percorso(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        protected override void OnLoaded()
        {
            base.OnLoaded();

        }
        private Strada strada;
        [NoForeignKey]
        public Strada Strada
        {
            get => strada;
            set
            {
                if (strada == value)
                    return;


                Strada prev = strada;
                strada = value;

                if (IsLoading)
                    return;

                if (prev != null && prev.Percorso == this)
                    prev.Percorso = null;

                if (strada != null)
                    strada.Percorso = this;

                OnChanged(nameof(Strada));

            }
        }


    }

}
