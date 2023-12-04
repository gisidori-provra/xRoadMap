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
    public class DispositivoRitenuta:EventoLineare
    {
        public DispositivoRitenuta(Session session):base(session)
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


        private TipoDispositivoRitenuta tipologia;
        public TipoDispositivoRitenuta Tipologia
        {
            get => tipologia;
            set => SetPropertyValue(nameof(Tipologia), ref tipologia, value);
        }

        TipoMaterialeDispositivoRitenuta materiale;
        public TipoMaterialeDispositivoRitenuta Materiale
        {
            get => materiale;
            set => SetPropertyValue(nameof(Materiale),ref materiale, value);
        }

        ClassificazioneDispositivoRitenuta classificazione;
        public ClassificazioneDispositivoRitenuta Classificazione
        {
            get => classificazione;
            set => SetPropertyValue(nameof(Classificazione),ref classificazione, value);
        }

        double distanza;
        public double Distanza
        {
            get => distanza;
            set => SetPropertyValue(nameof(Distanza),ref distanza, value);
        }
    }
}
