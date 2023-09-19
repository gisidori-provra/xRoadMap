using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects.cspra
{

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [Persistent(@"CSPRA.EVE_PONTI")]
    public partial class cspraPonte:XPCustomObject
    {
        public cspraPonte(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }


        int fEVE_ID;
        [Key]
        public int EVE_ID
        {
            get { return fEVE_ID; }
            set { SetPropertyValue<int>(nameof(EVE_ID), ref fEVE_ID, value); }
        }
        cspraEnum fTIPO;
        public cspraEnum TIPO
        {
            get { return fTIPO; }
            set { SetPropertyValue<cspraEnum>(nameof(TIPO), ref fTIPO, value); }
        }
        cspraEnum fSCHEMA_STATICO;
        public cspraEnum SCHEMA_STATICO
        {
            get { return fSCHEMA_STATICO; }
            set { SetPropertyValue<cspraEnum>(nameof(SCHEMA_STATICO), ref fSCHEMA_STATICO, value); }
        }
        cspraEnum fILLUMINAZIONE;
        public cspraEnum ILLUMINAZIONE
        {
            get { return fILLUMINAZIONE; }
            set { SetPropertyValue<cspraEnum>(nameof(ILLUMINAZIONE), ref fILLUMINAZIONE, value); }
        }
        cspraEnum fTIPO_MAT_SPALLA;
        public cspraEnum TIPO_MAT_SPALLA
        {
            get { return fTIPO_MAT_SPALLA; }
            set { SetPropertyValue<cspraEnum>(nameof(TIPO_MAT_SPALLA), ref fTIPO_MAT_SPALLA, value); }
        }
        cspraEnum fTIPO_MAT_PILA;
        public cspraEnum TIPO_MAT_PILA
        {
            get { return fTIPO_MAT_PILA; }
            set { SetPropertyValue<cspraEnum>(nameof(TIPO_MAT_PILA), ref fTIPO_MAT_PILA, value); }
        }
        cspraEnum fTIPO_MAT_IMP;
        public cspraEnum TIPO_MAT_IMP
        {
            get { return fTIPO_MAT_IMP; }
            set { SetPropertyValue<cspraEnum>(nameof(TIPO_MAT_IMP), ref fTIPO_MAT_IMP, value); }
        }
        cspraEnum fEL_ATTRAVERSATO;
        public cspraEnum EL_ATTRAVERSATO
        {
            get { return fEL_ATTRAVERSATO; }
            set { SetPropertyValue<cspraEnum>(nameof(EL_ATTRAVERSATO), ref fEL_ATTRAVERSATO, value); }
        }
        cspraEnum fSTATO_MANUT;
        public cspraEnum STATO_MANUT
        {
            get { return fSTATO_MANUT; }
            set { SetPropertyValue<cspraEnum>(nameof(STATO_MANUT), ref fSTATO_MANUT, value); }
        }
    }

}
