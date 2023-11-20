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
    [Persistent(@"CSPRA.EVE_CORPOSTRADA")]
    public class cspraCorpoStradale : XPCustomObject
    {
        public cspraCorpoStradale(Session session) : base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        cspraEnum fDelimitazione;
        public cspraEnum Delimitazione
        {
            get { return fDelimitazione; }
            set { SetPropertyValue<cspraEnum>(nameof(DelayedAttribute), ref fDelimitazione, value); }
        }

        cspraEnum fTipo;
        [Persistent("TIPO")]
        public cspraEnum TipoCorpoStradale
        {
            get => fTipo;
            set => SetPropertyValue(nameof(TipoCorpoStradale), ref fTipo, value);   
        }


    }
}
