using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects.cspra
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [Persistent(@"CSPRA.EVEARGINELLI")]
    public class cspraArginelli:XPCustomObject
    {
        public cspraArginelli(Session session):base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        double larghezzaDX;
        [Persistent("LARGHDX")]
        public double LarghezzaDX
        {
            get { return larghezzaDX; }
            set => SetPropertyValue(nameof(LarghezzaDX),ref larghezzaDX, value);

        }

        double larghezzaSX;
        [Persistent("LARGHSX")]
        public double LarghezzaSX
        {
            get { return larghezzaSX; }
            set => SetPropertyValue(nameof(LarghezzaSX), ref larghezzaSX, value);
        }



    }
}
