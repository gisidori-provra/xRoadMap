using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects.cspra
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [Persistent(@"[CSPRA].[EVEACCESSI]")]
    public class cspraAccessi:XPCustomObject
    {
        public cspraAccessi(Session session):base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        cspraEnum fDestinazione;
        public cspraEnum Destinazione
        {
            get { return fDestinazione; }
            set { SetPropertyValue<cspraEnum>(nameof(Destinazione), ref fDestinazione, value); }
        }


    }
}
