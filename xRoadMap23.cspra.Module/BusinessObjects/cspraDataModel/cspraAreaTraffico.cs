using DevExpress.Utils.Text.Internal;
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
    [Persistent(@"CSPRA.EVE_AREA_TRAFFICO")]
    public class cspraAreaTraffico:XPCustomObject
    {
        public cspraAreaTraffico(Session session):base(session) 
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        string fDenominazione;
        [Persistent("DENOM_UFF")]
        public string Denominazione
        {
            get => fDenominazione;
            set => SetPropertyValue(nameof(Denominazione),ref fDenominazione, value);
        }

        cspraEnum fTipoServizio;
        [Persistent("TIPO_SERVIZIO")]
        public cspraEnum TipoServizio
        {
            get { return fTipoServizio; }
            set { SetPropertyValue(nameof(TipoServizio), ref fTipoServizio, value); }
        }

        cspraEnum fCorsie;
        [Persistent("CORSIE_ACC_DEC")]
        public cspraEnum Corsie
        {
            get { return fCorsie; }
            set { SetPropertyValue(nameof(Corsie), ref fCorsie, value); }
        }


    }
}
