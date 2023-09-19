using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xMap.Persistent.Base
{
    public interface IXPGeometry:DevExpress.Xpo.IXPObject
    {
        Geometry Shape { get; set; }
        int Oid { get; }

    }


}
