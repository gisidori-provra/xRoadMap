using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;

namespace xRoadMap.Module.BusinessObjects
{
    [Persistent(@"ARCO")]
    [EditorAlias("MapListEditor")]
    public partial class Arco: XPSTGeometry
    {
        public Arco() : base() { }
        public Arco(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        Strada fStrada;
        [Association(@"ArcoReferencesStrada"), NoForeignKey]
        public Strada Strada
        {
            get { return fStrada; }
            set { SetPropertyValue<Strada>(nameof(Strada), ref fStrada, value); }
        }
        TipoElementoStradale fTipoElementoStradale;
        [NoForeignKey]
        public TipoElementoStradale TipoElementoStradale
        {
            get { return fTipoElementoStradale; }
            set { SetPropertyValue<TipoElementoStradale>(nameof(TipoElementoStradale), ref fTipoElementoStradale, value); }
        }
        TipoConfineAmministrativo fConfineAmministrativo;
        [NoForeignKey]
        public TipoConfineAmministrativo ConfineAmministrativo
        {
            get { return fConfineAmministrativo; }
            set { SetPropertyValue<TipoConfineAmministrativo>(nameof(ConfineAmministrativo), ref fConfineAmministrativo, value); }
        }
        TipoCarreggiata fTipoCarreggiata;
        [NoForeignKey]
        public TipoCarreggiata TipoCarreggiata
        {
            get { return fTipoCarreggiata; }
            set { SetPropertyValue<TipoCarreggiata>(nameof(TipoCarreggiata), ref fTipoCarreggiata, value); }
        }
        double fLunghezza;
        public double Lunghezza
        {
            get { return fLunghezza; }
            set { SetPropertyValue<double>(nameof(Lunghezza), ref fLunghezza, value); }
        }
        float fStato;
        [NoForeignKey]
        public float Stato
        {
            get { return fStato; }
            set { SetPropertyValue<float>(nameof(Stato), ref fStato, value); }
        }
        TipoFonte fFonte;
        [NoForeignKey]
        public TipoFonte Fonte
        {
            get { return fFonte; }
            set { SetPropertyValue<TipoFonte>(nameof(Fonte), ref fFonte, value); }
        }
        LivelloGrafo fLivelloGrafo;
        public LivelloGrafo LivelloGrafo
        {
            get { return fLivelloGrafo; }
            set { SetPropertyValue<LivelloGrafo>(nameof(LivelloGrafo), ref fLivelloGrafo, value); }
        }

    }

}
