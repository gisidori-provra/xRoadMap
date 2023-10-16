using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Module.BusinessObjects
{
    [Persistent("SIT.FOGLI")]
    public class FoglioCatastale:XPSTGeometry
    {
        public FoglioCatastale(Session session):base(session)
        {

        }

        private string comune;
        private string sezione;
        private string allegato;
        private string sviluppo;

        private int foglio;
        public int Foglio
        {
            get => foglio;
            set => SetPropertyValue(nameof(Foglio),ref foglio,value);
        }

        public string Sezione
        {
            get => sezione;
            set => SetPropertyValue(nameof(Sezione),ref sezione,value);
        }

        public string Allegato
        {
            get => allegato;
            set => SetPropertyValue(nameof(Allegato),ref allegato,value);   
        }

        public string Sviluppo
        {
            get => sviluppo;
            set => SetPropertyValue(nameof(Sviluppo),ref sviluppo,value);
        }



    }
}
