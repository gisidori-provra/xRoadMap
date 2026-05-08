using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace xRoadMap.Module.BusinessObjects.Incidenti
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoOrganoCoordinatore : CodedValues<int>
    {
        public TipoOrganoCoordinatore(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


}
