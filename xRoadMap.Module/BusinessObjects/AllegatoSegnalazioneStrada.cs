using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.BusinessObjects
{
    [Persistent(@"SegPunto__ATTACH")]
    public partial class AllegatoSegnalazioneStrada : Allegato
    {
        public AllegatoSegnalazioneStrada(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        SegPunto segnalazione;
        [Persistent(@"REL_OBJECTID")]
        [Association]
        public SegPunto SegnalazioneStrada
        {
            get { return segnalazione; }
            set { SetPropertyValue(nameof(SegnalazioneStrada), ref segnalazione, value); }
        }

    }

    [Persistent(@"SegLinea__ATTACH")]
    public partial class AllegatoSegnalazioneLineareStrada : Allegato
    {
        public AllegatoSegnalazioneLineareStrada(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        SegLinea segnalazione;
        [Persistent(@"REL_OBJECTID")]
        [Association]
        public SegLinea SegnalazioneLineareStrada
        {
            get { return segnalazione; }
            set { SetPropertyValue(nameof(SegnalazioneLineareStrada), ref segnalazione, value); }
        }

    }
}