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
    [Persistent(@"CSPRA.EVE_SOTTOP_SOVRAP")]
    public class cspraSovrappassi:XPCustomObject
    {
        public cspraSovrappassi(Session session):base(session)
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
            set { SetPropertyValue<cspraEnum>(nameof(Tipo), ref fTipo, value); }
        }

        cspraEnum illuminazione;
        [Persistent("ILLUM")]
        public cspraEnum Illuminazione
        {
            get => illuminazione;
            set => SetPropertyValue(nameof(Illuminazione),ref illuminazione, value);
        }

        cspraEnum statoConservazione;
        [Persistent("Stato")]
        public cspraEnum StatoConservazione
        {
            get => statoConservazione;
            set => SetPropertyValue(nameof(StatoConservazione),ref statoConservazione, value);
        }

    }
}
