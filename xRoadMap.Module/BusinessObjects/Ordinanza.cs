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
using DevExpress.Persistent.Validation;
using DevExpress.Office.NumberConverters;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace xRoadMap.Module.BusinessObjects
{


    [MapInheritance(MapInheritanceType.OwnTable)]
    public partial class Ordinanza : EventoSuStrada, IEventoLineareOnRoad
    {
        public Ordinanza(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            TipoGeometria = TipoGeometriaEvento.Lineare;
            base.AfterConstruction();
        }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public string Name => $"Ordinanza nr {this.Atto?.Numero} del {this.Atto?.Data} - {this.Descrizione}";

        [RuleRequiredField]
        [Association]
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada), ref strada, value);
        }

        Atto fAtto;
        [Aggregated, DevExpress.Persistent.Base.ExpandObjectMembers(DevExpress.Persistent.Base.ExpandObjectMembers.Never), NoForeignKey]
        public Atto Atto
        {
            get { return fAtto; }
            set { SetPropertyValue<Atto>(nameof(Atto), ref fAtto, value); }
        }


        private string urlCMS;
        [VisibleInListView(false)]
        [Size(512)]
        public string UrlCMS
        {
            get => urlCMS;
            set => SetPropertyValue(nameof(UrlCMS), ref urlCMS, value);
        }

        public override void SetStrada(Strada value)
        {
            Strada = value;
        }

        string fDescrizione;
        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "5")]
        public string Descrizione
        {
            get { return fDescrizione; }
            set { SetPropertyValue<string>(nameof(Descrizione), ref fDescrizione, value); }
        }

        string note;
        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "5")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public string Note
        {
            get => note;
            set => SetPropertyValue(nameof(Note), ref note, value);
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
        [Appearance("AlleOre.Enabled", Enabled = false, Criteria = "DataFine IS NULL")]
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
        [PersistentAlias($"({nameof(DataInizio)} IS NULL OR {nameof(DataInizio)}<=Today()) AND ({nameof(DataFine)} IS NULL OR {nameof(DataFine)}>Today()) AND ({nameof(Stato)}=0)")]
        public bool Vigente => (bool)EvaluateAlias(); //(!DataInizio.HasValue || DataInizio.Value <= DateTime.Today) && (!DataFine.HasValue || DataFine >= DateTime.Today);

        [VisibleInDetailView(false)]
        [PersistentAlias($"Iif([{nameof(OrdinanzeSuccessive)}][], 1, 0)")]
        public VersioneOrdinanza Versione => (VersioneOrdinanza)EvaluateAlias();

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
        [Appearance("LimiteVelocità", criteria: "NOT LimiteVelocità", Enabled = false)]
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
            set => SetPropertyValue(nameof(Percorribilità), ref fPercorribilità, value);
        }

        [Browsable(false)]
        [RuleFromBoolProperty("Valido", DefaultContexts.Save, CustomMessageTemplate = "Specificare un tipo di limitazione")]
        public bool IsValid
        {
            get => LimiteMassa || LimiteSagoma != TipoSagoma.Libero || LimiteVelocità || Percorribilità != TipoPercorrenza.Libero;
        }

        StatoOrdinanza fStato;
        public StatoOrdinanza Stato
        {
            get => fStato;
            set => SetPropertyValue(nameof(Stato), ref fStato, value);
        }

        private Ordinanza fOrdinanzaPrecedente;

        [Association]
        [VisibleInListView(false)]
        [System.ComponentModel.DisplayName("Ordinanza Modificata")]
        [ToolTip("Ordinanza che viene modificata o revocata dall'ordinanza corrente")]
        [DataSourceCriteria($"Strada='@This.Strada' AND Oid<>'@This.Oid'")]
        public Ordinanza OrdinanzaPrecedente
        {
            get => fOrdinanzaPrecedente;
            set => SetPropertyValue(nameof(OrdinanzaPrecedente), ref fOrdinanzaPrecedente, value);
        }

        [DevExpress.ExpressApp.DC.XafDisplayName("Modificata da:")]
        [Association]
        public XPCollection<Ordinanza> OrdinanzeSuccessive
        {
            get
            {
                return GetCollection<Ordinanza>(nameof(OrdinanzeSuccessive));
            }
        }

        [Association, Aggregated]
        public XPCollection<AllegatoOrdinanza> Allegati => GetCollection<AllegatoOrdinanza>(nameof(Allegati));

    }

    [Persistent("ALLEGATO_ORDINANZA")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class AllegatoOrdinanza : Allegato
    {
        public AllegatoOrdinanza(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        Ordinanza fOrdinanza;
        [Persistent(@"REL_OBJECTID")]
        [Association]
        public Ordinanza Ordinanza
        {
            get => fOrdinanza;
            set => SetPropertyValue(nameof(Ordinanza), ref fOrdinanza, value);
        }

        string fDescrizione;
        public string Descrizione
        {
            get => fDescrizione;
            set => SetPropertyValue(nameof(Descrizione), ref fDescrizione, value);
        }


    }
    public enum StatoOrdinanza
    {
        Emessa = 0,
        Revocata =1
    }

    public enum VersioneOrdinanza
    {
        Originale = 0,
        Modificata = 1
    }
}
