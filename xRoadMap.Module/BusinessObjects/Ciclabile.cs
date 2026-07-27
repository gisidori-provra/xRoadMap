using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xRoadMap.Module.BusinessObjects;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Pdf;
using DevExpress.ExpressApp.Model;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]

    [NavigationItem("Catasto Strade")]
    public class Ciclabile:EventoSuStrada,IEventoOnRoad
    {
        public Ciclabile(Session session):base(session)
        {

        }
        public override void AfterConstruction()
        {
            TipoGeometria = TipoGeometriaEvento.Lineare;
            base.AfterConstruction();
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Id_RER
        {
            get => iD_RER;
            set => SetPropertyValue(nameof(Id_RER), ref iD_RER, value);
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

        string noteShp;
        string immagini;
        string dettaglio;
        string fonteCompilazione;
        DateTime dataCompilazione;
        decimal importoFinanziamento;
        string iDFinFonte;
        string fonteFinanziamento;
        string descrizioneIntervento;
        int anno;
        CiclabileTipoInt tipoIntervento;
        CiclabileFinanz finanziamento;
        CiclabileRaccordoSpezzate raccordoSpezzate;
        string criticità;
        string linkMonitoraggio;
        bool monitoraggio;
        CiclabileIlluminazione illuminazione;
        CiclabileAlbertature alberature;
        CiclabileSegnalTur segnaliTuristici;
        int pendenza;
        bool argine;
        string dotazioniSicurezza;
        bool attraversamento;
        CiclabileInfrastr infrastruttura;
        CiclabileFondo fondo2;
        CiclabileFondo fondo1;
        CiclabileSepar1 separatore2;
        CiclabileSepar1 separatore1;
        int larghezza2;
        int larghezza1;
        CiclabileLimTr limitazioneTraffico;
        CiclabileTipoCl1 tipoCL2;
        CiclabileTipoCl1 tipoCL1;
        CiclabileClassPlan classificazioneBiciplan;
        CiclabileVocazione vocazione;
        string toponimo;
        string nome;
        string reteLocale;
        string areaVasta;
        CiclabileContesto contesto;
        CiclabileRcr rcr;
        CiclabileBicitalia bicitalia;
        CiclabileSnct snct;
        CiclabileEurov euroVelo;
        Provincia provincia;
        Comune comune;
        string note;
        CiclabileStatoAgg statoAttuazione;
        string iD_RER;
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
            set => SetPropertyValue(nameof(TipoCiclabile), ref tipoCiclabile, value);
        }

        private SensoCiclabile senso;
        public SensoCiclabile Senso
        {
            get => senso;
            set => SetPropertyValue(nameof(Senso), ref senso, value);
        }

        [ToolTip("Indicazione dello stato esistente/progetto/realizzata, con riferimento alla data di inserimento del dato")]
        [Persistent("Stato_AGG")]
        public CiclabileStatoAgg StatoAttuazione
        {
            get => statoAttuazione;
            set => SetPropertyValue(nameof(StatoAttuazione), ref statoAttuazione, value);
        }

        [ToolTip("Eventuali annotazioni sul dato cartografico")]
        [Persistent("note_shp")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NoteShp
        {
            get => noteShp;
            set => SetPropertyValue(nameof(NoteShp), ref noteShp, value);
        }

        [Persistent("COD_ISTAT")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Comune Comune
        {
            get => comune;
            set => SetPropertyValue(nameof(Comune), ref comune, value);
        }


        public Provincia Provincia
        {
            get => provincia;
            set => SetPropertyValue(nameof(Provincia), ref provincia, value);
        }

        [ToolTip("Indicazione del nome/sigla dell’itinerario cicloturistico Eurovelo")]
        [Persistent("R_EUROV")]
        public CiclabileEurov EuroVelo
        {
            get => euroVelo;
            set => SetPropertyValue(nameof(EuroVelo), ref euroVelo, value);
        }

        [ToolTip("Indicazione del nome/sigla dell’itinerario cicloturistico SNCT (Sistema Nazionale Ciclovie Turistiche)")]
        [Persistent("R_SNCT")]
        public CiclabileSnct Snct
        {
            get => snct;
            set => SetPropertyValue(nameof(Snct), ref snct, value);
        }

        [ToolTip("Indicazione del nome/sigla dell’itinerario cicloturistico Bicitalia")]
        [Persistent("R_BICIT")]
        public CiclabileBicitalia Bicitalia
        {
            get => bicitalia;
            set => SetPropertyValue(nameof(Bicitalia), ref bicitalia, value);
        }

        [ToolTip("Indicazione del nome/sigla dell’itinerario cicloturistico RCR (Rete Ciclabile Regionale)")]
        [Persistent("R_RCR")]
        public CiclabileRcr Rcr
        {
            get => rcr;
            set => SetPropertyValue(nameof(Rcr), ref rcr, value);
        }

        [ToolTip("Indicare l’area vasta di appartenenza del tratto")]
        [Persistent("R_A_VASTA")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string AreaVasta
        {
            get => areaVasta;
            set => SetPropertyValue(nameof(AreaVasta), ref areaVasta, value);
        }

        [ToolTip("Indicare la rete locale di appartenenza del tratto")]
        [Persistent("RETE_LOC")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ReteLocale
        {
            get => reteLocale;
            set => SetPropertyValue(nameof(ReteLocale), ref reteLocale, value);
        }

        [ToolTip("Indicare il nome della ciclabile, se presente")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nome
        {
            get => nome;
            set => SetPropertyValue(nameof(Nome), ref nome, value);
        }

        [ToolTip("Indicazione del toponimo locale se pertinente, nei casi in cui il tratto non rientri nella casistica sopra indicata")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Toponimo
        {
            get => toponimo;
            set => SetPropertyValue(nameof(Toponimo), ref toponimo, value);
        }

        [ToolTip("Indicazione della vocazione della ciclabile")]
        public CiclabileVocazione Vocazione
        {
            get => vocazione;
            set => SetPropertyValue(nameof(Vocazione), ref vocazione, value);
        }

        [ToolTip("Classificazione secondo il Biciplan della Regione Emilia-Romagna")]
        [Persistent("CLASS_PLAN")]
        public CiclabileClassPlan ClassificazioneBiciplan
        {
            get => classificazioneBiciplan;
            set => SetPropertyValue(nameof(ClassificazioneBiciplan), ref classificazioneBiciplan, value);
        }

        [ToolTip("Indicazione della tipologia del percorso ciclabile con riferimento al tipo sede e uso")]
        [Persistent("TIPO_CL_1")]
        public CiclabileTipoCl1 TipoCL1
        {
            get => tipoCL1;
            set => SetPropertyValue(nameof(TipoCL1), ref tipoCL1, value);
        }

        [ToolTip("Indicazione della tipologia del percorso ciclabile con riferimento al tipo sede e uso")]
        [Persistent("TIPO_CL_2")]
        public CiclabileTipoCl1 TipoCL2
        {
            get => tipoCL2;
            set => SetPropertyValue(nameof(TipoCL2), ref tipoCL2, value);
        }

        [ToolTip("Indicazione di ulteriori interventi moderazione e/o limitazione del traffico veicolare")]
        [Persistent("LIM_TR")]
        public CiclabileLimTr LimitazioneTraffico
        {
            get => limitazioneTraffico;
            set => SetPropertyValue(nameof(LimitazioneTraffico), ref limitazioneTraffico, value);
        }

        [Persistent("LARGH_1")]
        public int Larghezza1
        {
            get => larghezza1;
            set => SetPropertyValue(nameof(Larghezza1), ref larghezza1, value);
        }

        [Persistent("LARGH_2")]
        public int Larghezza2
        {
            get => larghezza2;
            set => SetPropertyValue(nameof(Larghezza2), ref larghezza2, value);
        }

        [ToolTip("Indicazione della tipologia di elementi separatori e/o di protezione")]
        [Persistent("SEPAR_1")]
        public CiclabileSepar1 Separatore1
        {
            get => separatore1;
            set => SetPropertyValue(nameof(Separatore1), ref separatore1, value);
        }

        [ToolTip("Indicazione della tipologia di elementi separatori e/o di protezione")]
        [Persistent("SEPAR_2")]
        public CiclabileSepar1 Separatore2
        {
            get => separatore2;
            set => SetPropertyValue(nameof(Separatore2), ref separatore2, value);
        }

        [ToolTip("Indicazione – sintetica – del materiale del fondo")]
        [Persistent("FONDO_1")]
        public CiclabileFondo Fondo1
        {
            get => fondo1;
            set => SetPropertyValue(nameof(Fondo1), ref fondo1, value);
        }

        [ToolTip("Indicazione – sintetica – del materiale del fondo")]
        [Persistent("FONDO_2")]
        public CiclabileFondo Fondo2
        {
            get => fondo2;
            set => SetPropertyValue(nameof(Fondo2), ref fondo2, value);
        }

        [ToolTip("Indicare eventuale presenza di manufatti per il superamento di ostacoli, barriere, intersezioni (attributo del tratto)")]
        [Persistent("INFRASTR")]
        public CiclabileInfrastr Infrastruttura
        {
            get => infrastruttura;
            set => SetPropertyValue(nameof(Infrastruttura), ref infrastruttura, value);
        }

        [ToolTip("Indicare se il singolo tratto si colloca in attraversamento del traffico veicolare in condizioni di sicurezza")]
        [Persistent("ATTRAVER")]
        public bool Attraversamento
        {
            get => attraversamento;
            set => SetPropertyValue(nameof(Attraversamento), ref attraversamento, value);
        }

        [ToolTip("Indicare eventuali soluzioni presenti per l’incremento della sicurezza del traffico ciclistico")]
        [Persistent("DOT_SICUR")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DotazioniSicurezza
        {
            get => dotazioniSicurezza;
            set => SetPropertyValue(nameof(DotazioniSicurezza), ref dotazioniSicurezza, value);
        }

        public CiclabileContesto Contesto
        {
            get => contesto;
            set => SetPropertyValue(nameof(Contesto), ref contesto, value);
        }

        [ToolTip("indicare se il tratto insiste su Argini, alzaie, ecc in ambiti di pertinenza idraulica")]
        public bool Argine
        {
            get => argine;
            set => SetPropertyValue(nameof(Argine), ref argine, value);
        }

        [ToolTip("Pendenza media in %")]
        public int Pendenza
        {
            get => pendenza;
            set => SetPropertyValue(nameof(Pendenza), ref pendenza, value);
        }

        [ToolTip("Indicazione presenza di elementi di riconoscibilità dell’itinerario")]
        [Persistent("SEGNAL_TUR")]
        public CiclabileSegnalTur SegnaliTuristici
        {
            get => segnaliTuristici;
            set => SetPropertyValue(nameof(SegnaliTuristici), ref segnaliTuristici, value);
        }

        [ToolTip("Indicazione presenza di filari di alberature per ombreggiatura nei mesi caldi")]
        public CiclabileAlbertature Alberature
        {
            get => alberature;
            set => SetPropertyValue(nameof(Alberature), ref alberature, value);
        }

        [ToolTip("Indicazione se il tratto in esame gode di illuminazione pubblica")]
        public CiclabileIlluminazione Illuminazione
        {
            get => illuminazione;
            set => SetPropertyValue(nameof(Illuminazione), ref illuminazione, value);
        }

        [ToolTip("indicazione circa la presenza di sistemi di monitoraggio lungo l’itinerario o tratto")]
        [Persistent("MONITOR")]
        public bool Monitoraggio
        {
            get => monitoraggio;
            set => SetPropertyValue(nameof(Monitoraggio), ref monitoraggio, value);
        }

        [ToolTip("indicazione di eventuali link a portale raccolta dati monitoraggio")]
        [Persistent("MONIT_DATI")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LinkMonitoraggio
        {
            get => linkMonitoraggio;
            set => SetPropertyValue(nameof(LinkMonitoraggio), ref linkMonitoraggio, value);
        }

        [ToolTip("eventuali annotazioni su criticità presenti nel tratto")]
        [Persistent("CRITIC_ES")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Criticità
        {
            get => criticità;
            set => SetPropertyValue(nameof(Criticità), ref criticità, value);
        }

        [ToolTip("Indicare se il tratto risolve situazioni di discontinuità della rete esistente")]
        [Persistent("RACC_SPEZZ")]
        public CiclabileRaccordoSpezzate RaccordoSpezzate
        {
            get => raccordoSpezzate;
            set => SetPropertyValue(nameof(RaccordoSpezzate), ref raccordoSpezzate, value);
        }

        [ToolTip("Distinguere se sussiste finanziamento, da parte della RER o da altre fonti")]
        [Persistent("FINANZ")]
        public CiclabileFinanz Finanziamento
        {
            get => finanziamento;
            set => SetPropertyValue(nameof(Finanziamento), ref finanziamento, value);
        }

        [ToolTip("Distinzione del tipo di intervento")]
        [Persistent("TIPO_INT")]
        public CiclabileTipoInt TipoIntervento
        {
            get => tipoIntervento;
            set => SetPropertyValue(nameof(TipoIntervento), ref tipoIntervento, value);
        }

        [ModelDefault("DisplayFormat", "D4")]
        [ModelDefault("EditMask", "D4")]
        [ToolTip("Indicazione dell’anno di realizzazione o dell’ultima modifica")]
        [Persistent("DATA_R_INT")]
        public int Anno
        {
            get => anno;
            set => SetPropertyValue(nameof(Anno), ref anno, value);
        }

        [ToolTip("Breve descrizione dell’intervento realizzato o in progetto")]
        [Persistent("DES_INT")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string DescrizioneIntervento
        {
            get => descrizioneIntervento;
            set => SetPropertyValue(nameof(DescrizioneIntervento), ref descrizioneIntervento, value);
        }

        [ToolTip("Indicazione della fonte del finanziamento, se il dato è pertinente")]
        [Persistent("FIN_FONTE")]
        public string FonteFinanziamento
        {
            get => fonteFinanziamento;
            set => SetPropertyValue(nameof(FonteFinanziamento), ref fonteFinanziamento, value);
        }

        [ToolTip("codice identificativo all’interno di una stessa linea di finanziamento")]
        [Persistent("ID_FIN_FON")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string IDFinFonte
        {
            get => iDFinFonte;
            set => SetPropertyValue(nameof(IDFinFonte), ref iDFinFonte, value);
        }

        [ToolTip("Indicazione del finanziamento in euro")]
        [Persistent("FIN_EURO")]
        public decimal ImportoFinanziamento
        {
            get => importoFinanziamento;
            set => SetPropertyValue(nameof(ImportoFinanziamento), ref importoFinanziamento, value);
        }


        [ToolTip("Data di compilazione del dato")]
        [Persistent("DATA_COMP")]
        public DateTime DataCompilazione
        {
            get => dataCompilazione;
            set => SetPropertyValue(nameof(DataCompilazione), ref dataCompilazione, value);
        }

        [ToolTip("Indicazione della fonte da cui è stato tratto il dato")]
        [Persistent("FONTE")]
        public string FonteCompilazione
        {
            get => fonteCompilazione;
            set => SetPropertyValue(nameof(FonteCompilazione), ref fonteCompilazione, value);
        }

        [ToolTip("Indicazione dell’accuratezza del tracciato riportato in cartografia")]
        public string Dettaglio
        {
            get => dettaglio;
            set => SetPropertyValue(nameof(Dettaglio), ref dettaglio, value);
        }

        [ToolTip("DENOMINAZIONE/I FILES IMMAGINI")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Immagini
        {
            get => immagini;
            set => SetPropertyValue(nameof(Immagini), ref immagini, value);
        }

        [ToolTip("Eventuali annotazioni del compilatore")]
        public string Note
        {
            get => note;
            set => SetPropertyValue(nameof(Note), ref note, value);
        }



    }
}
