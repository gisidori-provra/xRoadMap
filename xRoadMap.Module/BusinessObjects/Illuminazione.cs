using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xRoadMap.Module.BusinessObjects;
using DevExpress.XtraExport.Xls;
using DevExpress.Persistent.Base;
using System.Diagnostics.Contracts;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]
    [NavigationItem("Catasto Strade")]

    public class Illuminazione:EventoSuStrada,IEventoOnRoad
    {
        public Illuminazione(Session session):base(session)
        {

        }
        public override void AfterConstruction()
        {
            TipoGeometria = TipoGeometriaEvento.Lineare;
            base.AfterConstruction();
        }


        [Association]
        public Strada Strada
        {
            get => strada;
            set => SetPropertyValue(nameof(Strada),ref strada,value);
        }

        public override void SetStrada(Strada value)
        {
            Strada = value;
        }

        double distanza;
        public double Distanza
        {
            get => distanza;
            set => SetPropertyValue(nameof(Distanza),ref distanza,value);
        }

        private TipoIlluminazione tipoIlluminazione;
        public TipoIlluminazione TipoIlluminazione
        {
            get => tipoIlluminazione;
            set => SetPropertyValue(nameof(TipoIlluminazione), ref tipoIlluminazione, value);
        }

        private TipoDisposizioneLampade tipoDisposizioneLampade;
        public TipoDisposizioneLampade TipoDisposizioneLampade
        {
            get => tipoDisposizioneLampade;
            set => SetPropertyValue(nameof(TipoDisposizioneLampade),ref tipoDisposizioneLampade,value);
        }



    }
}
