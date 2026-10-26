using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraCharts;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Implementation;
using NetTopologySuite.IO;
using System.ComponentModel;

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
        [Browsable(false)]
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

        //[PersistentAlias("[SDE.st_leght(shape)]")]
        //public double Lenght => System.Convert.ToDouble(EvaluateAlias());
        [ModelDefault("DisplayFormat","n0")]
        [System.ComponentModel.DisplayName("Lunghezza geometrica")]
        public double Lenght => (Shape?.Length).GetValueOrDefault();

    //    [VisibleInListView(false)]
    //    [ModelDefault("DisplayFormat", "n0")]
    //    public double MIniziale => GetMeasureRange(Shape, Estremo.Inizio);

    //    [VisibleInListView(false)]
    //    [ModelDefault("DisplayFormat", "n0")]
    //    public double MFinale => GetMeasureRange(Shape, Estremo.Fine);

    //    enum Estremo
    //    {
    //        Inizio,
    //        Fine
    //    }

    //    static double GetMeasureRange(Geometry geometry, Estremo estremo)
    //    {
    //        var M = estremo == Estremo.Inizio ? double.PositiveInfinity : double.NegativeInfinity;

    //        if (geometry == null)
    //            return double.NaN;

    //        var stack = new Stack<Geometry>();
    //        stack.Push(geometry);

    //        while (stack.Count > 0)
    //        {
    //            var g = stack.Pop();

    //            switch (g)
    //            {
    //                case LineString ls:
    //                    ReadSequence(ls.CoordinateSequence, ref M,estremo);
    //                    break;

    //                case MultiLineString mls:
    //                    for (int i = 0; i < mls.NumGeometries; i++)
    //                        stack.Push(mls.GetGeometryN(i));
    //                    break;

    //                case GeometryCollection gc:
    //                    for (int i = 0; i < gc.NumGeometries; i++)
    //                        stack.Push(gc.GetGeometryN(i));
    //                    break;
    //            }
    //        }

    //        return M;

    //        static void ReadSequence(CoordinateSequence seq, ref double M,Estremo estremo)
    //        {
    //            if (seq == null || seq.Measures == 0)
    //                return;

    //            for (int i = 0; i < seq.Count; i++)
    //            {
    //                double m = seq.GetM(i);
    //                if (double.IsNaN(m))
    //                    continue;
    //                if (estremo == Estremo.Inizio && m < M) M = m;
    //                if (estremo == Estremo.Fine && m > M) M = m;
    //            }
    //        }
    //    }
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
            if (coordSeq == null)
                return Create(Array.Empty<Coordinate>());

            return new CoordinateArraySequence(
                coordSeq.ToCoordinateArray(),
                coordSeq.Dimension,
                coordSeq.Measures);
        }

        public override CoordinateSequence Create(int size, Ordinates ordinates)
        {
            int dimensions = OrdinatesUtility.OrdinatesToDimension(ordinates);
            int measures = OrdinatesUtility.OrdinatesToMeasures(ordinates);

            return Create(size, dimensions, measures);
        }

        public override CoordinateSequence Create(
            int size,
            int dimension,
            int measures)
        {
            return new CoordinateArraySequence(size, dimension, measures);
        }

        public new Ordinates Ordinates => ordinates;


    }

    public class SdeMeasureFilter : ICoordinateSequenceFilter
    {
        private readonly double _offset;
        private readonly double _scale;

        public SdeMeasureFilter(double offset, double scale)
        {
            _offset = offset;
            _scale = scale;
        }

        public bool Done => false;

        public bool GeometryChanged => true;

        public void Filter(CoordinateSequence seq, int index)
        {
            if (seq.Measures == 0)
                return;

            double m = seq.GetM(index);

            if (double.IsNaN(m))
                return;

            double correctedM = Math.Round(
                (m - _offset) * _scale, 4);

            seq.SetM(index, correctedM);
        }
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

            CustomCoordinateSequenceFactory sequenceFactory = null;
            var tokens = new string(wkt.TakeWhile(c => c != '(').ToArray()).Split(' ');
            if (tokens.Length > 0)
            {
                switch (tokens[1])
                {
                    case "M":
                        sequenceFactory = new CustomCoordinateSequenceFactory(Ordinates.XYM);
                        break;
                    case "Z":
                        sequenceFactory = new CustomCoordinateSequenceFactory(Ordinates.XYZ);
                        break;
                    case "ZM":
                        sequenceFactory = new CustomCoordinateSequenceFactory(Ordinates.XYZM);
                        break;
                    default:
                        break;
                }
            }
            // Servizi NetTopologySuite
            if (sequenceFactory == null)
                reader = new WKTReader();
            else
            {
                var services = new NtsGeometryServices(
                sequenceFactory,
                new PrecisionModel(),
                0);
                reader = new WKTReader(services);
            }

            Geometry g = reader.Read((string)value);
            g.Apply(new SdeMeasureFilter(offset: -100000, scale: 10000));
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
