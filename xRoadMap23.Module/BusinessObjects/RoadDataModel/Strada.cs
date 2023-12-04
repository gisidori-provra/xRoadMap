using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using NetTopologySuite.Geometries;

namespace xRoadMap.Module.BusinessObjects
{

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [DefaultProperty(nameof(Sigla))]
    public partial class Strada : XPCustomObject, IXPGeometry,IConStrada
    {
        public Strada() : base() { }
        public Strada(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private Percorso percorso;

        [VisibleInListView(false), VisibleInLookupListView(false)]
        [NoForeignKey]
        public Percorso Percorso
        {
            get => percorso;
            set
            {
                if (percorso == value)
                    return;

                Percorso prev = percorso;
                percorso = value;

                if (IsLoading)
                    return;

                if (prev != null && prev.Strada == this)
                    prev.Strada = null;

                if (percorso != null)
                    percorso.Strada = this;

                OnChanged(nameof(Percorso));

            }
        }

        [VisibleInListView(false), VisibleInLookupListView(false), VisibleInDetailView(false), VisibleInDashboards(false)]
        public Geometry Shape { get => ((IXPGeometry)percorso)?.Shape; set => ((IXPGeometry)percorso).Shape = value; }

        //private XPCollection<Rilievo> rilievi;
        //public XPCollection<Rilievo> Rilievi
        //{
        //    get
        //    {
        //        if (rilievi == null)
        //            rilievi = new XPCollection<Rilievo>(Session);      //(XPCollection<Rilievo>) Session.GetObjectsFromQuery<Rilievo>("SELECT R.* FROM XMAP.RILIEVO R, XMAP.PERCORSO P WHERE P.OBJECTID = @p0 AND SDE.ST_DISTANCE(R.SHAPE,P.SHAPE)<50", new object[] { this.Percorso.Oid });

        //        return rilievi;
        //    }
        //}


        int fOid;
        [Key(true)]
        [Persistent(@"OBJECTID")]
        [System.ComponentModel.Browsable(false)]
        public int Oid
        {
            get { return fOid; }
            set { SetPropertyValue<int>(nameof(Oid), ref fOid, value); }
        }
        string fSigla;
        public string Sigla
        {
            get { return fSigla; }
            set { SetPropertyValue<string>(nameof(Sigla), ref fSigla, value); }
        }
        string fDenominazione;
        public string Denominazione
        {
            get { return fDenominazione; }
            set { SetPropertyValue<string>(nameof(Denominazione), ref fDenominazione, value); }
        }
        TipoClassificaFunzionale fClassificaFunzionale;
        [NoForeignKey]
        public TipoClassificaFunzionale ClassificaFunzionale
        {
            get { return fClassificaFunzionale; }
            set { SetPropertyValue<TipoClassificaFunzionale>(nameof(ClassificaFunzionale), ref fClassificaFunzionale, value); }
        }
        string fNumero;
        public string Numero
        {
            get { return fNumero; }
            set { SetPropertyValue<string>(nameof(Numero), ref fNumero, value); }
        }
        TipoAsse fAsse;
        [NoForeignKey]
        public TipoAsse Asse
        {
            get { return fAsse; }
            set { SetPropertyValue<TipoAsse>(nameof(Asse), ref fAsse, value); }
        }
        TipoAmministrazione fTipoAmministrazione;
        [NoForeignKey]
        public TipoAmministrazione TipoAmministrazione
        {
            get { return fTipoAmministrazione; }
            set { SetPropertyValue<TipoAmministrazione>(nameof(TipoAmministrazione), ref fTipoAmministrazione, value); }
        }
        string fTronco;
        public string Tronco
        {
            get { return fTronco; }
            set { SetPropertyValue<string>(nameof(Tronco), ref fTronco, value); }
        }
        StatoGrafo fStato;
        public StatoGrafo Stato
        {
            get { return fStato; }
            set { SetPropertyValue<StatoGrafo>(nameof(Stato), ref fStato, value); }
        }

        double kmIniziale;
        public double KMIniziale
        {
            get => kmIniziale;
            set => SetPropertyValue(nameof(KMIniziale), ref kmIniziale, value);
        }

        double kmFinale;
        public double KMFinale
        {
            get => kmFinale;
            set => SetPropertyValue(nameof(KMFinale), ref kmFinale, value);
        }

        [DevExpress.Persistent.Base.VisibleInDetailView(false), DevExpress.Persistent.Base.VisibleInListView(false)]
        [Association(), Aggregated]
        public XPCollection<Cippo> Cippi { get { return GetCollection<Cippo>(nameof(Cippi)); } }
        [Association(), Aggregated]
        public XPCollection<Tombino> Tombini { get { return GetCollection<Tombino>(nameof(Tombini)); } }
        [Association(), Aggregated]
        public XPCollection<Ponte> Ponti { get { return GetCollection<Ponte>(nameof(Ponti)); } }
        [Association(), Aggregated]
        public XPCollection<Ordinanza> Ordinanze { get { return GetCollection<Ordinanza>(nameof(Ordinanze)); } }
        [Association,Aggregated]
        public XPCollection<Accesso> Accessi => GetCollection<Accesso>(nameof(Accessi));
        [Association, Aggregated]
        public XPCollection<AreaTraffico> AreeTraffico => GetCollection<AreaTraffico>(nameof(AreeTraffico));
        [Association, Aggregated]
        public XPCollection<Banchina> Banchine => GetCollection<Banchina>();

        [System.ComponentModel.DisplayName("Carreggiata")]
        [Association, Aggregated]
        public XPCollection<Carreggiata> Carreggiate => GetCollection<Carreggiata>();

        [Association, Aggregated]
        public XPCollection<CentroAbitato> CentriAbitati=> GetCollection<CentroAbitato>();

        [Association, Aggregated]
        public XPCollection<CorpoStradale> CorpiStradali=> GetCollection<CorpoStradale>();

        [Association, Aggregated]
        public XPCollection<Galleria> Gallerie => GetCollection<Galleria>();

        [Association, Aggregated]
        public XPCollection<Marciapiede> Marciapiedi => GetCollection<Marciapiede>();

        [Association, Aggregated]
        public XPCollection<OperaSostegno> OpereSostegno => GetCollection<OperaSostegno>();

        [Association, Aggregated]
        public XPCollection<PassaggioLivello> PassaggiLivello => GetCollection<PassaggioLivello>();

        [Association, Aggregated]
        public XPCollection<Sottopasso> Sottopassi => GetCollection<Sottopasso>();

        [Association, Aggregated]
        public XPCollection<Vegetazione> Vegetazione => GetCollection<Vegetazione>();

        [Association, Aggregated]
        public XPCollection<Arginello> Arginelli => GetCollection<Arginello>();

        [Association, Aggregated]
        public XPCollection<Ciclabile> Ciclabili => GetCollection<Ciclabile>();

        [Association, Aggregated]
        public XPCollection<Cunetta> Cunette => GetCollection<Cunetta>();

        [Association, Aggregated]
        public XPCollection<DispositivoRitenuta> DispositiviRitenuta => GetCollection<DispositivoRitenuta>();

        [Association, Aggregated]
        public XPCollection<Illuminazione> Illuminazione => GetCollection<Illuminazione>();

        [Association, Aggregated]
        public XPCollection<ImpiantoPubblicitario> ImpiantiPubblicitari => GetCollection<ImpiantoPubblicitario>();


        [Association, Aggregated]
        public XPCollection<EventoLineareSuStrada> EventiLineari => GetCollection<EventoLineareSuStrada>(nameof(EventiLineari));

        Strada IConStrada.Strada { get => this;}
    }

}
