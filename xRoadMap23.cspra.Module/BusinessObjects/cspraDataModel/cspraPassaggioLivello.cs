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
    [Persistent(@"CSPRA.EVE_PL")]
    public class cspraPassaggioLivello:XPCustomObject
    {
        public cspraPassaggioLivello(Session session):base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        cspraEnum tipo;
        public cspraEnum Tipo
        {
            get { return tipo; }
            set { SetPropertyValue<cspraEnum>(nameof(Tipo), ref tipo, value); }
        }

        int numeroBinari;
        [Persistent("N_BINARI")]
        public int NumeroBinari
        {
            get { return numeroBinari; }
            set => SetPropertyValue(nameof(NumeroBinari), ref numeroBinari, value); 
        }

    }
}
