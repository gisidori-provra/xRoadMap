using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]
    [Persistent("Incidenti")]
    [NavigationItem("Incidenti")]

    public class IncidenteStradale:EventoPuntuale,IEventoOnRoad
    {
        public IncidenteStradale(Session session):base(session)
        {
            
        }

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


        Provincia provincia;
        Comune comune;
        DateTime data;

        public DateTime Data
        {
            get => data;
            set => SetPropertyValue(nameof(Data), ref data, value);
        }


        public Comune Comune
        {
            get => comune;
            set => SetPropertyValue(nameof(Comune), ref comune, value);
        }


        public Provincia Provincia
        {
            get => provincia;
            set => SetPropertyValue(nameof(Provincia), ref provincia, value);
        }

      

    }

    [NavigationItem("Impostazioni")]
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    public class Regione : XPCustomObject
    {
        public Regione(Session session) : base(session)
        { }

        string denominazione;

        string codiceIstat;

        [Key]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CodiceIstat
        {
            get => codiceIstat;
            set => SetPropertyValue(nameof(CodiceIstat), ref codiceIstat, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Denominazione
        {
            get => denominazione;
            set => SetPropertyValue(nameof(Denominazione), ref denominazione, value);
        }



    }

    [NavigationItem("Impostazioni")]
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    public class Provincia : XPCustomObject
    {
        public Provincia(Session session) : base(session)
        { }

        Regione regione;
        string denominazione;

        string codiceIstat;

        [Key]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CodiceIstat
        {
            get => codiceIstat;
            set => SetPropertyValue(nameof(CodiceIstat), ref codiceIstat, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Denominazione
        {
            get => denominazione;
            set => SetPropertyValue(nameof(Denominazione), ref denominazione, value);
        }

        
        public Regione Regione
        {
            get => regione;
            set => SetPropertyValue(nameof(Regione), ref regione, value);
        }
    }


    [NavigationItem("Impostazioni")]
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    public class Comune : XPCustomObject
    {
        public Comune(Session session) : base(session)
        { }

        Provincia provincia;
        string denominazione;

        string codiceIstat;

        [Key]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CodiceIstat
        {
            get => codiceIstat;
            set => SetPropertyValue(nameof(CodiceIstat), ref codiceIstat, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Denominazione
        {
            get => denominazione;
            set => SetPropertyValue(nameof(Denominazione), ref denominazione, value);
        }

        
        public Provincia Provincia
        {
            get => provincia;
            set => SetPropertyValue(nameof(Provincia), ref provincia, value);
        }

    }


}
