using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{
    public class DenominazioneStrada : EventoLineare, IEventoOnRoad
    {
        public DenominazioneStrada(Session session) : base(session)
        { }

        [Association]
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada), ref strada, value);
        }

        public override void SetStrada(Strada value)
        {
            Strada = value;
        }


        string denominazione;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Denominazione
        {
            get => denominazione;
            set => SetPropertyValue(nameof(Denominazione), ref denominazione, value);
        }

    }
}
