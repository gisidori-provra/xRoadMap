using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace xRoadMap.Module.BusinessObjects
{

    [Persistent(@"SegnalazioneStrada")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    [DefaultProperty(nameof(Descrizione))]
    public partial class SegnalazioneStrada : EventoPuntuale,IEventoOnRoad
    {
        public SegnalazioneStrada(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

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

        [Association,Aggregated]
        public XPCollection<AllegatoSegnalazioneStrada> Allegati => GetCollection<AllegatoSegnalazioneStrada>();
        

    }

}
