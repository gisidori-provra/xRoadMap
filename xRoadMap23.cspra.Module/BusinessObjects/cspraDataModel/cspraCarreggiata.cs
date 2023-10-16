using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects.cspra;

namespace xRoadMap.cspra.Module.Module.BusinessObjects.cspraDataModel
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [Persistent(@"CSPRA.EVE_CARREGGIATA")]
    public class cspraCarreggiata : XPCustomObject
    {
        public cspraCarreggiata(Session session) : base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        cspraEnum fTipo;
        public cspraEnum Tipo
        {
            get { return fTipo; }
            set { SetPropertyValue(nameof(Tipo), ref fTipo, value); }
        }

        int fLarghezza;
        public int Larghezza
        {
            get => fLarghezza;
            set => SetPropertyValue(nameof(Larghezza), ref fLarghezza, value);
        }



    }
}
