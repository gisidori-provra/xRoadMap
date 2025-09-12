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
    /// <summary>
    /// Classe per la gestione dei percorsi ciclabili.
    /// Conforme al modello regionale Emilia-Romagna per il dataset minimo DB LINEARE e attributi estesi:
    /// 
    /// Attributi minimi richiesti:
    /// - ID_txt: identificativo univoco del tratto
    /// - STATO_AGG: stato di attuazione 
    /// - TIPO_CL_1/2: tipologia percorso ciclabile
    /// - LIM_TR: limitazione traffico veicolare
    /// - SEN_MARCIA: senso di marcia
    /// - FONTE: fonte del dato
    /// - NOTE: annotazioni
    /// 
    /// Attributi aggiuntivi per completezza del modello:
    /// - MATERIALE_SUP: materiale superficie
    /// - ILLUMINAZIONE: presenza illuminazione
    /// - PENDENZA: pendenza percentuale
    /// - TIPO_PROTEZIONE: tipo protezione ciclisti
    /// - ENTE_GESTORE: ente responsabile gestione
    /// - ANNO_COSTRUZIONE: anno di costruzione
    /// - ULTIMA_MANUTENZIONE: data ultima manutenzione
    /// - ACCESSIBILITA: livello accessibilità
    /// - LIVELLO_PRIORITA: priorità nell'infrastruttura
    /// - VELOCITA_MAX: velocità massima consentita
    /// </summary>
    [MapInheritance(MapInheritanceType.OwnTable)]

    [NavigationItem("Catasto Strade")]
    public class Ciclabile:EventoLineare,IEventoOnRoad
    {
        public Ciclabile(Session session):base(session)
        {

        }

        Strada strada;
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

        // Proprietà aggiuntive per il modello regionale Emilia-Romagna

        private string idTxt;
        [DisplayName("ID Tratto")]
        public string ID_txt
        {
            get => idTxt;
            set => SetPropertyValue(nameof(ID_txt), ref idTxt, value);
        }

        private StatoAttuazioneCiclabile statoAttuazione;
        [DisplayName("Stato Attuazione")]
        public StatoAttuazioneCiclabile STATO_AGG
        {
            get => statoAttuazione;
            set => SetPropertyValue(nameof(STATO_AGG), ref statoAttuazione, value);
        }

        private TipoCiclabile tipoCl1;
        [DisplayName("Tipologia Percorso 1")]
        public TipoCiclabile TIPO_CL_1
        {
            get => tipoCl1;
            set => SetPropertyValue(nameof(TIPO_CL_1), ref tipoCl1, value);
        }

        private TipoCiclabile tipoCl2;
        [DisplayName("Tipologia Percorso 2")]
        public TipoCiclabile TIPO_CL_2
        {
            get => tipoCl2;
            set => SetPropertyValue(nameof(TIPO_CL_2), ref tipoCl2, value);
        }

        private LimitazioneTrafficoCiclabile limitazioneTraffico;
        [DisplayName("Limitazione Traffico")]
        public LimitazioneTrafficoCiclabile LIM_TR
        {
            get => limitazioneTraffico;
            set => SetPropertyValue(nameof(LIM_TR), ref limitazioneTraffico, value);
        }

        private SensoCiclabile sensoMarcia;
        [DisplayName("Senso di Marcia")]
        public SensoCiclabile SEN_MARCIA
        {
            get => sensoMarcia;
            set => SetPropertyValue(nameof(SEN_MARCIA), ref sensoMarcia, value);
        }

        private string fonte;
        [DisplayName("Fonte Dato")]
        public string FONTE
        {
            get => fonte;
            set => SetPropertyValue(nameof(FONTE), ref fonte, value);
        }

        private string note;
        [DisplayName("Note")]
        [Size(SizeAttribute.Unlimited)]
        public string NOTE
        {
            get => note;
            set => SetPropertyValue(nameof(NOTE), ref note, value);
        }

        // Attributi aggiuntivi per completezza del modello regionale

        private MaterialeSuperficieCiclabile materialeSuperficie;
        [DisplayName("Materiale Superficie")]
        public MaterialeSuperficieCiclabile MATERIALE_SUP
        {
            get => materialeSuperficie;
            set => SetPropertyValue(nameof(MATERIALE_SUP), ref materialeSuperficie, value);
        }

        private bool illuminazione;
        [DisplayName("Illuminazione")]
        public bool ILLUMINAZIONE
        {
            get => illuminazione;
            set => SetPropertyValue(nameof(ILLUMINAZIONE), ref illuminazione, value);
        }

        private double pendenza;
        [DisplayName("Pendenza (%)")]
        public double PENDENZA
        {
            get => pendenza;
            set => SetPropertyValue(nameof(PENDENZA), ref pendenza, value);
        }

        private TipoProtezioneCiclabile tipoProtezione;
        [DisplayName("Tipo Protezione")]
        public TipoProtezioneCiclabile TIPO_PROTEZIONE
        {
            get => tipoProtezione;
            set => SetPropertyValue(nameof(TIPO_PROTEZIONE), ref tipoProtezione, value);
        }

        private string enteGestore;
        [DisplayName("Ente Gestore")]
        public string ENTE_GESTORE
        {
            get => enteGestore;
            set => SetPropertyValue(nameof(ENTE_GESTORE), ref enteGestore, value);
        }

        private DateTime? annoCostruzione;
        [DisplayName("Anno Costruzione")]
        public DateTime? ANNO_COSTRUZIONE
        {
            get => annoCostruzione;
            set => SetPropertyValue(nameof(ANNO_COSTRUZIONE), ref annoCostruzione, value);
        }

        private DateTime? ultimaManutenzione;
        [DisplayName("Ultima Manutenzione")]
        public DateTime? ULTIMA_MANUTENZIONE
        {
            get => ultimaManutenzione;
            set => SetPropertyValue(nameof(ULTIMA_MANUTENZIONE), ref ultimaManutenzione, value);
        }

        private AccessibilitaCiclabile accessibilita;
        [DisplayName("Accessibilità")]
        public AccessibilitaCiclabile ACCESSIBILITA
        {
            get => accessibilita;
            set => SetPropertyValue(nameof(ACCESSIBILITA), ref accessibilita, value);
        }

        private PriorityLevelCiclabile livelloPriorita;
        [DisplayName("Livello Priorità")]
        public PriorityLevelCiclabile LIVELLO_PRIORITA
        {
            get => livelloPriorita;
            set => SetPropertyValue(nameof(LIVELLO_PRIORITA), ref livelloPriorita, value);
        }

        private double velocitaMax;
        [DisplayName("Velocità Massima (km/h)")]
        public double VELOCITA_MAX
        {
            get => velocitaMax;
            set => SetPropertyValue(nameof(VELOCITA_MAX), ref velocitaMax, value);
        }

    }
}
