using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Headers;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Helpers;
using DevExpress.Xpo.Metadata;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Implementation;
using NetTopologySuite.IO;
using NetTopologySuite.LinearReferencing;

namespace xRoadMap.Module.BusinessObjects
{

    public interface IXPGeometry : DevExpress.Xpo.IXPObject
    {
        Geometry Shape { get; set; }
        int Oid { get; }

    }

    //https://community.devexpress.com/blogs/oliver/archive/2017/01/16/xpo-sql-server-and-spatial-data-revisited.aspx

    [NonPersistent]
    [DeferredDeletion(false)]
    [OptimisticLocking(false)]
    public abstract class XPSTGeometry : XPCustomObject, IXPGeometry
    {
        public XPSTGeometry() : base(Session.DefaultSession)
        {

        }

        public XPSTGeometry(Session session) : base(session)
        {

        }

        private int oid;
        [Key(AutoGenerate = true), DbType("int"),Persistent("OBJECTID")]
        [ModelDefault("AllowEdit","False")]
        [VisibleInListView(false)]
        [DevExpress.Xpo.DisplayName("Oid")]
        public int Oid
        {
            get => oid;
            set => SetPropertyValue<int>(nameof(Oid), ref oid, value);
        }

        private Geometry shape;
        [DbType("SDE.ST_GEOMETRY"), Persistent("SHAPE")]
        [ValueConverter(typeof(GeometryConverter))]
        public Geometry Shape
        {
            get => shape;
            set => SetPropertyValue(nameof(Shape), ref shape, value);
        }



    }


    public class CustomCoordinateSequenceFactory : CoordinateSequenceFactory
    {
        private Ordinates ordinates;
        public CustomCoordinateSequenceFactory(Ordinates ordinates)
        {
            this.ordinates = ordinates;
        }

        public override CoordinateSequence Create(Coordinate[] coordinates)
        {
            //return GeometryFactory.Default.CoordinateSequenceFactory.Create(coordinates);
            var dimensions = OrdinatesUtility.OrdinatesToDimension(Ordinates);
            var measures = OrdinatesUtility.OrdinatesToMeasures(Ordinates);
            return new CoordinateArraySequence(coordinates,dimensions ,measures);
        }

        public override CoordinateSequence Create(CoordinateSequence coordSeq)
        {
            return GeometryFactory.Default.CoordinateSequenceFactory.Create(coordSeq);
        }

        public override CoordinateSequence Create(int size, Ordinates ordinates)
        {
            return GeometryFactory.Default.CoordinateSequenceFactory.Create(size, ordinates);
        }
        public override CoordinateSequence Create(int size, int dimension, int measures)
        {
            return this.Create(size, this.Ordinates);
        }

        public new Ordinates Ordinates => ordinates;

    }

    public class GeometryConverter : ValueConverter
    {

        public static Geometry FromBinary(byte[] value, int srid = 25382)
        {
            WKBReader reader = new WKBReader();
            Geometry g = reader.Read(value);
            g.SRID = srid;

            return g;
        }
        public static Geometry FromWKT(string value, int srid = 25832)
        {

            //SqlChars str = new SqlChars(new SqlString((string)value));

            var wkt = (string)value;

            WKTReader reader = null;

            var tokens = new string(wkt.TakeWhile(c => c != '(').ToArray()).Split(' ');
            if (tokens.Length > 0)
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

            return g;

            //WKTWriter writer = WKTWriter.ForMicrosoftSqlServer();
            //var ss = writer.Write(g);
            //SqlChars str = new SqlChars(ss);
            //SqlGeometry s = SqlGeometry.STGeomFromText(str, 25832);


            //return s;
        }

        public override object ConvertFromStorageType(object value)
        {
            if (value == null)
                return value;
            if (!(value is string))
                throw new ArgumentException();

            var buff = (string)value;   // DevExpress.Persistent.Base.CompressionUtils.Decompress(new System.IO.MemoryStream((byte[])value)).ToArray();

            return GeometryConverter.FromWKT(buff);
        }

        public override object ConvertToStorageType(object value)
        {
            if (value == null)
                return value;
            
            if (!(value is Geometry))
                throw new ArgumentException();
            
            var geometry = value as Geometry;

            //return DevExpress.Persistent.Base.CompressionUtils.Compress(new System.IO.MemoryStream(geometry.AsBinary())).ToArray();

            return geometry.AsText();


        }
        public override Type StorageType
        {
            get { return typeof(string); }
        }
    }

}
