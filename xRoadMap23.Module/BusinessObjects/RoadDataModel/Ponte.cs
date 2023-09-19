using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects
{

    [MapInheritance(MapInheritanceType.OwnTable)]
    public partial class Ponte : EventoLineare, IEventoLineareOnRoad
    {
        public Ponte(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

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

        string fNome;
        public string Nome
        {
            get { return fNome; }
            set { SetPropertyValue<string>(nameof(Nome), ref fNome, value); }
        }
        TipoSchemaStatico fTipoSchemaStatico;
        [NoForeignKey]
        public TipoSchemaStatico TipoSchemaStatico
        {
            get { return fTipoSchemaStatico; }
            set { SetPropertyValue<TipoSchemaStatico>(nameof(TipoSchemaStatico), ref fTipoSchemaStatico, value); }
        }
        TipoOpera fTipoOpera;
        [NoForeignKey]
        public TipoOpera TipoOpera
        {
            get { return fTipoOpera; }
            set { SetPropertyValue<TipoOpera>(nameof(TipoOpera), ref fTipoOpera, value); }
        }
        TipoMateriale fTipoMateriale;
        [DevExpress.Xpo.DisplayName(@"Tipo materiale impalcato")]
        [NoForeignKey]
        public TipoMateriale TipoMateriale
        {
            get { return fTipoMateriale; }
            set { SetPropertyValue<TipoMateriale>(nameof(TipoMateriale), ref fTipoMateriale, value); }
        }
        TipoMateriale fTipoSpalla;
        [DevExpress.Xpo.DisplayName(@"Tipo materiale spalla")]
        [NoForeignKey]
        public TipoMateriale TipoSpalla
        {
            get { return fTipoSpalla; }
            set { SetPropertyValue<TipoMateriale>(nameof(TipoSpalla), ref fTipoSpalla, value); }
        }
        TipoMateriale fTipoPila;
        [DevExpress.Xpo.DisplayName(@"Tipo materiale pilastri")]
        [NoForeignKey]
        public TipoMateriale TipoPila
        {
            get { return fTipoPila; }
            set { SetPropertyValue<TipoMateriale>(nameof(TipoPila), ref fTipoPila, value); }
        }
        int fNumeroCampate;
        public int NumeroCampate
        {
            get { return fNumeroCampate; }
            set { SetPropertyValue<int>(nameof(NumeroCampate), ref fNumeroCampate, value); }
        }
        double fLunghezza;
        public double Lunghezza
        {
            get { return fLunghezza; }
            set { SetPropertyValue<double>(nameof(Lunghezza), ref fLunghezza, value); }
        }
        double fLarghezza;
        public double Larghezza
        {
            get { return fLarghezza; }
            set { SetPropertyValue<double>(nameof(Larghezza), ref fLarghezza, value); }
        }
        double fLunghMaxCampata;
        public double LunghMaxCampata
        {
            get { return fLunghMaxCampata; }
            set { SetPropertyValue<double>(nameof(LunghMaxCampata), ref fLunghMaxCampata, value); }
        }
        bool fIlluminazione;
        public bool Illuminazione
        {
            get { return fIlluminazione; }
            set { SetPropertyValue<bool>(nameof(Illuminazione), ref fIlluminazione, value); }
        }
        TipoElementoAttraversato fTipoElementoAttraversato;
        [NoForeignKey]
        public TipoElementoAttraversato TipoElementoAttraversato
        {
            get { return fTipoElementoAttraversato; }
            set { SetPropertyValue<TipoElementoAttraversato>(nameof(TipoElementoAttraversato), ref fTipoElementoAttraversato, value); }
        }
        string fNote;
        public string Note
        {
            get { return fNote; }
            set { SetPropertyValue<string>(nameof(Note), ref fNote, value); }
        }
        TipoStatoConservazione fStatoConservazione;
        public TipoStatoConservazione StatoConservazione
        {
            get { return fStatoConservazione; }
            set { SetPropertyValue<TipoStatoConservazione>(nameof(StatoConservazione), ref fStatoConservazione, value); }
        }
        string fCodiceARS;
        public string CodiceARS
        {
            get { return fCodiceARS; }
            set { SetPropertyValue<string>(nameof(CodiceARS), ref fCodiceARS, value); }
        }


        [Association, NoForeignKey]
        public XPCollection<LimiteTransito> LimitiTransito => GetCollection<LimiteTransito>();

        [Association(@"IspezioneReferencesPonte"), Aggregated]
        public XPCollection<Ispezione> Ispezioni { get { return GetCollection<Ispezione>(nameof(Ispezioni)); } }

    }

}
