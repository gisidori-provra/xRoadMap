using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects.Incidenti
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoLocalizzazione : CodedValues<int>
    {
        public TipoLocalizzazione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoTronco : CodedValues<int>
    {
        public TipoTronco(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoStrada : CodedValues<int>
    {
        public TipoStrada(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoPavimentazione : CodedValues<int>
    {
        public TipoPavimentazione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoIntersezione : CodedValues<int>
    {
        public TipoIntersezione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoFondoStradale : CodedValues<int>
    {
        public TipoFondoStradale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoSegnaletica : CodedValues<int>
    {
        public TipoSegnaletica(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoMeteo : CodedValues<int>
    {
        public TipoMeteo(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoNaturaIncidente : CodedValues<int>
    {
        public TipoNaturaIncidente(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoVeicolo : CodedValues<int>
    {
        public TipoVeicolo(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoPatente : CodedValues<int>
    {
        public TipoPatente(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoEsito : CodedValues<int>
    {
        public TipoEsito(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
