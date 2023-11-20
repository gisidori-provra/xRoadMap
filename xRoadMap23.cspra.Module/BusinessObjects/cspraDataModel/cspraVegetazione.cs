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
    [Persistent(@"CSPRA.EVE_VEGETA")]
    public class cspraVegetazione:XPCustomObject
    {
        public cspraVegetazione(Session session):base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        cspraEnum fTipoVegetazione;
        [Persistent("Tipo")]
        public cspraEnum TipoVegetazione
        {
            get { return fTipoVegetazione; }
            set { SetPropertyValue<cspraEnum>(nameof(TipoVegetazione), ref fTipoVegetazione, value); }
        }

        cspraEnum fFunzione;
        public cspraEnum Funzione
        {
            get { return fFunzione; }
            set => SetPropertyValue(nameof(Funzione), ref fFunzione, value);
        }

    }
}
