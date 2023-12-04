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
    [Persistent(@"CSPRA.EVEILLUMINAZIONE")]
    public class cspraIlluminazione : XPCustomObject
    {
        public cspraIlluminazione(Session session) : base(session)
        {

        }

        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }

        double distanza;
        [Persistent("DIST")]
        public double Distanza
        {
            get => distanza;
            set => SetPropertyValue(nameof(Distanza), ref distanza, value);   
        }

        cspraEnum tipo;
        [Persistent("TIPO")]
        public cspraEnum Tipo
        {
            get => tipo;
            set => SetPropertyValue(nameof(Tipo), ref tipo, value);
        }

        cspraEnum tipoIlluminazione;
        [Persistent("TIPOIMP")]
        public cspraEnum TipoIlluminazione
        {
            get => tipoIlluminazione;
            set => SetPropertyValue(nameof(TipoIlluminazione), ref tipoIlluminazione, value);
        }





    }
}
