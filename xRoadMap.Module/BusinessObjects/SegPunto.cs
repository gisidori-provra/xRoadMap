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

    [Persistent(@"SegPunto")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    [DefaultProperty(nameof(Descrizione))]
    [System.ComponentModel.DisplayName("Segnalazione puntuale")]
    public partial class SegPunto : EventoSuStrada
    {
        public SegPunto(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            TipoGeometria = TipoGeometriaEvento.Puntuale;
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

        private string siglaSP;
        /// <summary>
        /// Per editing mobile tramite CodedDomain StradeProvinciali. Un trigger Oracle aggiorna il campo Strada
        /// </summary>
        [Browsable(false)]
        public string SiglaSP
        {
            get => siglaSP;
            set => SetPropertyValue(nameof(SiglaSP), ref siglaSP, value);
        }

        [Association,Aggregated]
        public XPCollection<AllegatoSegnalazioneStrada> Allegati => GetCollection<AllegatoSegnalazioneStrada>();
        

    }
}
