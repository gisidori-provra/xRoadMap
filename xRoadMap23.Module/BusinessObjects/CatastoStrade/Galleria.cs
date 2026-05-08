using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xRoadMap.Module.BusinessObjects;
using DevExpress.Persistent.Base;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]
    [NavigationItem("Catasto Strade")]

    public class Galleria:EventoLineare,IEventoOnRoad
    {
        public Galleria(Session session):base(session)
        {

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


        private TipoOperaGalleria tipoOpera;
        public TipoOperaGalleria TipoOpera
        {
            get => tipoOpera;
            set => SetPropertyValue(nameof(TipoOpera), ref tipoOpera, value);
        }

        private TipoIlluminazione illuminazioneImbocco;
        public TipoIlluminazione IlluminazioneImbocco
        {
            get => illuminazioneImbocco;
            set => SetPropertyValue(nameof(IlluminazioneImbocco),ref illuminazioneImbocco,value);
        }

        private TipoIlluminazione illuminazione;
        public TipoIlluminazione Illuminazione
        {
            get => illuminazione;
            set => SetPropertyValue(nameof(Illuminazione), ref illuminazione, value);
        }

        private TipoImpiantoVentilazione ventilazione;
        public TipoImpiantoVentilazione Ventilazione
        {
            get => ventilazione;
            set => SetPropertyValue(nameof(Ventilazione), ref ventilazione, value);
        }

        TipoStatoConservazione stato;
        public TipoStatoConservazione Stato
        {
            get => stato;
            set => SetPropertyValue(nameof(Stato),ref stato, value);
        }

        bool piazzole;
        public bool Piazzole
        {
            get => piazzole;
            set => SetPropertyValue(nameof(Piazzole),ref piazzole, value);
        }



    }
}
