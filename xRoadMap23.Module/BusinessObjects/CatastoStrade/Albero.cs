using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{
    [MapInheritance(MapInheritanceType.OwnTable)]
    [NavigationItem("Catasto Strade")]
    public class Albero:EventoPuntuale,IEventoOnRoad
    {
        public Albero(Session session):base(session)
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

        private string codice;
        public string Codice
        {
            get => codice;
            set =>SetPropertyValue(nameof(Codice), ref codice, value);
        }

        [Association,Aggregated]
        public XPCollection<AllegatoAlbero> Allegati => GetCollection<AllegatoAlbero>();


    }

    public class AllegatoAlbero : Allegato
    {
        public AllegatoAlbero(Session session):base(session)
        {
            
        }

        Albero albero;
        [Persistent(@"REL_OBJECTID")]
        [Association]
        public Albero Albero
        {
            get { return albero; }
            set { SetPropertyValue(nameof(Albero), ref albero, value); }
        }


    }
}
