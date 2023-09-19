using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.BusinessObjects
{
    [Persistent(@"EventoPuntuale__ATTACH")]
    public partial class AllegatoEventoPuntuale : Allegato
    {
        public AllegatoEventoPuntuale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        EventoPuntuale evento;
        [Persistent(@"REL_OBJECTID")]
        [Association]
        public EventoPuntuale Evento
        {
            get { return evento; }
            set { SetPropertyValue(nameof(Evento), ref evento, value); }
        }


    }
}