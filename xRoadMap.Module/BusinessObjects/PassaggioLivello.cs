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

    public class PassaggioLivello:EventoSuStrada    ,IEventoOnRoad
    {
        public PassaggioLivello(Session session):base(session)
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

        private int numeroBinari;
        public int NumeroBinari
        {
            get => numeroBinari;
            set => SetPropertyValue(nameof(NumeroBinari),ref numeroBinari,value);
        }


        private TipoPassaggioLivello tipoPassaggioLivello;
        public TipoPassaggioLivello TipoPassaggioLivello
        {
            get => tipoPassaggioLivello;
            set => SetPropertyValue(nameof(TipoPassaggioLivello), ref tipoPassaggioLivello, value);
        }
    }
}
