using DevExpress.Xpo;
using System.ComponentModel;

namespace xRoadMap.Module.BusinessObjects
{
    [Persistent(@"SegLinea")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    [DefaultProperty(nameof(Descrizione))]
    [System.ComponentModel.DisplayName("Segnalazione lineare")]
    public partial class SegLinea : EventoSuStrada, IEventoLineareOnRoad
    {
        public SegLinea(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            TipoGeometria = TipoGeometriaEvento.Lineare;
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

        [Association, Aggregated]
        public XPCollection<AllegatoSegnalazioneLineareStrada> Allegati => GetCollection<AllegatoSegnalazioneLineareStrada>();


    }
}
