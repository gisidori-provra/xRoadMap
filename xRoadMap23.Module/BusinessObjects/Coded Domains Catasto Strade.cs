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
    public partial class TipoCiclabile : CodedDomain<double>
    {
        public TipoCiclabile(Session session) : base(session) { }
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


    [Persistent("ciclabile_senso_percorrenza")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class SensoCiclabile : CodedDomain<double>
    {
        public SensoCiclabile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("ciclabile_categoria_funzionale")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class CategoriaFunzionaleCiclabile : CodedDomain<double>
    {
        public CategoriaFunzionaleCiclabile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("ciclabile_tipologia_protezione")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class TipologiaProtezioneCiclabile : CodedDomain<double>
    {
        public TipologiaProtezioneCiclabile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("ciclabile_compatibilita_veicolare")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class CompatibilitaVeicolareCiclabile : CodedDomain<double>
    {
        public CompatibilitaVeicolareCiclabile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("ciclabile_connessione_rete")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class ConnessioneReteCiclabile : CodedDomain<double>
    {
        public ConnessioneReteCiclabile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    [Persistent("ciclabile_categoria_utenza")]
    [NavigationItem("Impostazioni Catasto Strade")]
    public partial class CategoriaUtenzaCiclabile : CodedDomain<double>
    {
        public CategoriaUtenzaCiclabile(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
