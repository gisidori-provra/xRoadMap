using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects
{

    [MapInheritance(MapInheritanceType.OwnTable)]
    public partial class LimiteVelocità : EventoLineare, IEventoLineareOnRoad
    {
        public LimiteVelocità(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [Association]
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada), ref strada, value);
        }

        public override void SetStrada(Strada value)
        {
            Strada = value;
        }

        int fLimite;
        [DevExpress.Xpo.DisplayName(@"Limite di velocità (km/h)")]
        public int Limite
        {
            get { return fLimite; }
            set { SetPropertyValue<int>(nameof(Limite), ref fLimite, value); }
        }
    }



}
