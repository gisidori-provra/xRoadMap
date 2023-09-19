using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace xRoadMap.Module.BusinessObjects
{
    public partial class RilievoPuntuale: XPSTGeometry
    {
        public RilievoPuntuale(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        string fDescrizione;
        [Size(SizeAttribute.Unlimited)]
        public string Descrizione
        {
            get { return fDescrizione; }
            set { SetPropertyValue<string>(nameof(Descrizione), ref fDescrizione, value); }
        }

        string siglaSP;
        public string SiglaSP
        {
            get => siglaSP;
            set => SetPropertyValue(nameof(SiglaSP), ref siglaSP, value);
        }

        Strada fStrada;
        [Persistent(@"Strada")]
        public Strada Strada
        {
            get { return fStrada; }
            set { SetPropertyValue(nameof(Strada), ref fStrada, value); }
        }

        string km;
        [DevExpress.Xpo.DisplayName("Progressiva chilometrica")]
        public string Km
        {
            get => km;
            set => SetPropertyValue(nameof(Km), ref km, value);
        }

        DateTime? fDataInizio;
        public DateTime? DataInizio
        {
            get { return fDataInizio; }
            set { SetPropertyValue<DateTime?>(nameof(DataInizio), ref fDataInizio, value); }
        }
        DateTime? fDataFine;
        public DateTime? DataFine
        {
            get { return fDataFine; }
            set { SetPropertyValue<DateTime?>(nameof(DataFine), ref fDataFine, value); }
        }
        string fNote;
        public string Note
        {
            get { return fNote; }
            set { SetPropertyValue<string>(nameof(Note), ref fNote, value); }
        }

        TipoRilievo fTipoRilievo;
        public TipoRilievo TipoRilievo
        {
            get { return fTipoRilievo; }
            set { SetPropertyValue(nameof(TipoRilievo), ref fTipoRilievo, value); }
        }

        [Association,Aggregated]
        public XPCollection<AllegatoRilievo> Allegati => GetCollection<AllegatoRilievo>();

    }

}
