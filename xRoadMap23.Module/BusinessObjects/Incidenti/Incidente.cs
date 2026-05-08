using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Model;
using System;

namespace xRoadMap.Module.BusinessObjects.Incidenti
{
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [Persistent("INCIDENTI")]
    [NavigationItem("Incidenti stradali")]
    public class Incidente : EventoPuntuale, IEventoOnRoad
    {
        public Incidente(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        #region 1. IDENTIFICAZIONE INCIDENTE (Campi 1-10)

        private int annoIncidente;
        [Persistent("ANNO")]
        [Size(2)]
        public int AnnoIncidente
        {
            get => annoIncidente;
            set => SetPropertyValue(nameof(AnnoIncidente), ref annoIncidente, value);
        }

        private int meseIncidente;
        [Persistent("MESE")]
        public int MeseIncidente
        {
            get => meseIncidente;
            set => SetPropertyValue(nameof(MeseIncidente), ref meseIncidente, value);
        }

        private string codiceProvincia;
        [Persistent("PROVIN")]
        [Size(3)]
        public string CodiceProvincia
        {
            get => codiceProvincia;
            set => SetPropertyValue(nameof(CodiceProvincia), ref codiceProvincia, value);
        }

        private string codiceComune;
        [Persistent("COMUNE")]
        [Size(3)]
        public string CodiceComune
        {
            get => codiceComune;
            set => SetPropertyValue(nameof(CodiceComune), ref codiceComune, value);
        }

        private int numeroOrdine;
        [Persistent("NUMORD")]
        public int NumeroOrdine
        {
            get => numeroOrdine;
            set => SetPropertyValue(nameof(NumeroOrdine), ref numeroOrdine, value);
        }

        private int giornoIncidente;
        [Persistent("GIORINC")]
        public int GiornoIncidente
        {
            get => giornoIncidente;
            set => SetPropertyValue(nameof(GiornoIncidente), ref giornoIncidente, value);
        }

        private int oraIncidente;
        [Persistent("Ora")]
        public int OraIncidente
        {
            get => oraIncidente;
            set => SetPropertyValue(nameof(OraIncidente), ref oraIncidente, value);
        }

        private int minutiIncidente;
        [Persistent("Min")]
        public int MinutiIncidente
        {
            get => minutiIncidente;
            set => SetPropertyValue(nameof(MinutiIncidente), ref minutiIncidente, value);
        }

        private TipoOrganoRilevazione organoRilevazione;
        [Persistent("ORGRIL")]
        public TipoOrganoRilevazione OrganoRilevazione
        {
            get => organoRilevazione;
            set => SetPropertyValue(nameof(OrganoRilevazione), ref organoRilevazione, value);
        }

        private TipoOrganoCoordinatore organoCoordinatore;
        [Persistent("ORGANC")]
        public TipoOrganoCoordinatore OrganoCoordinatore
        {
            get => organoCoordinatore;
            set => SetPropertyValue(nameof(OrganoCoordinatore), ref organoCoordinatore, value);
        }

        #endregion

        #region 2. LOCALIZZAZIONE INCIDENTE (Campi 11-14)

        private TipoLocalizzazione localizzazioneIncidente;
        [Persistent("ABITAT")]
        public TipoLocalizzazione LocalizzazioneIncidente
        {
            get => localizzazioneIncidente;
            set => SetPropertyValue(nameof(LocalizzazioneIncidente), ref localizzazioneIncidente, value);
        }

        private string denominazioneStrada;
        [Persistent("DENOMIN")]
        [Size(3)]
        public string DenominazioneStrada
        {
            get => denominazioneStrada;
            set => SetPropertyValue(nameof(DenominazioneStrada), ref denominazioneStrada, value);
        }

        private int ettometrica;
        [Persistent("Hm")]
        public int Ettometrica
        {
            get => ettometrica;
            set => SetPropertyValue(nameof(Ettometrica), ref ettometrica, value);
        }

        private TipoTronco troncoStrada;
        [Persistent("TRONCO")]
        public TipoTronco TroncoStrada
        {
            get => troncoStrada;
            set => SetPropertyValue(nameof(TroncoStrada), ref troncoStrada, value);
        }

        private string nomeStrada;
        [Persistent("STRADA")]
        [Size(200)]
        public string NomeStrada
        {
            get => nomeStrada;
            set => SetPropertyValue(nameof(NomeStrada), ref nomeStrada, value);
        }

        #endregion

        #region 3. CARATTERISTICHE LUOGO (Campi 15-21)

        private TipoStrada tipoStrada;
        [Persistent("TIPOSTR")]
        public TipoStrada TipoStrada
        {
            get => tipoStrada;
            set => SetPropertyValue(nameof(TipoStrada), ref tipoStrada, value);
        }

        private TipoPavimentazione pavimentazione;
        [Persistent("TIPOPAV")]
        public TipoPavimentazione Pavimentazione
        {
            get => pavimentazione;
            set => SetPropertyValue(nameof(Pavimentazione), ref pavimentazione, value);
        }

        private TipoIntersezione intersezione;
        [Persistent("INTERS")]
        public TipoIntersezione Intersezione
        {
            get => intersezione;
            set => SetPropertyValue(nameof(Intersezione), ref intersezione, value);
        }

        private TipoFondoStradale fondoStradale;
        [Persistent("FONDSTR")]
        public TipoFondoStradale FondoStradale
        {
            get => fondoStradale;
            set => SetPropertyValue(nameof(FondoStradale), ref fondoStradale, value);
        }

        private TipoSegnaletica segnaletica;
        [Persistent("SEGNALE")]
        public TipoSegnaletica Segnaletica
        {
            get => segnaletica;
            set => SetPropertyValue(nameof(Segnaletica), ref segnaletica, value);
        }

        private TipoMeteo condizioniMeteorologiche;
        [Persistent("METEO")]
        public TipoMeteo CondizioniMeteorologiche
        {
            get => condizioniMeteorologiche;
            set => SetPropertyValue(nameof(CondizioniMeteorologiche), ref condizioniMeteorologiche, value);
        }

        #endregion

        #region 4. NATURA INCIDENTE (Campo 22)

        private TipoNaturaIncidente naturaIncidente;
        [Persistent("NATURA")]
        public TipoNaturaIncidente NaturaIncidente
        {
            get => naturaIncidente;
            set => SetPropertyValue(nameof(NaturaIncidente), ref naturaIncidente, value);
        }

        #endregion

        #region 5. VEICOLI COINVOLTI (Campi 23-51)

        // Veicolo A
        private TipoVeicolo tipoVeicoloA;
        [Persistent("AVEICol")]
        public TipoVeicolo TipoVeicoloA
        {
            get => tipoVeicoloA;
            set => SetPropertyValue(nameof(TipoVeicoloA), ref tipoVeicoloA, value);
        }

        private int cilindrataVeicoloA;
        [Persistent("CilA")]
        public int CilindrataVeicoloA
        {
            get => cilindrataVeicoloA;
            set => SetPropertyValue(nameof(CilindrataVeicoloA), ref cilindrataVeicoloA, value);
        }

        private int pesoVeicoloA;
        [Persistent("APESO")]
        public int PesoVeicoloA
        {
            get => pesoVeicoloA;
            set => SetPropertyValue(nameof(PesoVeicoloA), ref pesoVeicoloA, value);
        }

        private string targaVeicoloA;
        [Persistent("ATARG")]
        [Size(8)]
        public string TargaVeicoloA
        {
            get => targaVeicoloA;
            set => SetPropertyValue(nameof(TargaVeicoloA), ref targaVeicoloA, value);
        }

        private string siglaVeicoloA;
        [Persistent("AESTERO")]
        [Size(3)]
        public string SiglaVeicoloA
        {
            get => siglaVeicoloA;
            set => SetPropertyValue(nameof(SiglaVeicoloA), ref siglaVeicoloA, value);
        }

        private int annoImmatricolazioneVeicoloA;
        [Persistent("AIMMAT")]
        public int AnnoImmatricolazioneVeicoloA
        {
            get => annoImmatricolazioneVeicoloA;
            set => SetPropertyValue(nameof(AnnoImmatricolazioneVeicoloA), ref annoImmatricolazioneVeicoloA, value);
        }

        private int annoRevisioneVeicoloA;
        [Persistent("AREVISA")]
        public int AnnoRevisioneVeicoloA
        {
            get => annoRevisioneVeicoloA;
            set => SetPropertyValue(nameof(AnnoRevisioneVeicoloA), ref annoRevisioneVeicoloA, value);
        }

        private int chilometriVeicoloA;
        [Persistent("AKM")]
        public int ChilometriVeicoloA
        {
            get => chilometriVeicoloA;
            set => SetPropertyValue(nameof(ChilometriVeicoloA), ref chilometriVeicoloA, value);
        }

        // Veicolo B
        private TipoVeicolo tipoVeicoloB;
        [Persistent("BVEICol")]
        public TipoVeicolo TipoVeicoloB
        {
            get => tipoVeicoloB;
            set => SetPropertyValue(nameof(TipoVeicoloB), ref tipoVeicoloB, value);
        }

        private int cilindrataVeicoloB;
        [Persistent("CilB")]
        public int CilindrataVeicoloB
        {
            get => cilindrataVeicoloB;
            set => SetPropertyValue(nameof(CilindrataVeicoloB), ref cilindrataVeicoloB, value);
        }

        private int pesoVeicoloB;
        [Persistent("BPESO")]
        public int PesoVeicoloB
        {
            get => pesoVeicoloB;
            set => SetPropertyValue(nameof(PesoVeicoloB), ref pesoVeicoloB, value);
        }

        private string targaVeicoloB;
        [Persistent("BTARGA")]
        [Size(8)]
        public string TargaVeicoloB
        {
            get => targaVeicoloB;
            set => SetPropertyValue(nameof(TargaVeicoloB), ref targaVeicoloB, value);
        }

        private string siglaVeicoloB;
        [Persistent("BESTERO")]
        [Size(3)]
        public string SiglaVeicoloB
        {
            get => siglaVeicoloB;
            set => SetPropertyValue(nameof(SiglaVeicoloB), ref siglaVeicoloB, value);
        }

        private int annoImmatricolazioneVeicoloB;
        [Persistent("BIMMAT")]
        public int AnnoImmatricolazioneVeicoloB
        {
            get => annoImmatricolazioneVeicoloB;
            set => SetPropertyValue(nameof(AnnoImmatricolazioneVeicoloB), ref annoImmatricolazioneVeicoloB, value);
        }

        private int annoRevisioneVeicoloB;
        [Persistent("BREVIS")]
        public int AnnoRevisioneVeicoloB
        {
            get => annoRevisioneVeicoloB;
            set => SetPropertyValue(nameof(AnnoRevisioneVeicoloB), ref annoRevisioneVeicoloB, value);
        }

        private int chilometriVeicoloB;
        [Persistent("BKM")]
        public int ChilometriVeicoloB
        {
            get => chilometriVeicoloB;
            set => SetPropertyValue(nameof(ChilometriVeicoloB), ref chilometriVeicoloB, value);
        }

        // Veicolo C
        private TipoVeicolo tipoVeicoloC;
        [Persistent("CVEICol")]
        public TipoVeicolo TipoVeicoloC
        {
            get => tipoVeicoloC;
            set => SetPropertyValue(nameof(TipoVeicoloC), ref tipoVeicoloC, value);
        }

        private int cilindrataVeicoloC;
        [Persistent("CilC")]
        public int CilindrataVeicoloC
        {
            get => cilindrataVeicoloC;
            set => SetPropertyValue(nameof(CilindrataVeicoloC), ref cilindrataVeicoloC, value);
        }

        private int pesoVeicoloC;
        [Persistent("CPESO")]
        public int PesoVeicoloC
        {
            get => pesoVeicoloC;
            set => SetPropertyValue(nameof(PesoVeicoloC), ref pesoVeicoloC, value);
        }

        private string targaVeicoloC;
        [Persistent("CTARGA")]
        [Size(8)]
        public string TargaVeicoloC
        {
            get => targaVeicoloC;
            set => SetPropertyValue(nameof(TargaVeicoloC), ref targaVeicoloC, value);
        }

        private string siglaVeicoloC;
        [Persistent("CESTERO")]
        [Size(3)]
        public string SiglaVeicoloC
        {
            get => siglaVeicoloC;
            set => SetPropertyValue(nameof(SiglaVeicoloC), ref siglaVeicoloC, value);
        }

        private int annoImmatricolazioneVeicoloC;
        [Persistent("CIMMAT")]
        public int AnnoImmatricolazioneVeicoloC
        {
            get => annoImmatricolazioneVeicoloC;
            set => SetPropertyValue(nameof(AnnoImmatricolazioneVeicoloC), ref annoImmatricolazioneVeicoloC, value);
        }

        private int annoRevisioneVeicoloC;
        [Persistent("CREVIS")]
        public int AnnoRevisioneVeicoloC
        {
            get => annoRevisioneVeicoloC;
            set => SetPropertyValue(nameof(AnnoRevisioneVeicoloC), ref annoRevisioneVeicoloC, value);
        }

        private int chilometriVeicoloC;
        [Persistent("CKM")]
        public int ChilometriVeicoloC
        {
            get => chilometriVeicoloC;
            set => SetPropertyValue(nameof(ChilometriVeicoloC), ref chilometriVeicoloC, value);
        }

        #endregion

        #region 6. CIRCOSTANZE (Campi 33-36)

        private TipoCircostanza circostanzaVeicoloA;
        [Persistent("ACIRCol")]
        public TipoCircostanza CircostanzaVeicoloA
        {
            get => circostanzaVeicoloA;
            set => SetPropertyValue(nameof(CircostanzaVeicoloA), ref circostanzaVeicoloA, value);
        }

        private TipoCircostanza circostanzaDifettiVeicoloA;
        [Persistent("ADIFET")]
        public TipoCircostanza CircostanzaDifettiVeicoloA
        {
            get => circostanzaDifettiVeicoloA;
            set => SetPropertyValue(nameof(CircostanzaDifettiVeicoloA), ref circostanzaDifettiVeicoloA, value);
        }

        private TipoCircostanza circostanzaConducenteA;
        [Persistent("APSICO")]
        public TipoCircostanza CircostanzaConducenteA
        {
            get => circostanzaConducenteA;
            set => SetPropertyValue(nameof(CircostanzaConducenteA), ref circostanzaConducenteA, value);
        }

        private TipoCircostanza circostanzaVeicoloB;
        [Persistent("BCIRCol")]
        public TipoCircostanza CircostanzaVeicoloB
        {
            get => circostanzaVeicoloB;
            set => SetPropertyValue(nameof(CircostanzaVeicoloB), ref circostanzaVeicoloB, value);
        }

        private TipoCircostanza circostanzaDifettiVeicoloB;
        [Persistent("BDIFET")]
        public TipoCircostanza CircostanzaDifettiVeicoloB
        {
            get => circostanzaDifettiVeicoloB;
            set => SetPropertyValue(nameof(CircostanzaDifettiVeicoloB), ref circostanzaDifettiVeicoloB, value);
        }

        private TipoCircostanza circostanzaConducenteB;
        [Persistent("BPSICO")]
        public TipoCircostanza CircostanzaConducenteB
        {
            get => circostanzaConducenteB;
            set => SetPropertyValue(nameof(CircostanzaConducenteB), ref circostanzaConducenteB, value);
        }

        #endregion

        #region 7. CONSEGUENZE PERSONE - CONDUCENTE VEICOLO A (Campi 52-60)

        private int etaConducenteA;
        [Persistent("AETA")]
        public int EtaConducenteA
        {
            get => etaConducenteA;
            set => SetPropertyValue(nameof(EtaConducenteA), ref etaConducenteA, value);
        }

        private int sessoConducenteA;
        [Persistent("ASEX")]
        public int SessoConducenteA
        {
            get => sessoConducenteA;
            set => SetPropertyValue(nameof(SessoConducenteA), ref sessoConducenteA, value);
        }

        private TipoEsito esitoConducenteA;
        [Persistent("AESIT")]
        public TipoEsito EsitoConducenteA
        {
            get => esitoConducenteA;
            set => SetPropertyValue(nameof(EsitoConducenteA), ref esitoConducenteA, value);
        }

        private TipoPatente tipoPatenteConducenteA;
        [Persistent("APATEN")]
        public TipoPatente TipoPatenteConducenteA
        {
            get => tipoPatenteConducenteA;
            set => SetPropertyValue(nameof(TipoPatenteConducenteA), ref tipoPatenteConducenteA, value);
        }

        private int annoRilascioPatenteA;
        [Persistent("ARILAS")]
        public int AnnoRilascioPatenteA
        {
            get => annoRilascioPatenteA;
            set => SetPropertyValue(nameof(AnnoRilascioPatenteA), ref annoRilascioPatenteA, value);
        }

        private int conducenteProfessionaleA;
        [Persistent("APROFESS")]
        public int ConducenteProfessionaleA
        {
            get => conducenteProfessionaleA;
            set => SetPropertyValue(nameof(ConducenteProfessionaleA), ref conducenteProfessionaleA, value);
        }

        private int obbligoCascoCinturaA;
        [Persistent("AOBBLIG")]
        public int ObbligoCascoCinturaA
        {
            get => obbligoCascoCinturaA;
            set => SetPropertyValue(nameof(ObbligoCascoCinturaA), ref obbligoCascoCinturaA, value);
        }

        private int infoCascoCinturaConducenteA;
        [Persistent("ACINTC")]
        public int InfoCascoCinturaConducenteA
        {
            get => infoCascoCinturaConducenteA;
            set => SetPropertyValue(nameof(InfoCascoCinturaConducenteA), ref infoCascoCinturaConducenteA, value);
        }

        private int infoCascoCinturaPasseggeroA;
        [Persistent("ACINTP")]
        public int InfoCascoCinturaPasseggeroA
        {
            get => infoCascoCinturaPasseggeroA;
            set => SetPropertyValue(nameof(InfoCascoCinturaPasseggeroA), ref infoCascoCinturaPasseggeroA, value);
        }

        #endregion

        #region 8. PASSEGGERI E PEDONI (Campi 61-147)

        private int numeroPasseggeriMortiMaschiA;
        [Persistent("AAPMM")]
        public int NumeroPasseggeriMortiMaschiA
        {
            get => numeroPasseggeriMortiMaschiA;
            set => SetPropertyValue(nameof(NumeroPasseggeriMortiMaschiA), ref numeroPasseggeriMortiMaschiA, value);
        }

        private int numeroPasseggeriMortiFemmineA;
        [Persistent("AAPFM")]
        public int NumeroPasseggeriMortiFemmineA
        {
            get => numeroPasseggeriMortiFemmineA;
            set => SetPropertyValue(nameof(NumeroPasseggeriMortiFemmineA), ref numeroPasseggeriMortiFemmineA, value);
        }

        private int numeroPasseggeriFeritiMaschiA;
        [Persistent("AAPMF")]
        public int NumeroPasseggeriFeritiMaschiA
        {
            get => numeroPasseggeriFeritiMaschiA;
            set => SetPropertyValue(nameof(NumeroPasseggeriFeritiMaschiA), ref numeroPasseggeriFeritiMaschiA, value);
        }

        private int numeroPasseggeriFeritiSFemmineA;
        [Persistent("AAPFF")]
        public int NumeroPasseggeriFeritiSFemmineA
        {
            get => numeroPasseggeriFeritiSFemmineA;
            set => SetPropertyValue(nameof(NumeroPasseggeriFeritiSFemmineA), ref numeroPasseggeriFeritiSFemmineA, value);
        }

        // Conducente Veicolo B
        private int etaConducenteB;
        [Persistent("BETA")]
        public int EtaConducenteB
        {
            get => etaConducenteB;
            set => SetPropertyValue(nameof(EtaConducenteB), ref etaConducenteB, value);
        }

        private int sessoConducenteB;
        [Persistent("BSEX")]
        public int SessoConducenteB
        {
            get => sessoConducenteB;
            set => SetPropertyValue(nameof(SessoConducenteB), ref sessoConducenteB, value);
        }

        private TipoEsito esitoConducenteB;
        [Persistent("BESIT")]
        public TipoEsito EsitoConducenteB
        {
            get => esitoConducenteB;
            set => SetPropertyValue(nameof(EsitoConducenteB), ref esitoConducenteB, value);
        }

        private TipoPatente tipoPatenteConducenteB;
        [Persistent("BPATEN")]
        public TipoPatente TipoPatenteConducenteB
        {
            get => tipoPatenteConducenteB;
            set => SetPropertyValue(nameof(TipoPatenteConducenteB), ref tipoPatenteConducenteB, value);
        }

        private int annoRilascioPatenteB;
        [Persistent("BRILAS")]
        public int AnnoRilascioPatenteB
        {
            get => annoRilascioPatenteB;
            set => SetPropertyValue(nameof(AnnoRilascioPatenteB), ref annoRilascioPatenteB, value);
        }

        private int conducenteProfessionaleB;
        [Persistent("BPROFESS")]
        public int ConducenteProfessionaleB
        {
            get => conducenteProfessionaleB;
            set => SetPropertyValue(nameof(ConducenteProfessionaleB), ref conducenteProfessionaleB, value);
        }

        // Passeggeri Veicolo B
        private int numeroPasseggeriMortiMaschiB;
        [Persistent("BAPMM")]
        public int NumeroPasseggeriMortiMaschiB
        {
            get => numeroPasseggeriMortiMaschiB;
            set => SetPropertyValue(nameof(NumeroPasseggeriMortiMaschiB), ref numeroPasseggeriMortiMaschiB, value);
        }

        private int numeroPasseggeriMortiFemmineB;
        [Persistent("BAPFM")]
        public int NumeroPasseggeriMortiFemmineB
        {
            get => numeroPasseggeriMortiFemmineB;
            set => SetPropertyValue(nameof(NumeroPasseggeriMortiFemmineB), ref numeroPasseggeriMortiFemmineB, value);
        }

        private int numeroPasseggeriFeritiMaschiB;
        [Persistent("BAPMF")]
        public int NumeroPasseggeriFeritiMaschiB
        {
            get => numeroPasseggeriFeritiMaschiB;
            set => SetPropertyValue(nameof(NumeroPasseggeriFeritiMaschiB), ref numeroPasseggeriFeritiMaschiB, value);
        }

        private int numeroPasseggeriFeritiSFemmineB;
        [Persistent("BAPFF")]
        public int NumeroPasseggeriFeritiSFemmineB
        {
            get => numeroPasseggeriFeritiSFemmineB;
            set => SetPropertyValue(nameof(NumeroPasseggeriFeritiSFemmineB), ref numeroPasseggeriFeritiSFemmineB, value);
        }

        // Conducente Veicolo C
        private int etaConducenteC;
        [Persistent("CETA")]
        public int EtaConducenteC
        {
            get => etaConducenteC;
            set => SetPropertyValue(nameof(EtaConducenteC), ref etaConducenteC, value);
        }

        private int sessoConducenteC;
        [Persistent("CSEX")]
        public int SessoConducenteC
        {
            get => sessoConducenteC;
            set => SetPropertyValue(nameof(SessoConducenteC), ref sessoConducenteC, value);
        }

        private TipoEsito esitoConducenteC;
        [Persistent("CESIT")]
        public TipoEsito EsitoConducenteC
        {
            get => esitoConducenteC;
            set => SetPropertyValue(nameof(EsitoConducenteC), ref esitoConducenteC, value);
        }

        private TipoPatente tipoPatenteConducenteC;
        [Persistent("CPATEN")]
        public TipoPatente TipoPatenteConducenteC
        {
            get => tipoPatenteConducenteC;
            set => SetPropertyValue(nameof(TipoPatenteConducenteC), ref tipoPatenteConducenteC, value);
        }

        private int annoRilascioPatenteC;
        [Persistent("CRILAS")]
        public int AnnoRilascioPatenteC
        {
            get => annoRilascioPatenteC;
            set => SetPropertyValue(nameof(AnnoRilascioPatenteC), ref annoRilascioPatenteC, value);
        }

        private int conducenteProfessionaleC;
        [Persistent("CPROFESS")]
        public int ConducenteProfessionaleC
        {
            get => conducenteProfessionaleC;
            set => SetPropertyValue(nameof(ConducenteProfessionaleC), ref conducenteProfessionaleC, value);
        }

        // Passeggeri Veicolo C
        private int numeroPasseggeriMortiMaschiC;
        [Persistent("CAPMM")]
        public int NumeroPasseggeriMortiMaschiC
        {
            get => numeroPasseggeriMortiMaschiC;
            set => SetPropertyValue(nameof(NumeroPasseggeriMortiMaschiC), ref numeroPasseggeriMortiMaschiC, value);
        }

        private int numeroPasseggeriMortiFemmineC;
        [Persistent("CAPFM")]
        public int NumeroPasseggeriMortiFemmineC
        {
            get => numeroPasseggeriMortiFemmineC;
            set => SetPropertyValue(nameof(NumeroPasseggeriMortiFemmineC), ref numeroPasseggeriMortiFemmineC, value);
        }

        private int numeroPasseggeriFeritiMaschiC;
        [Persistent("CAPMF")]
        public int NumeroPasseggeriFeritiMaschiC
        {
            get => numeroPasseggeriFeritiMaschiC;
            set => SetPropertyValue(nameof(NumeroPasseggeriFeritiMaschiC), ref numeroPasseggeriFeritiMaschiC, value);
        }

        private int numeroPasseggeriFeritiSFemmineC;
        [Persistent("CAPFF")]
        public int NumeroPasseggeriFeritiSFemmineC
        {
            get => numeroPasseggeriFeritiSFemmineC;
            set => SetPropertyValue(nameof(NumeroPasseggeriFeritiSFemmineC), ref numeroPasseggeriFeritiSFemmineC, value);
        }

        #endregion

        #region 9. ALTRI VEICOLI E RIEPILOGO (Campi 143-150)

        private int numeroAltriVeicoliCoinvolti;
        [Persistent("ALTRVEIC")]
        public int NumeroAltriVeicoliCoinvolti
        {
            get => numeroAltriVeicoliCoinvolti;
            set => SetPropertyValue(nameof(NumeroAltriVeicoliCoinvolti), ref numeroAltriVeicoliCoinvolti, value);
        }

        private int numeroAltriMortiMaschi;
        [Persistent("COINVMOM")]
        public int NumeroAltriMortiMaschi
        {
            get => numeroAltriMortiMaschi;
            set => SetPropertyValue(nameof(NumeroAltriMortiMaschi), ref numeroAltriMortiMaschi, value);
        }

        private int numeroAltriMortiFemmine;
        [Persistent("COINVMOF")]
        public int NumeroAltriMortiFemmine
        {
            get => numeroAltriMortiFemmine;
            set => SetPropertyValue(nameof(NumeroAltriMortiFemmine), ref numeroAltriMortiFemmine, value);
        }

        private int numeroAltriFeritiMaschi;
        [Persistent("COINVFEM")]
        public int NumeroAltriFeritiMaschi
        {
            get => numeroAltriFeritiMaschi;
            set => SetPropertyValue(nameof(NumeroAltriFeritiMaschi), ref numeroAltriFeritiMaschi, value);
        }

        private int numeroAltriFeritiSFemmine;
        [Persistent("COINVFEF")]
        public int NumeroAltriFeritiSFemmine
        {
            get => numeroAltriFeritiSFemmine;
            set => SetPropertyValue(nameof(NumeroAltriFeritiSFemmine), ref numeroAltriFeritiSFemmine, value);
        }

        private int totaleMortiPrime24Ore;
        [Persistent("MORTI24")]
        public int TotaleMortiPrime24Ore
        {
            get => totaleMortiPrime24Ore;
            set => SetPropertyValue(nameof(TotaleMortiPrime24Ore), ref totaleMortiPrime24Ore, value);
        }

        private int totaleMortiEntro30Giorni;
        [Persistent("MORTI7")]
        public int TotaleMortiEntro30Giorni
        {
            get => totaleMortiEntro30Giorni;
            set => SetPropertyValue(nameof(TotaleMortiEntro30Giorni), ref totaleMortiEntro30Giorni, value);
        }

        private int totaleReriti;
        [Persistent("FERITI")]
        public int TotaleReriti
        {
            get => totaleReriti;
            set => SetPropertyValue(nameof(TotaleReriti), ref totaleReriti, value);
        }

        #endregion

        #region 11. IDENTIFICATIVI (Campi aggiuntivi)

        private string codiceIdentificativoEnte;
        [Persistent("CodEnte")]
        [Size(40)]
        public string CodiceIdentificativoEnte
        {
            get => codiceIdentificativoEnte;
            set => SetPropertyValue(nameof(CodiceIdentificativoEnte), ref codiceIdentificativoEnte, value);
        }

        private string codiceIdentificativoCarabinieri;
        [Persistent("CodiceCC")]
        [Size(30)]
        public string CodiceIdentificativoCarabinieri
        {
            get => codiceIdentificativoCarabinieri;
            set => SetPropertyValue(nameof(CodiceIdentificativoCarabinieri), ref codiceIdentificativoCarabinieri, value);
        }

        #endregion
    }



}
