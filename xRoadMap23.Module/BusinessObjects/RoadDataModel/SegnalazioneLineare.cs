using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.BusinessObjects
{
    [Persistent("EV_SEGNALAZIONELINEARE")]
    public class SegnalazioneLineare:EventoLineare
    {
        public SegnalazioneLineare(Session session):base(session) 
        {

        }


        string fDescrizione;
        [Size(SizeAttribute.Unlimited)]
        public string Descrizione
        {
            get { return fDescrizione; }
            set { SetPropertyValue<string>(nameof(Descrizione), ref fDescrizione, value); }
        }


        TipoSegnalazione tipoSegnalazione;
        public TipoSegnalazione TipoSegnalazione
        {
            get => tipoSegnalazione;
            set => SetPropertyValue(nameof(TipoSegnalazione), ref tipoSegnalazione, value);
        }
    }
}
