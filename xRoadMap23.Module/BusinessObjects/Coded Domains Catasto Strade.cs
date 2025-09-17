using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using RTools_NTS.Util;
using DevExpress.Persistent.Base;

namespace xRoadMap.Module.BusinessObjects
{
    [Persistent("aree_traffico_tipologia")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoAreaTraffico : CodedDomain<double>
    {
        public TipoAreaTraffico(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("banchine_tipo_pav")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoPavimentazione: CodedDomain<double>
    {
        public TipoPavimentazione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("banchine_tipo_superficie")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoSuperficie : CodedDomain<double>
    {
        public TipoSuperficie(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("ciclabile_senso_percorrenza")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class SensoPercorrenza: CodedDomain<double>
    {
        public SensoPercorrenza(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("ciclabile_tipo")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoCliclabile : CodedDomain<double>
    {
        public TipoCliclabile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("cippi_materiale")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoMaterialeCippo : CodedDomain<double>
    {
        public TipoMaterialeCippo(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("classe_orografia")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoOrografia : CodedDomain<double>
    {
        public TipoOrografia(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("classe_tortuosita")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoTortuosita : CodedDomain<double>
    {
        public TipoTortuosita(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("corpo_stradale_delimitazione")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoDelimitazione : CodedDomain<double>
    {
        public TipoDelimitazione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("corpo_stradale_tipologia")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipologiaCorpoStradale : CodedDomain<double>
    {
        public TipologiaCorpoStradale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("cunette_materiale")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoMaterialeCunetta : CodedDomain<double>
    {
        public TipoMaterialeCunetta(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("cunette_tipologia")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TiplogiaCunetta : CodedDomain<double>
    {
        public TiplogiaCunetta(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("dati_patrimoniali")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoPatrimonio : CodedDomain<string>
    {
        public TipoPatrimonio(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("destinazione_accessi")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoDestinazioneAccesso : CodedDomain<double>
    {
        public TipoDestinazioneAccesso(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("passaggi_a_livello_tipo")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoPassaggioLivello : CodedDomain<double>
    {
        public TipoPassaggioLivello(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("destinazione_area")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoDestinazioneArea : CodedDomain<double>
    {
        public TipoDestinazioneArea(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("vegetazione_tipologia")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoVegetazione : CodedDomain<double>
    {
        public TipoVegetazione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("vegetazione_funzione")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class FunzioneVegetazione : CodedDomain<double>
    {
        public FunzioneVegetazione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }



    [Persistent("disp_ritenuta_classif")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class ClassificazioneDispositivoRitenuta : CodedDomain<string>
    {
        public ClassificazioneDispositivoRitenuta(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("disp_ritenuta_materiale")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoMaterialeDispositivoRitenuta : CodedDomain<double>
    {
        public TipoMaterialeDispositivoRitenuta(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("disp_ritenuta_tipo")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoDispositivoRitenuta : CodedDomain<double>
    {
        public TipoDispositivoRitenuta(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("frane_attivita")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoAttivitàFrana : CodedDomain<double>
    {
        public TipoAttivitàFrana(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("frane_stato")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class StatoFrana : CodedDomain<double>
    {
        public StatoFrana(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("frane_tipo_movimento")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoMovimentoFrana : CodedDomain<double>
    {
        public TipoMovimentoFrana(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("gallerie_impianti_vent")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoImpiantoVentilazione : CodedDomain<double>
    {
        public TipoImpiantoVentilazione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }



    [Persistent("gallerie_tipo_opera")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoOperaGalleria : CodedDomain<string>
    {
        public TipoOperaGalleria(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("giunzioni_regolazione")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoRegolazioneGiunzione : CodedDomain<double>
    {
        public TipoRegolazioneGiunzione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("giunzioni_tipologia")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipologiaGiunzione : CodedDomain<double>
    {
        public TipologiaGiunzione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("grado_sismicita")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoSismicità : CodedDomain<double>
    {
        public TipoSismicità(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("illuminazione_disp_lampade")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoDisposizioneLampade : CodedDomain<double>
    {
        public TipoDisposizioneLampade(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("illuminazione_tipologia")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoIlluminazione : CodedDomain<double>
    {
        public TipoIlluminazione(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("opera_sost_tipologia")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoOperaSostegno : CodedDomain<double>
    {
        public TipoOperaSostegno(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("opera_sost_tipologia_costr")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipologiaCostruttivaOperaSostegno : CodedDomain<string>
    {
        public TipologiaCostruttivaOperaSostegno(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("sovr_sott_tipo_opera")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoSottopasso : CodedDomain<string>
    {
        public TipoSottopasso(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("ciclabile_tipo")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipoCiclabile : CodedDomain<double>
    {
        public TipoCiclabile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }


    [Persistent("ciclabile_senso_percorrenza")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class SensoCiclabile : CodedDomain<double>
    {
        public SensoCiclabile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    #region Ciclabili Emilia-Romagna

    [Persistent("ciclabili_stato_agg")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileStatoAgg : CodedDomain<short>
    {
        public CiclabileStatoAgg(Session session) : base(session) { }
    }

    [Persistent("ciclabili_r_eurov")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileEurov : CodedDomain<string>
    {
        public CiclabileEurov(Session session) : base(session) { }
    }


    [Persistent("ciclabili_bicitalia")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileBicitalia : CodedDomain<string>
    {
        public CiclabileBicitalia(Session session) : base(session) { }
    }

    [Persistent("ciclabili_snct")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileSnct : CodedDomain<string>
    {
        public CiclabileSnct(Session session) : base(session) { }
    }

    [Persistent("ciclabili_r_rcr")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileRcr : CodedDomain<string>
    {
        public CiclabileRcr(Session session) : base(session) { }
    }

    [Persistent("ciclabili_contesto")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileContesto : CodedDomain<short>
    {
        public CiclabileContesto(Session session) : base(session) { }
    }

    [Persistent("ciclabili_vocazione")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileVocazione : CodedDomain<short>
    {
        public CiclabileVocazione(Session session) : base(session) { }
    }

    [Persistent("ciclabili_class_plan")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileClassPlan : CodedDomain<short>
    {
        public CiclabileClassPlan(Session session) : base(session) { }
    }


    [Persistent("ciclabili_tipo_cl_1")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileTipoCl1 : CodedDomain<short>
    {
        public CiclabileTipoCl1(Session session) : base(session) { }
    }

    [Persistent("ciclabili_lim_tr")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileLimTr : CodedDomain<short>
    {
        public CiclabileLimTr(Session session) : base(session) { }
    }

    [Persistent("ciclabili_sen_marcia")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileSensoMarcia : CodedDomain<short>
    {
        public CiclabileSensoMarcia(Session session) : base(session) { }
    }

    [Persistent("ciclabili_separ_1")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileSepar1 : CodedDomain<short>
    {
        public CiclabileSepar1(Session session) : base(session) { }
    }

    [Persistent("ciclabili_fondo")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileFondo : CodedDomain<short>
    {
        public CiclabileFondo(Session session) : base(session) { }
    }

    [Persistent("ciclabili_infrastr")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileInfrastr : CodedDomain<short>
    {
        public CiclabileInfrastr(Session session) : base(session) { }
    }

    [Persistent("ciclabili_segnal_tur")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileSegnalTur : CodedDomain<short>
    {
        public CiclabileSegnalTur(Session session) : base(session) { }
    }

    [Persistent("ciclabili_alberature")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileAlbertature : CodedDomain<short>
    {
        public CiclabileAlbertature(Session session) : base(session) { }
    }

    [Persistent("ciclabili_illuminazione")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileIlluminazione : CodedDomain<short>
    {
        public CiclabileIlluminazione(Session session) : base(session) { }
    }

    [Persistent("ciclabili_racc_spezz")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileRaccordoSpezzate : CodedDomain<short>
    {
        public CiclabileRaccordoSpezzate(Session session) : base(session) { }
    }

    [Persistent("ciclabili_finanz")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileFinanz : CodedDomain<short>
    {
        public CiclabileFinanz(Session session) : base(session) { }
    }

    [Persistent("ciclabili_tipo_int")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileTipoInt : CodedDomain<short>
    {
        public CiclabileTipoInt(Session session) : base(session) { }
    }

    [Persistent("ciclabili_inter_mod")]
    [NavigationItem("Impostazioni Ciclabili")]
    public partial class CiclabileInterMod : CodedDomain<short>
    {
        public CiclabileInterMod(Session session) : base(session) { }
    }


    #endregion

}
