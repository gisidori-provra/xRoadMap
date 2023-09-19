using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Module.BusinessObjects;

namespace xRoadMap23.Module.BusinessObjects.RoadDataModel
{
    public struct Posizione
    {

        [DevExpress.Xpo.DisplayName("Tipo localizzazione")]
        public TipoPosizione Tipo;
        [DevExpress.Xpo.DisplayName("Progressiva chilometrica")]
        public string Km;
        [DevExpress.Xpo.DisplayName(@"Coord. X")]
        public double X;
        [DevExpress.Xpo.DisplayName(@"Coord. Y")]
        public double Y;
        [DevExpress.Xpo.DisplayName(@"Coord. Z")]
        public double Z;
        [DevExpress.Xpo.DisplayName(@"Coord. M")]
        public double M;
    }
}
