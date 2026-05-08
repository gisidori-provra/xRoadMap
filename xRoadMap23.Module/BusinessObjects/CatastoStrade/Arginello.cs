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
    public class Arginello:EventoLineare,IEventoOnRoad
    {
        public Arginello(Session session):base(session)
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

        double larghezzaDX;
        public double LarghezzaDX
        {
            get { return larghezzaDX; }
            set => SetPropertyValue(nameof(LarghezzaDX), ref larghezzaDX, value);

        }

        double larghezzaSX;
        public double LarghezzaSX
        {
            get { return larghezzaSX; }
            set => SetPropertyValue(nameof(LarghezzaSX), ref larghezzaSX, value);
        }


    }
}
