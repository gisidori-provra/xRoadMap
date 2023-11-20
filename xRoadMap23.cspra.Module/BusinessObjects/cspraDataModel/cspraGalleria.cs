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
    [Persistent(@"CSPRA.EVE_GALLERIE")]
    public class cspraGallerie:XPCustomObject
    {
        public cspraGallerie(Session session):base(session)
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
        cspraEnum illuminazioneImbocco;
        [Persistent("ILLUM_IMB")]
        public cspraEnum IlluminazioneImbocco
        {
            get => illuminazioneImbocco;
            set => SetPropertyValue(nameof(IlluminazioneImbocco),ref illuminazioneImbocco, value);
        }

        cspraEnum illuminazione;
        [Persistent("ILLUM_GALL")]
        public cspraEnum Illuminazione
        {
            get => illuminazione;
            set => SetPropertyValue(nameof(Illuminazione),ref illuminazione, value);
        }

        cspraEnum ventilazione;
        public cspraEnum Ventilazione
        {
            get => ventilazione;
            set => SetPropertyValue(nameof(Ventilazione), ref ventilazione, value);
        }

        cspraEnum stato;
        public cspraEnum Stato
        {
            get => stato;
            set => SetPropertyValue(nameof(Stato), ref stato, value);
        }


        cspraEnum piazzole;
        public cspraEnum Piazzole
        {
            get => piazzole;
            set => SetPropertyValue(nameof(Piazzole), ref piazzole, value);
        }



    }
}
