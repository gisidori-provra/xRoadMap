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

    public partial class LimiteCentroAbitato : EventoLineare,IEventoOnRoad
    {
        public LimiteCentroAbitato(Session session) : base(session) { }
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

        string fNome;
        public string Nome
        {
            get { return fNome; }
            set { SetPropertyValue<string>(nameof(Nome), ref fNome, value); }
        }
        string fCodiceIstat;
        public string CodiceIstat
        {
            get { return fCodiceIstat; }
            set { SetPropertyValue<string>(nameof(CodiceIstat), ref fCodiceIstat, value); }
        }

    }

}
