using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.BusinessObjects
{
    [Persistent(@"SegnalazioneStrada__ATTACH")]
    public partial class AllegatoSegnalazioneStrada : Allegato
    {
        public AllegatoSegnalazioneStrada(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        SegnalazioneStrada segnalazione;
        [Persistent(@"REL_OBJECTID")]
        [Association]
        public SegnalazioneStrada SegnalazioneStrada
        {
            get { return segnalazione; }
            set { SetPropertyValue(nameof(SegnalazioneStrada), ref segnalazione, value); }
        }

    }

    [Persistent(@"SegnalazioneLineareStrada__ATTACH")]
    public partial class AllegatoSegnalazioneLineareStrada : Allegato
    {
        public AllegatoSegnalazioneLineareStrada(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        SegnalazioneLineareStrada segnalazione;
        [Persistent(@"REL_OBJECTID")]
        [Association]
        public SegnalazioneLineareStrada SegnalazioneLineareStrada
        {
            get { return segnalazione; }
            set { SetPropertyValue(nameof(SegnalazioneLineareStrada), ref segnalazione, value); }
        }

    }
}