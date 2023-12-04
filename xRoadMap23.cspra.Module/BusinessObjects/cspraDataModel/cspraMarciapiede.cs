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
    [Persistent(@"CSPRA.EVE_MARCIAPIEDI")]
    public class cspraMarciapiede : XPCustomObject
    {
        public cspraMarciapiede(Session session) : base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        double larghezza;
        public double Larghezza
        {
            get => larghezza;
            set => SetPropertyValue(nameof(Larghezza), ref larghezza, value);   
        }



    }
}
