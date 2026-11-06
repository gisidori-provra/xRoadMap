using DevExpress.Xpo.Metadata;
using Microsoft.SqlServer.Types;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Xpo
{
    public class MSSqlSpatialConverter : ValueConverter
    {
        public static Geometry FromBinary(byte[] value, int srid)
        {
            WKBReader reader = new WKBReader();
            Geometry g = reader.Read(value);
            g.SRID = srid;

            return g;
        }

        public static Geometry FromSQLGeometry(SqlGeometry geometry)
        {
            // this mechanism persists the srid to SQL Server - 
            // better than using WKT because it doesn't contain srid at all
            var buffer = geometry.STAsBinary().Buffer;
            var srid = (int) geometry.STSrid;
            return FromBinary(buffer, srid);
        }

        public static Geometry FromWKT(string value, int srid)
        {

            //SqlChars str = new SqlChars(new SqlString((string)value));

            var wkt = (string)value;

            WKTReader reader = null;

            var tokens = new string(wkt.TakeWhile(c => c != '(').ToArray()).Split(' ');
            if (tokens.Length > 1)
            {
                switch (tokens[1])
                {
                    case "M":
                        reader = new WKTReader(new NetTopologySuite.NtsGeometryServices(new CustomCoordinateSequenceFactory(Ordinates.XYM)));
                        break;
                    case "Z":
                        reader = new WKTReader(new NetTopologySuite.NtsGeometryServices(new CustomCoordinateSequenceFactory(Ordinates.XYZ)));
                        break;
                    case "ZM":
                        reader = new WKTReader(new NetTopologySuite.NtsGeometryServices(new CustomCoordinateSequenceFactory(Ordinates.XYZM)));
                        break;
                    default:
                        break;
                }
            }
            if (reader == null)
                reader = new WKTReader();
            Geometry g = reader.Read((string)value);
            g.SRID = srid;
            if (g.IsValid == false)
                g = g.Buffer(0);
            
            return g;

            //WKTWriter writer = WKTWriter.ForMicrosoftSqlServer();
            //var ss = writer.Write(g);
            //SqlChars str = new SqlChars(ss);
            //SqlGeometry s = SqlGeometry.STGeomFromText(str, 25832);


            //return s;
        }

        public static SqlGeometry ToSQLGeometry(Geometry geom)
        {
            //WKTWriter writer = new WKTWriter();
            //var buffer = writer.Write(geom);
            //var bytes = new SqlChars(buffer);
            //return SqlGeometry.STGeomFromText(bytes, geom.SRID);

            WKBWriter writer = new WKBWriter();
            var buffer = writer.Write(geom);
            var bytes = new SqlBytes(buffer);
            return SqlGeometry.STGeomFromWKB(bytes, geom.SRID);

        }

        #region ValueConverter

        public override object ConvertFromStorageType(object value)
        {
            // We're ignoring the request to convert here, knowing that the loaded
            // object is already the correct type because SqlClient returns it 
            // that way.
            if (value is SqlGeometry geom)
            {
                return FromSQLGeometry(geom);
            }
            return value;
        }

        public override object ConvertToStorageType(object value)
        {
            if (value == null) return null;

            var geom = value as Geometry;
            if (geom != null)
                return ToSQLGeometry(geom).Serialize();

            return value;

        }
        public override Type StorageType
        {
            get { return typeof(byte[]); }
        }

        #endregion
    }

}
