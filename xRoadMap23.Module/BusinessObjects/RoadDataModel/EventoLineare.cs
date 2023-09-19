using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using NetTopologySuite.Geometries;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;

namespace xRoadMap.Module.BusinessObjects
{
    [NonPersistent]
    public abstract partial class EventoLineare : XPSTGeometry, IEventoLineare,IEventoOnRoad
    {
        public EventoLineare(Session session) : base(session) { }

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
            //        this.MFine = RoutingHelper.GetMeasureFromChilometrica(this as IEventoOnRoad, this.KmFine);
            //        break;
            //    case TipoPosizione.Coordinate:
            //        this.KmFine = RoutingHelper.GetChilometricaFromMeasure(this as IEventoOnRoad, this.MFine);
            //        break;
            //}
        }


        DateTime? fDataInizio;
        [ImmediatePostData]
        public DateTime? DataInizio
        {
            get { return fDataInizio; }
            set { SetPropertyValue<DateTime?>(nameof(DataInizio), ref fDataInizio, value); }
        }
        DateTime? fDataFine;
        [ImmediatePostData]
        public DateTime? DataFine
        {
            get { return fDataFine; }
            set { SetPropertyValue<DateTime?>(nameof(DataFine), ref fDataFine, value); }
        }

        Atto fAtto;
        [Aggregated, DevExpress.Persistent.Base.ExpandObjectMembers(DevExpress.Persistent.Base.ExpandObjectMembers.Never), NoForeignKey]
        public Atto Atto
        {
            get { return fAtto; }
            set { SetPropertyValue<Atto>(nameof(Atto), ref fAtto, value); }
        }

        protected Strada strada;

        public virtual void SetStrada(Strada value)
        {
            throw new NotImplementedException();
        }

        Strada IEventoOnRoad.Strada { get => strada; set => SetStrada(value); }

        string km;
        [DevExpress.Xpo.DisplayName("Progressiva chilometrica")]
        [DevExpress.ExpressApp.ConditionalAppearance.Appearance("Km", Criteria = "Tipo = ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate#", Enabled = false)]
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

        string kmFine;
        [DevExpress.Xpo.DisplayName("Progressiva chilometrica finale")]
        [DevExpress.ExpressApp.ConditionalAppearance.Appearance("KmFine", Criteria = "Tipo = ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate#", Enabled = false)]
        public string KmFine
        {
            get => kmFine;
            set => SetPropertyValue(nameof(KmFine), ref kmFine, value);
        }

        double xFine;
        [DevExpress.Xpo.DisplayName(@"Coord. X Finale")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double XFine
        {
            get => xFine;
            set => SetPropertyValue(nameof(XFine), ref xFine, value);
        }

        double yFine;
        [DevExpress.Xpo.DisplayName(@"Coord. Y Finale")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double YFine
        {
            get => yFine;
            set => SetPropertyValue(nameof(YFine), ref yFine, value);
        }

        double zFine;
        [DevExpress.Xpo.DisplayName(@"Coord. Z Finale")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double ZFine
        {
            get => zFine;
            set => SetPropertyValue(nameof(ZFine), ref zFine, value);
        }

        double mFine;
        [DevExpress.Xpo.DisplayName(@"Coord. M Finale")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "n0")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double MFine
        {
            get => mFine;
            set => SetPropertyValue(nameof(MFine), ref mFine, value);
        }

        int eve_id;
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public int Event_id
        {
            get => eve_id;
            set => SetPropertyValue(nameof(Event_id), ref eve_id, value);
        }

        double offset;
        public double Offset
        {
            get => offset;
            set => SetPropertyValue(nameof(Offset), ref offset, value);
        }




        private string urlCMS;
        [VisibleInListView(false)]
        [Size(512)]
        public string UrlCMS
        {
            get => urlCMS;
            set => SetPropertyValue(nameof(UrlCMS), ref urlCMS, value);
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
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double Longitudine
        {
            get => longitudine;
            set => SetPropertyValue(nameof(Longitudine), ref longitudine, value);
        }

        //[Association, Aggregated]
        //public XPCollection<AllegatoEventoLineare> Allegati => GetCollection<AllegatoEventoLineare>();

        double latitudineFine;
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double LatitudineFine
        {
            get => latitudineFine;
            set => SetPropertyValue(nameof(LatitudineFine), ref latitudineFine, value);
        }

        double longitudineFine;
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        public double LongitudineFine
        {
            get => longitudineFine;
            set => SetPropertyValue(nameof(LongitudineFine), ref longitudineFine, value);
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
        [DevExpress.ExpressApp.ConditionalAppearance.Appearance("LongitudineSessagesimale", Enabled = false, Criteria = "Tipo <> ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate#")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        [NonPersistent]
        public string LongitudineSessagesimale
        {
            get => RoutingHelper.ToSessagesimale(Longitudine);
            set => Longitudine = RoutingHelper.FromSessagesimale(value);
        }

        [System.ComponentModel.DisplayName("Latitudine Fine (°'\")")]
        [DevExpress.ExpressApp.ConditionalAppearance.Appearance("LatitudineFineSessagesimale", Enabled = false, Criteria = "Tipo <> ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate#")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        [NonPersistent]
        public string LatitudineFineSessagesimale
        {
            get => RoutingHelper.ToSessagesimale(LatitudineFine);
            set => LatitudineFine = RoutingHelper.FromSessagesimale(value);
        }


        [System.ComponentModel.DisplayName("Longitudine Fine (°'\")")]
        [DevExpress.ExpressApp.ConditionalAppearance.Appearance("LongitudineFineSessagesimale", Enabled = false, Criteria = "Tipo <> ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate#")]
        [DevExpress.ExpressApp.Model.ModelDefault("AllowEdit", "False")]
        [NonPersistent]
        public string LongitudineFineSessagesimale
        {
            get => RoutingHelper.ToSessagesimale(LongitudineFine);
            set => LongitudineFine = RoutingHelper.FromSessagesimale(value);
        }

        Strada IConStrada.Strada => strada;
    }

}
