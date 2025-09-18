using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xRoadMap.Module.BusinessObjects;
using DevExpress.Persistent.Base;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]

    [NavigationItem("Catasto Strade")]
    public class Ciclabile:EventoLineare,IEventoOnRoad
    {
        public Ciclabile(Session session):base(session)
        {

        }

        [Association]
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada),ref strada,value);
        }

        public override void SetStrada(Strada value)
        {
            Strada = value;
        }

        double larghezza;
        public double Larghezza
        {
            get { return larghezza; }
            set => SetPropertyValue(nameof(Larghezza), ref larghezza, value);

        }

        double lunghezza;
        public double Lunghezza
        {
            get { return lunghezza; }
            set => SetPropertyValue(nameof(Lunghezza), ref lunghezza, value);
        }

        private TipoCiclabile tipoCiclabile;
        public TipoCiclabile TipoCiclabile
        {
            get => tipoCiclabile;
            set => SetPropertyValue(nameof(TipoCiclabile),ref tipoCiclabile, value);
        }

        private SensoCiclabile senso;
        public SensoCiclabile Senso
        {
            get => senso;
            set => SetPropertyValue(nameof(Senso),ref senso, value);    
        }

        // Regional specification fields
        
        private string codiceIdentificativoRegionale;
        [Size(50)]
        public string CodiceIdentificativoRegionale
        {
            get => codiceIdentificativoRegionale;
            set => SetPropertyValue(nameof(CodiceIdentificativoRegionale), ref codiceIdentificativoRegionale, value);
        }

        private CategoriaFunzionaleCiclabile categoriaFunzionale;
        public CategoriaFunzionaleCiclabile CategoriaFunzionale
        {
            get => categoriaFunzionale;
            set => SetPropertyValue(nameof(CategoriaFunzionale), ref categoriaFunzionale, value);
        }

        private TipoPavimentazione tipoPavimentazione;
        public TipoPavimentazione TipoPavimentazione
        {
            get => tipoPavimentazione;
            set => SetPropertyValue(nameof(TipoPavimentazione), ref tipoPavimentazione, value);
        }

        private TipoStatoConservazione statoConservazione;
        public TipoStatoConservazione StatoConservazione
        {
            get => statoConservazione;
            set => SetPropertyValue(nameof(StatoConservazione), ref statoConservazione, value);
        }

        private TipologiaProtezioneCiclabile tipologiaProtezione;
        public TipologiaProtezioneCiclabile TipologiaProtezione
        {
            get => tipologiaProtezione;
            set => SetPropertyValue(nameof(TipologiaProtezione), ref tipologiaProtezione, value);
        }

        private CompatibilitaVeicolareCiclabile compatibilitaVeicolare;
        public CompatibilitaVeicolareCiclabile CompatibilitaVeicolare
        {
            get => compatibilitaVeicolare;
            set => SetPropertyValue(nameof(CompatibilitaVeicolare), ref compatibilitaVeicolare, value);
        }

        private double pendenzaMedia;
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n2")]
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", "n2")]
        public double PendenzaMedia
        {
            get => pendenzaMedia;
            set => SetPropertyValue(nameof(PendenzaMedia), ref pendenzaMedia, value);
        }

        private double pendenzaMassima;
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n2")]
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", "n2")]
        public double PendenzaMassima
        {
            get => pendenzaMassima;
            set => SetPropertyValue(nameof(PendenzaMassima), ref pendenzaMassima, value);
        }

        private TipoIlluminazione tipoIlluminazione;
        public TipoIlluminazione TipoIlluminazione
        {
            get => tipoIlluminazione;
            set => SetPropertyValue(nameof(TipoIlluminazione), ref tipoIlluminazione, value);
        }

        private bool accessibilitaDisabili;
        public bool AccessibilitaDisabili
        {
            get => accessibilitaDisabili;
            set => SetPropertyValue(nameof(AccessibilitaDisabili), ref accessibilitaDisabili, value);
        }

        private ConnessioneReteCiclabile connessioneRete;
        public ConnessioneReteCiclabile ConnessioneRete
        {
            get => connessioneRete;
            set => SetPropertyValue(nameof(ConnessioneRete), ref connessioneRete, value);
        }

        private CategoriaUtenzaCiclabile categoriaUtenza;
        public CategoriaUtenzaCiclabile CategoriaUtenza
        {
            get => categoriaUtenza;
            set => SetPropertyValue(nameof(CategoriaUtenza), ref categoriaUtenza, value);
        }

        private bool superficieAntisdrucciolo;
        public bool SuperficieAntisdrucciolo
        {
            get => superficieAntisdrucciolo;
            set => SetPropertyValue(nameof(SuperficieAntisdrucciolo), ref superficieAntisdrucciolo, value);
        }

        private bool presenzaCordolo;
        public bool PresenzaCordolo
        {
            get => presenzaCordolo;
            set => SetPropertyValue(nameof(PresenzaCordolo), ref presenzaCordolo, value);
        }

        private double altezzaCordolo;
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n2")]
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", "n2")]
        public double AltezzaCordolo
        {
            get => altezzaCordolo;
            set => SetPropertyValue(nameof(AltezzaCordolo), ref altezzaCordolo, value);
        }

        private double distanzaCarreggiata;
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n2")]
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", "n2")]
        public double DistanzaCarreggiata
        {
            get => distanzaCarreggiata;
            set => SetPropertyValue(nameof(DistanzaCarreggiata), ref distanzaCarreggiata, value);
        }

    }
}
