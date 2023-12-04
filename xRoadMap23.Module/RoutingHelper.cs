using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using DevExpress.XtraMap;
using DevExpress.XtraPrinting.Shape;
using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.Index.HPRtree;
using NetTopologySuite.Utilities;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using xRoadMap.Module.BusinessObjects;
using xRoadMap.Module.BusinessObjects.RoadDataModel;

namespace xRoadMap.Module
{
    public static class RoutingHelper
    {

        public static Strada FindNearest(GeoPoint point,IObjectSpace os)
        {
            Strada st = null;
            double min = double.PositiveInfinity;
            var strade = os.GetObjects<Strada>();
            var c = ToETRS89(new NetTopologySuite.Geometries.Coordinate(point.Longitude, point.Latitude));
            var p = new NetTopologySuite.Geometries.Point(c);
            foreach (var item in strade)
            {
                if (item.Shape == null)
                    continue;

                var distOp = new NetTopologySuite.Operation.Distance.DistanceOp(item.Shape,p);
                var dist = distOp.Distance();
                if (dist<min)
                {
                    min = dist;
                    st = item;
                }
            }
            
            return st;
        }


        public static string ToSessagesimale(double decimalDegrees)
        {
            var degrees = decimalDegrees;
            var minutes = ((decimalDegrees - (int)degrees) * 60);
            var seconds = ((minutes - (int)minutes)) * 60;
            return $"{(int)degrees}°{(int)minutes}'{(int)seconds}''";
        }

        public static double FromSessagesimale(string sessagesimale)
        {
            int degrees=0;
            int minutes=0;
            int seconds=0;
            var tokens = sessagesimale.Split(' ','°','\'');

            if (tokens.Length>0)
                int.TryParse(tokens[0].Trim(' ','°'),out degrees);
            if (tokens.Length>1)
                int.TryParse(tokens[1].Trim(' ', '\''),out minutes);
            if (tokens.Length>2)
                int.TryParse(tokens[2].Trim(' ', '\''), out seconds);

            return degrees + minutes/60 + seconds/3600 ;

        }

        public static string GetChilometricaFromMeasure(Strada st,double m)
        {
            if (m == double.NaN)
                return null;


            int km = (int)Math.Truncate(m/1000)*1000;
            int offset = (int)Math.Round(m - km,MidpointRounding.AwayFromZero);

            if (st != null)
            {
                if (offset > 500)
                {
                    offset -= 1000;
                    km += 1000;
                }
                var cp = st.Cippi.OrderBy(c => c.Misura).FirstOrDefault();      //Cippo iniziale
                if (cp != null)
                {
                    offset += (int)cp.Misura;
                    if (cp.Offset != null)
                        offset += (int)Math.Round(cp.Misura - cp.Offset.Measure, MidpointRounding.AwayFromZero);
                    while (offset >= 1000)
                    {
                        offset -= 1000;
                        km += 1000;
                    }
                    while (offset < 0)
                    {
                        offset += 1000;
                        km -= 1000;
                    }
                }

                cp = st.Cippi.OrderByDescending(c => c.Misura).FirstOrDefault(c => c.Misura <= km);
                if (cp != null)
                {
                    if (cp.Offset != null)
                        offset += (int)Math.Round(cp.Misura - cp.Offset.Measure, MidpointRounding.AwayFromZero);
                    while (offset >= 1000)
                    {
                        offset -= 1000;
                        km += 1000;
                    }
                    while (offset < 0)
                    {
                        offset += 1000;
                        km -= 1000;
                    }
                }
            }
            return $"{km/1000:F0}{offset:+000;-000}";
        }

        public static double GetMeasureFromChilometrica(IEventoOnRoad ev, string chilometrica)
        {
            if (ev == null)
                throw new ArgumentNullException(nameof(ev));

            double cippo = 0;
            double offset = 0;
            if (chilometrica == null)
                return 0;
            var pos = chilometrica.IndexOfAny("+-".ToCharArray());
            if (pos == -1)
            {
                if (!double.TryParse(chilometrica, out cippo))
                    return double.NaN;
            }
            else
            {
                if (!double.TryParse(chilometrica.Substring(0, pos), out cippo) ||
                    !double.TryParse(chilometrica.Substring(pos), out offset))         //Offset con segno
                    return double.NaN;
            }
            var cp = ev.Strada?.Cippi.FirstOrDefault(c => c.Misura == cippo * 1000);
            if (cp != null)
            {
                if (cp.Offset != null)
                    return cp.Offset.Measure + offset;
            }
            return offset+cippo*1000;
        }


        public static void LocalizzaPuntualeSuKilometrica(IEnumerable<EventoPuntuale> events)
        {
            foreach (var item in events)
            {
                item.M = RoutingHelper.GetMeasureFromChilometrica(item as IEventoOnRoad, item.Km);
                var ev = (IEventoOnRoad)item;
                var line = ev.Strada.Shape;
                var loc = NetTopologySuite.LinearReferencing.LengthLocationMap.GetLocation(line, ev.M);
                var seg = loc.GetSegment(line);
                ev.Shape = new NetTopologySuite.Geometries.Point(seg.P0);
            }
        }

        public static void LocalizzaPuntualeSuXY(IEnumerable<EventoPuntuale> events)
        {

            foreach (var item in events)
            {
                LocalizzaPuntualeSuXY(item);
            }
        }

        public static void LocalizzaPuntualeSuXY(EventoPuntuale item)
        {
            var ev = (IEventoOnRoad)item;
            var point = ev.Shape as NetTopologySuite.Geometries.Point;
            item.Km = LocalizzaPuntualeSuXY(ev.Strada,point.Coordinate, out double m);
            item.M = m;
        }

        public static string LocalizzaPuntualeSuXY(Strada st, NetTopologySuite.Geometries.Coordinate point,out double m)
        {
            m = 0;
            var line = st.Shape;
            var loc = NetTopologySuite.LinearReferencing.LocationIndexOfPoint.IndexOf(line, point);
            m = NetTopologySuite.LinearReferencing.LengthLocationMap.GetLength(line, loc);
            var g1 = new NetTopologySuite.Geometries.Point(point);
            var dist = NetTopologySuite.Operation.Distance.DistanceOp.Distance(line, g1);
            if (dist < 50)
            {
                var km = GetChilometricaFromMeasure(st, m);
                return km;
            }
            return null;
        }

        public static double GetBearing(Strada st,NetTopologySuite.Geometries.Coordinate point)
        {
            var line = st.Shape;
            var loc = NetTopologySuite.LinearReferencing.LocationIndexOfPoint.IndexOf(line, point);
            return loc.GetSegment(line).Angle;
        }

        public static void LocalizzaLineareSuXY(IEnumerable<EventoLineare> events)
        {
            foreach (var item in events)
            {
                var ev = (IEventoLineareOnRoad)item;
                var line = ev.Strada.Shape;
                var subLine = ev.Shape;
                var loc = new NetTopologySuite.LinearReferencing.LocationIndexOfLine(line);
                
                var ndx = loc.IndicesOf(subLine);
                item.M = NetTopologySuite.LinearReferencing.LengthLocationMap.GetLength(line, ndx[0]);
                item.MFine = NetTopologySuite.LinearReferencing.LengthLocationMap.GetLength(line, ndx[1]);
                item.Km = GetChilometricaFromMeasure(ev.Strada, item.M);
                item.KmFine = GetChilometricaFromMeasure(ev.Strada, item.MFine);
            }


        }

        public static void LocalizzaLineareSuKilometrica(IEnumerable<EventoLineare> events)
        {
            //string gpName = "MakeLineRouteEventLayer";
            //UpdateEventTableLineare(events);
            //CallGPService(gpName, events);
            //UpdateShapeLine(events);
            //UpdateLineCoordinates(events);

            foreach (var item in events)
            {
                item.M = RoutingHelper.GetMeasureFromChilometrica(item as IEventoOnRoad, item.Km);
                if (string.IsNullOrEmpty(item.KmFine))
                    item.MFine = 9999999;
                else
                    item.MFine = RoutingHelper.GetMeasureFromChilometrica(item as IEventoOnRoad, item.KmFine);

                var ev = (IEventoLineareOnRoad)item;
                var line = ev.Strada.Shape;
                var loc1 = NetTopologySuite.LinearReferencing.LengthLocationMap.GetLocation(line, ev.M);
                var loc2 = NetTopologySuite.LinearReferencing.LengthLocationMap.GetLocation(line, ev.MFine);
                var seg = NetTopologySuite.LinearReferencing.ExtractLineByLocation.Extract(line,loc1,loc2);
                ev.Shape = seg;
                UpdateLineCoordinate(item);
            }
        }

        private static void UpdateShapeLine(IEnumerable<EventoLineare> events)
        {
            if (events.Count() == 0)
                return;
            var session = events.First().Session;

            foreach (var ev in events)
            {
                var shp = session.FindObject<LayerEventoLineare>(new DevExpress.Data.Filtering.BinaryOperator(nameof(LayerEventoLineare.Evento), ev.Oid));
                if (shp != null)
                    ev.Shape = shp.Shape;
            }
        }

        private static void UpdateKmLineare(IEnumerable<EventoLineare> events)
        {
            if (events.Count() == 0)
                return;
            var session = events.First().Session;

            foreach (IEventoLineareOnRoad ev in events)
            {
                var shp = session.FindObject<EventTable>(new DevExpress.Data.Filtering.BinaryOperator(nameof(EventTable.Evento), ev.Oid));
                if (shp != null)
                {
                    ev.M = shp.M;
                    ev.MFine = shp.MFine;
                    ev.Km = GetChilometricaFromMeasure(ev.Strada, ev.M);
                    ev.KmFine = GetChilometricaFromMeasure(ev.Strada, ev.MFine);
                }
            }

        }

        private static void UpdateKmPuntuale(IEnumerable<EventoPuntuale> events)
        {
            if (events.Count() == 0)
                return;
            var session = events.First().Session;

            foreach (IEventoOnRoad ev in events)
            {
                var shp = session.FindObject<EventTable>(new DevExpress.Data.Filtering.BinaryOperator(nameof(EventTable.Evento), ev.Oid));
                if (shp != null)
                {
                    ev.M = shp.M;
                    ev.Km = GetChilometricaFromMeasure(ev.Strada, ev.M);
                }
            }

        }

        private static void UpdateEventTableLineare(IEnumerable<EventoLineare> events)
        {
            if (events.Count() == 0)
                return;
            var session = events.First().Session;

            var evTab = new XPCollection<EventTable>(session);

            foreach (var item in evTab.ToList())
            {
                item.Delete();
            }

            var lay = new XPCollection<LayerEventoLineare>(session);
            foreach (var item in lay.ToList())
            {
                item.Delete();
            }

            foreach (IEventoLineareOnRoad item in events)
            {
                evTab.Add(new EventTable(session) { Evento = item.Oid,M = item.M,MFine = item.MFine,Strada = item.Strada });
            }

            session.CommitTransaction();

        }

        private static void UpdateEventLayer(Session session, IEnumerable<IEventoOnRoad> events)
        {
            if (events.Count() == 0)
                return;

            var evTab = new XPCollection<LayerEventoPuntuale>(session);

            foreach (var item in evTab.ToList())
            {
                item.Delete();
            }
            session.CommitTransaction();

            foreach (IEventoOnRoad item in events)
            {
                evTab.Add(new LayerEventoPuntuale(session) { Evento = item.Oid, Shape = item.Shape,Strada = item.Strada});
            }

            session.CommitTransaction();
        }


        public static void LocatePointAlongRoute(IEnumerable<EventoPuntuale> events)
        {
            string gpName = "LocatePointAlongRoute";
            if (events.Count() == 0)
                return;
            var session = events.First().Session;
            UpdateEventLayer(session,events);
            CallGPService(gpName, events);
            UpdateKmPuntuale(events);
            UpdatePointCoordinates(events);
        }

        public static void LocateLineAlongRoute(IEnumerable<EventoLineare> events)
        {
            string gpName = "LocateLineAlongRoute";
            if (events.Count() == 0)
                return;
            var session = events.First().Session;
            UpdateEventLayer(session, events);
            CallGPService(gpName, events);
            UpdateKmLineare(events);
            UpdateLineCoordinates(events);
        }

        /// <summary>
        /// Trasforma coordinate da ETRS89 a WGS84
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static void UpdatePointCoordinates(IEnumerable<EventoPuntuale> events)
        {
            foreach (var ev in events)
            {
                UpdatePointCoordinate(ev);
            }
        }


        public static void UpdatePointCoordinate(EventoPuntuale ev)
        {
            NetTopologySuite.Geometries.Point shp = ev.Shape as NetTopologySuite.Geometries.Point;
            if (shp == null)
                return;

            ev.X = shp.X;
            ev.Y = shp.Y;
            //ev.Z = shp.Z;
            //ev.M = shp.M;
            var c = ToWGS84(shp.Coordinate);
            ev.Longitudine = c.X;
            ev.Latitudine = c.Y;
        }

        public static void UpdateLineCoordinates(IEnumerable<EventoLineare> events)
        {
            foreach (var ev in events)
            {
                UpdateLineCoordinate(ev);
            }
        }

        public static void UpdateLineCoordinate(EventoLineare ev)
        {
            var shp = ev.Shape as NetTopologySuite.Geometries.LineString;
            if (shp == null)
                return;
            var first = shp.CoordinateSequence.First;
            ev.X = first.X;
            ev.Y = first.Y; 
            var c = ToWGS84(first);
            ev.Longitudine = c.X;
            ev.Latitudine = c.Y;

            var last = shp.CoordinateSequence.Last;
            ev.XFine = last.X;
            ev.YFine = last.Y;
            c = ToWGS84(last);
            ev.LongitudineFine = c.X;
            ev.LatitudineFine = c.Y;
        }

        /// <summary>
        /// Trasforma coordinate da ETRS89 a WGS84
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static NetTopologySuite.Geometries.Coordinate ToWGS84(NetTopologySuite.Geometries.Coordinate point)
        {
            //CoordinateSystemFactory csFact = new CoordinateSystemFactory();
            CoordinateTransformationFactory ctFact = new CoordinateTransformationFactory();

            //ICoordinateSystem utm35ETRS = csFact.CreateFromWkt(
            //        "PROJCS[\"ETRS89 / ETRS-TM35\",GEOGCS[\"ETRS89\",DATUM[\"D_ETRS_1989\",SPHEROID[\"GRS_1980\",6378137,298.257222101]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.017453292519943295]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"latitude_of_origin\",0],PARAMETER[\"central_meridian\",27],PARAMETER[\"scale_factor\",0.9996],PARAMETER[\"false_easting\",500000],PARAMETER[\"false_northing\",0],UNIT[\"Meter\",1]]");

            string wkt = @"PROJCS[""ETRS89 / UTM zone 32N"",GEOGCS[""ETRS89"",DATUM[""European_Terrestrial_Reference_System_1989"",SPHEROID[""GRS 1980"",6378137,298.257222101,AUTHORITY[""EPSG"",""7019""]],TOWGS84[0,0,0,0,0,0,0],AUTHORITY[""EPSG"",""6258""]],PRIMEM[""Greenwich"",0,AUTHORITY[""EPSG"",""8901""]],UNIT[""degree"",0.0174532925199433,AUTHORITY[""EPSG"",""9122""]],AUTHORITY[""EPSG"",""4258""]],PROJECTION[""Transverse_Mercator""],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",9],PARAMETER[""scale_factor"",0.9996],PARAMETER[""false_easting"",500000],PARAMETER[""false_northing"",0],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""Easting"",EAST],AXIS[""Northing"",NORTH],AUTHORITY[""EPSG"",""25832""]]";
            GeoAPI.CoordinateSystems.ICoordinateSystem etr89 =
                ProjNet.Converters.WellKnownText.CoordinateSystemWktReader.Parse(wkt, Encoding.ASCII) as GeoAPI.CoordinateSystems.ICoordinateSystem;
            var wgs84 = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;

            ICoordinateTransformation trans = ctFact.CreateFromCoordinateSystems(etr89, wgs84);
            var coordinate = new GeoAPI.Geometries.Coordinate(point.X, point.Y);

            var tpoint = trans.MathTransform.Transform(coordinate);

            return new NetTopologySuite.Geometries.Coordinate(tpoint.X, tpoint.Y);
        }

        /// <summary>
        /// Trasforma coordinate da ETRS89 a WGS84
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static NetTopologySuite.Geometries.Coordinate ToETRS89(NetTopologySuite.Geometries.Coordinate point)
        {
            //CoordinateSystemFactory csFact = new CoordinateSystemFactory();
            CoordinateTransformationFactory ctFact = new CoordinateTransformationFactory();

            //ICoordinateSystem utm35ETRS = csFact.CreateFromWkt(
            //        "PROJCS[\"ETRS89 / ETRS-TM35\",GEOGCS[\"ETRS89\",DATUM[\"D_ETRS_1989\",SPHEROID[\"GRS_1980\",6378137,298.257222101]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.017453292519943295]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"latitude_of_origin\",0],PARAMETER[\"central_meridian\",27],PARAMETER[\"scale_factor\",0.9996],PARAMETER[\"false_easting\",500000],PARAMETER[\"false_northing\",0],UNIT[\"Meter\",1]]");

            string wkt = @"PROJCS[""ETRS89 / UTM zone 32N"",GEOGCS[""ETRS89"",DATUM[""European_Terrestrial_Reference_System_1989"",SPHEROID[""GRS 1980"",6378137,298.257222101,AUTHORITY[""EPSG"",""7019""]],TOWGS84[0,0,0,0,0,0,0],AUTHORITY[""EPSG"",""6258""]],PRIMEM[""Greenwich"",0,AUTHORITY[""EPSG"",""8901""]],UNIT[""degree"",0.0174532925199433,AUTHORITY[""EPSG"",""9122""]],AUTHORITY[""EPSG"",""4258""]],PROJECTION[""Transverse_Mercator""],PARAMETER[""latitude_of_origin"",0],PARAMETER[""central_meridian"",9],PARAMETER[""scale_factor"",0.9996],PARAMETER[""false_easting"",500000],PARAMETER[""false_northing"",0],UNIT[""metre"",1,AUTHORITY[""EPSG"",""9001""]],AXIS[""Easting"",EAST],AXIS[""Northing"",NORTH],AUTHORITY[""EPSG"",""25832""]]";
            GeoAPI.CoordinateSystems.ICoordinateSystem etr89 =
                ProjNet.Converters.WellKnownText.CoordinateSystemWktReader.Parse(wkt, Encoding.ASCII) as GeoAPI.CoordinateSystems.ICoordinateSystem;
            var wgs84 = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;

            ICoordinateTransformation trans = ctFact.CreateFromCoordinateSystems(wgs84,etr89);
            var coordinate = new GeoAPI.Geometries.Coordinate(point.X, point.Y);

            var tpoint = trans.MathTransform.Transform(coordinate);

            return new NetTopologySuite.Geometries.Coordinate(tpoint.X, tpoint.Y);

        }



        private static void CallGPService(string gpName, IEnumerable<XPSTGeometry> events)
        {

            string gpUrl = $"http://srvsitarcgis:6080/arcgis/rest/services/publish/{gpName}/GPServer/{gpName}/execute";

            ////List<NetTopologySuite.Geometries.Point> points = new List<NetTopologySuite.Geometries.Point>(); 
            //string list = "";
            //foreach (var ev in events)
            //{
            //    list += $"{ev.Oid},";
            //}
            //list = list.Remove(list.Length - 1);
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var values = new[]
                    {
                        //new KeyValuePair<string, string>("Expression", $"OBJECTID IN ({list})"),
                        new KeyValuePair<string, string>("env:outSR", ""),
                        new KeyValuePair<string, string>("env:processSR", ""),
                        new KeyValuePair<string, string>("returnZ","false"),
                        new KeyValuePair<string, string>("returnM","false"),
                        new KeyValuePair<string, string>("returnTrueCurve","false"),
                        new KeyValuePair<string, string>("returnFeatureCollection","false"),
                        new KeyValuePair<string, string>("f", "json")
                    };

                    foreach (var keyValuePair in values)
                        content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);

                    var asyncPost = client.PostAsync(gpUrl, content);
                    asyncPost.Wait();
                    var response = asyncPost.Result;

                    var responseString = response.Content.ReadAsStringAsync();
                    responseString.Wait();
                    string outputJson = responseString.Result;
                    //var pointReponse = System.Text.Json.JsonSerializer.Deserialize<PointConvertM2XYResponse.Rootobject>(outputJson);
                    //if (pointReponse.results.Length == 1 && pointReponse.results[0].value.features.Length == 1)
                    //{
                    //    var point = pointReponse.results[0].value.features[0];
                    //    points.Add(new NetTopologySuite.Geometries.Point(point.geometry.x,point.geometry.y));
                    //}
                }
            }
        }

    }
}
