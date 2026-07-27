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

    public class CentroAbitato:EventoSuStrada,IEventoOnRoad
    {
        public CentroAbitato(Session session):base(session)
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


        TipoClassificaFunzionale classificaFunzionale;
        private string nome;
        public string Nome
        {
            get => nome;
            set => SetPropertyValue(nameof(Nome), ref nome, value);
        }

        
        public TipoClassificaFunzionale ClassificaFunzionale
        {
            get => classificaFunzionale;
            set => SetPropertyValue(nameof(ClassificaFunzionale), ref classificaFunzionale, value);
        }
    }
}
