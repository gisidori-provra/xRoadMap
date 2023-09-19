using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]

    public class Accesso:EventoLineare,IEventoOnRoad
    {
        public Accesso(Session session):base(session)
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


        private TipoDestinazioneAccesso destinazione;
        public TipoDestinazioneAccesso Destinazione
        {
            get => destinazione;
            set => SetPropertyValue(nameof(Destinazione), ref destinazione, value);
        }
    }
}
