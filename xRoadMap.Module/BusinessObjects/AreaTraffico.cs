using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]
    [NavigationItem("Catasto Strade")]

    public class AreaTraffico : EventoSuStrada, IEventoOnRoad
    {
        public AreaTraffico(Session session) : base(session)
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
            set => SetPropertyValue(nameof(Strada), ref strada, value);
        }

        public override void SetStrada(Strada value)
        {
            Strada = value;
        }

        private string fDenominazione;
        public string Denominazione
        {
            get=> fDenominazione;
            set=>SetPropertyValue(nameof(Denominazione), ref fDenominazione, value);
        }

        private TipoAreaTraffico tipoAreaTraffico;
        public TipoAreaTraffico TipoAreaTraffico
        {
            get => tipoAreaTraffico;
            set => SetPropertyValue(nameof(TipoAreaTraffico), ref tipoAreaTraffico, value);
        }

        private bool corsieAccDec;
        [ToolTip("Corsie di acellerazione/decellerazione")]
        public bool CorsieAccDec
        {
            get => corsieAccDec;
            set => SetPropertyValue(nameof(CorsieAccDec), ref corsieAccDec, value); 
        }

    }
}
