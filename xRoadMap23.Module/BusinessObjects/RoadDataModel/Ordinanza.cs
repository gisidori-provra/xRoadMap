using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Utils.Filtering.Internal;

namespace xRoadMap.Module.BusinessObjects
{


    [MapInheritance(MapInheritanceType.OwnTable)]
    [DefaultProperty(nameof(Descrizione))]
    public partial class Ordinanza: EventoLineare,IEventoLineareOnRoad
    {
        public Ordinanza(Session session) : base(session) { }
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

        string fDescrizione;
        [Size(SizeAttribute.Unlimited)]
        public string Descrizione
        {
            get { return fDescrizione; }
            set { SetPropertyValue<string>(nameof(Descrizione), ref fDescrizione, value); }
        }

        private Ponte ponte;
        [Association]
        [VisibleInListView(false)]
        public Ponte Ponte
        {
            get => ponte;
            set => SetPropertyValue(nameof(Ponte), ref ponte, value);
        }

        [NonPersistent]
        [ModelDefault("DisplayFormat", "{0:hh\\:mm}")]
        [ModelDefault("EditMaskType", "DateTime")]
        [ModelDefault("EditMask", @"HH:mm")]
        [Appearance("DalleOre.Enabled", Enabled = false, Criteria = "DataInizio IS NULL")]
        public TimeSpan? DalleOre
        {
            get => DataInizio?.TimeOfDay;
            set
            {
                if (DataInizio.HasValue && value.HasValue)
                {
                    DataInizio = DataInizio.Value.Date + value;
                    OnChanged(nameof(DalleOre));
                }
            }
        }

        [NonPersistent]
        [ModelDefault("DisplayFormat", "{0:hh\\:mm}")]
        [ModelDefault("EditMaskType", "DateTime")]
        [ModelDefault("EditMask", @"HH:mm")]
        [Appearance("AlleOre.Enabled",Enabled =false,Criteria ="DataFine IS NULL")]
        public TimeSpan? AlleOre
        {
            get => DataFine?.TimeOfDay;
            set
            {
                if (DataFine.HasValue && value.HasValue)
                {
                    DataFine = DataFine.Value.Date + value;
                    OnChanged(nameof(AlleOre));
                }
            }
        }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public bool Vigente => (!DataInizio.HasValue || DataInizio.Value <= DateTime.Today) && (!DataFine.HasValue || DataFine >= DateTime.Today);

        bool fLimiteMassa;
        [ImmediatePostData]
        public bool LimiteMassa
        {
            get => fLimiteMassa;
            set => SetPropertyValue(nameof(LimiteMassa), ref fLimiteMassa, value);
        }

        double fPortata;
        [DevExpress.Xpo.DisplayName(@"Portata (Ton)")]
        [Appearance("LimiteMassa", criteria: "NOT LimiteMassa", Enabled = false)]
        [VisibleInListView(false)]
        [Persistent("MASSA")]
        public double Portata
        {
            get { return fPortata; }
            set { SetPropertyValue<double>(nameof(Portata), ref fPortata, value); }
        }

        TipoSagoma fLimiteSagoma;
        [ImmediatePostData]
        public TipoSagoma LimiteSagoma
        {
            get => fLimiteSagoma;
            set => SetPropertyValue(nameof(LimiteSagoma), ref fLimiteSagoma, value);
        }

        double fSagoma;
        [Appearance("LimiteSagoma", criteria: "LimiteSagoma=##Enum#xRoadMap.Module.BusinessObjects.TipoSagoma,Libero#", Enabled = false)]
        [DevExpress.Xpo.DisplayName("Limite Sagoma (mt)")]
        [VisibleInListView(false)]
        public double Sagoma
        {
            get => fSagoma;
            set { SetPropertyValue(nameof(Sagoma), ref fSagoma, value); }
        }


        bool fLimiteVelocità;
        [ImmediatePostData]
        [Persistent("LIMITEVELOCITA")]
        public bool LimiteVelocità
        {
            get => fLimiteVelocità;
            set => SetPropertyValue(nameof(LimiteVelocità), ref fLimiteVelocità, value);
        }

        int fVelocità;
        [DevExpress.Xpo.DisplayName(@"Limite di velocità (km/h)")]
        [Appearance("LimiteVelocità",criteria:"NOT LimiteVelocità",Enabled = false)]
        [VisibleInListView(false)]
        [Persistent("Velocita")]
        public int Velocità
        {
            get { return fVelocità; }
            set { SetPropertyValue(nameof(Velocità), ref fVelocità, value); }
        }

        TipoPercorrenza fPercorribilità;
        [ImmediatePostData]
        [Persistent("PERCORRIBILITA")]
        public TipoPercorrenza Percorribilità
        {
            get => fPercorribilità;
            set => SetPropertyValue(nameof(Percorribilità),ref fPercorribilità,value);    
        }

        private bool centroAbitato;
        [DevExpress.Xpo.DisplayName(@"Centro abitato")]
        [VisibleInListView(false)]
        public bool CentroAbitato
        { 
            get => centroAbitato;
            set => SetPropertyValue(nameof(CentroAbitato),ref centroAbitato,value);
        }

    }

}
