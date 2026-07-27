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

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]
    [NavigationItem("Catasto Strade")]

    public class Marciapiede:EventoSuStrada,IEventoOnRoad
    {
        public Marciapiede(Session session):base(session)
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

        double larghezza;
        public double Larghezza
        {
            get => larghezza;
            set => SetPropertyValue(nameof(Larghezza),ref larghezza,value);
        }

    }
}
