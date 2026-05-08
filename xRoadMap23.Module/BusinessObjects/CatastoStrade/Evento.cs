using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using NetTopologySuite.Geometries;
using DevExpress.ExpressApp.Workflow.StartWorkflowConditions;
using System.Runtime.CompilerServices;
using DevExpress.Persistent.Base;
using System.Globalization;
using DevExpress.Drawing.Internal.Fonts.Interop;
using DevExpress.XtraPrinting.Native;
using DevExpress.ExpressApp.Model;
using System.Net.Http.Headers;

namespace xRoadMap.Module.BusinessObjects
{

    [OptimisticLocking(false)]
    [DeferredDeletion(false)]

    public abstract partial class Evento : IEvento
    {
        public Evento(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            DataInizio = System.DateTime.Now.Date;
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            switch (Tipo)
            {
                case TipoPosizione.ProgressivaChilometrica:
                    if (this is IEventoPuntualeOnRoad evp)
                        evp.M = RoutingHelper.GetMeasureFromChilometrica(evp, evp.Km);
                    if (this is IEventoLineareOnRoad evl)
                        evl.MFine = RoutingHelper.GetMeasureFromChilometrica(evl,evl.KmFine);
                    break;
                case TipoPosizione.Coordinate:
                    if (this is IEventoPuntualeOnRoad evp2)
                        evp2.Km = RoutingHelper.GetChilometricaFromMeasure(evp2, evp2.M);
                    if (this is IEventoLineareOnRoad evl2)
                        evl2.KmFine = RoutingHelper.GetChilometricaFromMeasure(evl2, evl2.MFine);
                    break;
            }

            var culture = CultureInfo.InvariantCulture;
            var lat = Latitudine.ToString("F7", culture);
            var lon = Longitudine.ToString("F7", culture);
            var z = Z.ToString("F0", culture);
            int zoom = 17;
            this.UrlGoogleMaps = $@"https://www.google.com/maps/@?api=1&map_action=map&center={lat},{lon}&Zoom={zoom}";
            this.IFrameContent = 
$@"<style>
    .embed-container {{position: relative; padding-bottom: 80%; height: 0; max-width: 100%;}} 
    .embed-container iframe, 
    .embed-container object, 
    .embed-container iframe{{position: absolute; top: 0; left: 0; width: 100%; height: 100%;}} small{{position: absolute; z-index: 40; bottom: 0; margin-bottom: -15px;}}
</style>
<div class=""embed-container"">
    <iframe width=""500"" height=""400"" frameborder=""0"" scrolling=""no"" marginheight=""0"" marginwidth=""0"" title=""OrdinanzeLavori"" 
    src=""//sitportal.provincia.ra.it/arcgis/apps/Embed/index.html?webmap=e36bbe3597854498866d94cc1d7c9591&center={lon},{lat}
        &zoom=true
        &previewImage=false
        &scale=true
        &disable_scroll=true
        &theme=light
        &level={zoom}"">
    </iframe>
</div>";

        }

       
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            switch (propertyName)
            {
                case nameof(IEventoOnRoad.Strada):
                    Strada s = newValue as Strada;
                    Sigla = s?.Sigla;
                    OIDStrada = s?.Oid;
                    break;
                case nameof(Sigla):
                    string sigla = newValue as string;
                    ((IEventoOnRoad)this).Strada = Session.FindObject<Strada>(new BinaryOperator(nameof(Sigla), sigla));
                    break;
                default:
                    break;
            }
        }




        TipoGeometriaEvento fTipoGeometria;
        [Browsable(false)]
        public TipoGeometriaEvento TipoGeometria
        {
            get { return fTipoGeometria; }
            set { SetPropertyValue<TipoGeometriaEvento>(nameof(TipoGeometria), ref fTipoGeometria, value); }
        }
        string fLocalità;
        public string Località
        {
            get { return fLocalità; }
            set { SetPropertyValue<string>(nameof(Località), ref fLocalità, value); }
        }

        string fSigla;
        [MemberDesignTimeVisibility(false)]
        public string Sigla
        {
            get { return fSigla; }
            set { SetPropertyValue<string>(nameof(Sigla), ref fSigla, value); }
        }
        int? fOIDStrada;
        [MemberDesignTimeVisibility(false)]
        public int? OIDStrada
        {
            get { return fOIDStrada; }
            set { SetPropertyValue<int?>(nameof(OIDStrada), ref fOIDStrada, value); }
        }
        bool fLocate;
        [MemberDesignTimeVisibility(false)]
        public bool Locate
        {
            get { return fLocate; }
            set { SetPropertyValue<bool>(nameof(Locate), ref fLocate, value); }
        }

        int feve_id;
        [Indexed(Name = @"UXeve_id", Unique = true)]
        [MemberDesignTimeVisibility(false)]
        public int eve_id
        {
            get { return feve_id; }
            set { SetPropertyValue<int>(nameof(eve_id), ref feve_id, value); }
        }





        double offset;
        public double Offset
        {
            get => offset;
            set => SetPropertyValue(nameof(Offset), ref offset, value);
        }

        private string urlGoogleMaps;
        [ModelDefault("AllowEdit", "False")]
        [VisibleInListView(false)]
        [Size(512)]
        public string UrlGoogleMaps
        {
            get => urlGoogleMaps;
            set => SetPropertyValue(nameof(UrlGoogleMaps), ref urlGoogleMaps, value);
        }

        private string iFrameContent;
        [ModelDefault("AllowEdit", "False")]
        [Size(SizeAttribute.Unlimited)]
        public string IFrameContent
        {
            get => iFrameContent;
            set => SetPropertyValue(nameof(IFrameContent), ref iFrameContent, value);
        }





        [System.ComponentModel.DisplayName("Latitudine (°'\")")]
        public string LatitudineSessagesimale => ToSessagesimale(Latitudine);

        [System.ComponentModel.DisplayName("Longitudine (°'\")")]
        public string LongitudineSessagesimale => ToSessagesimale(Longitudine);



        public string ToSessagesimale(double decimalDegrees)
        {
            var degrees = decimalDegrees;
            var minutes = ((decimalDegrees - (int)degrees) * 60);
            var seconds = ((minutes - (int)minutes)) * 60;
            return $"{(int)degrees}° {(int)minutes}' {(int)seconds}''";
        }
    }

}
