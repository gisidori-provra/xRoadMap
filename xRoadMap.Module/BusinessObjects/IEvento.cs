using NetTopologySuite.Geometries;
using System;

namespace xRoadMap.Module.BusinessObjects
{
    public interface IEvento
    {
        int Oid { get; }
        DateTime? DataFine { get; set; }
        DateTime? DataInizio { get; set; }
        TipoPosizione Tipo { get; set; }
        Geometry Shape { get; set; }
        string Km { get; set; }
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
        double M { get; set; }
        double Latitudine { get; set; }
        double Longitudine { get; set; }
        int Event_id { get; set; }
        double Offset { get; set; }

    }

    public interface IEventoLineare : IEvento
    {
        string KmFine { get; set; }
        double XFine { get; set; }
        double YFine { get; set; }
        double ZFine { get; set; }
        double MFine { get; set; }
        double LatitudineFine { get; set; }
        double LongitudineFine { get; set; }

    }

    public interface IEventoOnRoad:IEvento,IConStrada
    {
        new Strada Strada { get; set; }
    }

    public interface IConStrada
    {
        Strada Strada { get; }
    }


    public interface IEventoLineareOnRoad:IEventoLineare,IEventoOnRoad
    {
    }


}
