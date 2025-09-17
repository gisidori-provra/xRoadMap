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
    public class Ciclabile:EventoLineare,IEventoOnRoad
    {
        public Ciclabile(Session session):base(session)
        {

        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Id_RER
        {
            get => iD_RER;
            set => SetPropertyValue(nameof(Id_RER), ref iD_RER, value);
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

        CiclabileStatoAgg statoAttuazione;
        string iD_RER;
        double larghezza;
        public double Larghezza
        {
            get { return larghezza; }
            set => SetPropertyValue(nameof(Larghezza), ref larghezza, value);

        }

        double lunghezza;
        public double Lunghezza
        {
            get { return lunghezza; }
            set => SetPropertyValue(nameof(Lunghezza), ref lunghezza, value);
        }

        private TipoCiclabile tipoCiclabile;
        public TipoCiclabile TipoCiclabile
        {
            get => tipoCiclabile;
            set => SetPropertyValue(nameof(TipoCiclabile), ref tipoCiclabile, value);
        }

        private SensoCiclabile senso;
        public SensoCiclabile Senso
        {
            get => senso;
            set => SetPropertyValue(nameof(Senso), ref senso, value);
        }

        [Persistent("Stato_AGG")]
        public CiclabileStatoAgg StatoAttuazione
        {
            get => statoAttuazione;
            set => SetPropertyValue(nameof(StatoAttuazione), ref statoAttuazione, value);
        }

        

    }
}
