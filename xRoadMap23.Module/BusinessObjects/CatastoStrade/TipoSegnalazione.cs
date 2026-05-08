using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [DefaultProperty(nameof(Codice))]
    [NavigationItem("Impostazioni Catasto Strade")]
    public class TipoSegnalazione:CodedDomain<int>
    {
        public TipoSegnalazione(Session session):base(session)
        {

        }
    }
}
