using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using NetTopologySuite.Geometries;
using DevExpress.Persistent.Base;
using DevExpress.Xpo.DB;
using OracleInternal.Secure.Network;
using DevExpress.ExpressApp.Model;

namespace xRoadMap.Module.BusinessObjects
{
    [NonPersistent]
    public partial class EventoPuntuale : XPSTGeometry, IEvento, IEventoOnRoad
    {
        public EventoPuntuale(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            DataInizio = System.DateTime.Now.Date;
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            //switch (Tipo)
            //{
            //    case TipoPosizione.ProgressivaChilometrica:
            //        this.M = RoutingHelper.GetMeasureFromChilometrica(this as IEventoOnRoad, this.Km);
            //        break;
            //    case TipoPosizione.Coordinate:
            //        this.Km = RoutingHelper.GetChilometricaFromMeasure(this as IEventoOnRoad, this.M);
            //        break;
            //}

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

        protected Strada strada;

        public virtual void SetStrada(Strada value)
        {
            SetPropertyValue<Strada>(nameof(Strada),ref strada , value);
        }

        Strada IEventoOnRoad.Strada { get => strada; set => SetStrada(value); }

        string km;
        [DevExpress.Xpo.DisplayName("Progressiva chilometrica")]
        [DevExpress.ExpressApp.ConditionalAppearance.Appearance("Km",Criteria = "Tipo = ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate#",Enabled = false)]
        public string Km
        {
            get => km;
            set => SetPropertyValue(nameof(Km), ref km, value);
        }

        TipoPosizione tipo;
        [ImmediatePostData]
        [DevExpress.Xpo.DisplayName("Tipo localizzazione")]
        public TipoPosizione Tipo
        {
            get => tipo;
            set => SetPropertyValue(nameof(Tipo), ref tipo, value);
        }

        double x;
        [DevExpress.Xpo.DisplayName(@"Coord. X")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double X
        {
            get => x;
            set => SetPropertyValue(nameof(X), ref x, value);
        }

        double y;
        [DevExpress.Xpo.DisplayName(@"Coord. Y")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double Y
        {
            get => y;
            set => SetPropertyValue(nameof(Y), ref y, value);
        }

        double z;
        [DevExpress.Xpo.DisplayName(@"Coord. Z")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double Z
        {
            get => z;
            set => SetPropertyValue(nameof(Z), ref z, value);
        }

        double m;
        [DevExpress.Xpo.DisplayName(@"Coord. M")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double M
        {
            get => m;
            set => SetPropertyValue(nameof(M), ref m, value);
        }

        double latitudine;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double Latitudine
        {
            get => latitudine;
            set => SetPropertyValue(nameof(Latitudine), ref latitudine, value);
        }
        // 44.41282085106091, 12.202746983518818
        double longitudine;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit","False")]
        public double Longitudine
        {
            get => longitudine;
            set => SetPropertyValue(nameof(Longitudine), ref longitudine, value);
        }

        [System.ComponentModel.DisplayName("Latitudine (°'\")")]
        [DevExpress.ExpressApp.ConditionalAppearance.Appearance("LatitudineSessagesimale", Enabled = false, Criteria = "Tipo <> ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate#")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        [NonPersistent]
        public string LatitudineSessagesimale
        {
            get => RoutingHelper.ToSessagesimale(Latitudine);
            set => Latitudine = RoutingHelper.FromSessagesimale(value);
        }

        [System.ComponentModel.DisplayName("Longitudine (°'\")")]
        [DevExpress.ExpressApp.ConditionalAppearance.Appearance("LongitudineSessagesimale",Enabled =false, Criteria = "Tipo <> ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate#")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        [NonPersistent]
        public string LongitudineSessagesimale
        {
            get => RoutingHelper.ToSessagesimale(Longitudine);
            set => Longitudine = RoutingHelper.FromSessagesimale(value);
        }

        Strada IConStrada.Strada => strada;

        //[Association, Aggregated]
        //public XPCollection<AllegatoEventoPuntuale> Allegati => GetCollection<AllegatoEventoPuntuale>();


    }

}
