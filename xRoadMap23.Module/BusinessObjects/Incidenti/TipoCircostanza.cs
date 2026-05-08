using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace xRoadMap.Module.BusinessObjects.Incidenti
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [NavigationItem("Impostazioni Incidenti")]
    public partial class TipoCircostanza : CodedValues<int>
    {
        public TipoCircostanza(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


}
