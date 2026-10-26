using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
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


        [VisibleInListView(false)]
        [ModelDefault("DisplayFormat", "n0")]
        public double MIniziale => System.Convert.ToDouble(Session.ExecuteScalar($"select sde.st_minm(shape) from percorso where objectid = {Oid}"));

        [VisibleInListView(false)]
        [ModelDefault("DisplayFormat", "n0")]
        public double MFinale => System.Convert.ToDouble(Session.ExecuteScalar($"select sde.st_maxm(shape) from percorso where objectid = {Oid}"));

    }

}
