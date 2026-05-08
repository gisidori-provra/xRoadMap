using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.BusinessObjects
{
    [Persistent(@"EventoLineare__ATTACH")]
    public partial class AllegatoEventoLineare : Allegato
    {
        public AllegatoEventoLineare(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        EventoLineare evento;
        [Persistent(@"REL_OBJECTID")]
        [Association]
        public EventoLineare Evento
        {
            get { return evento; }
            set { SetPropertyValue(nameof(Evento), ref evento, value); }
        }

    }
}
