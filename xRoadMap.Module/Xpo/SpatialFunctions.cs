using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using DevExpress.XtraRichEdit.Model;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using xRoadMap.Xpo;

namespace xRoadMap.Module.Xpo
{

    public class STMinMFunction : ICustomFunctionOperatorFormattable, ICustomFunctionOperatorBrowsable
    {
        public string Name => nameof(STMinM);

        public static readonly STMinMFunction Instance = new();
        public int MinOperandCount => 1;

        public int MaxOperandCount => 1;

        public string Description => "ST_MinM takes a geometry object and returns the minimum M value";

        public FunctionCategory Category => FunctionCategory.All;

        static STMinMFunction()
        {
            CriteriaOperator.RegisterCustomFunction(Instance);
        }
        private STMinMFunction() { }
        public static void Register()
        {
            // Forza l'esecuzione del costruttore statico.
            _ = Instance;
        }

        public object Evaluate(params object[] operands)
        {
            return STMinM((Geometry)operands[0]);
        }

        public string Format(Type providerType, params string[] operands)
        {
            if (providerType == typeof(OracleSDEConnectionProvider))
                return $"SDE.ST_MinM({operands[0]})";

            if (providerType == typeof(MSSqlSpatialProvider))
                return $"STMinM({operands[0]})";

            throw new NotSupportedException();

        }

        public Type ResultType(params Type[] operands)
        {
            return typeof(double);
        }

        public bool IsValidOperandCount(int count)
        {
            return count == 1;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type)
        {
            return type == typeof(Geometry);
        }

        public static double STMinM(Geometry geometry)
        {
            if (geometry == null || geometry.IsEmpty)
                return double.NaN;

            double min = double.NaN;

            void Visit(Geometry g)
            {
                if (g is LineString line)
                {
                    var seq = line.CoordinateSequence;

                    for (int i = 0; i < seq.Count; i++)
                    {
                        double m = seq.GetM(i);

                        if (!double.IsNaN(m) && m < min)
                            min = m;
                    }
                }
                else if (g is GeometryCollection collection)
                {
                    for (int i = 0; i < collection.NumGeometries; i++)
                        Visit(collection.GetGeometryN(i));
                }
            }

            Visit(geometry);
            return min;
        }
    }
    public class STMaxMFunction : ICustomFunctionOperatorFormattable, ICustomFunctionOperatorBrowsable
    {
        public string Name => nameof(STMaxM);

        public static readonly STMaxMFunction Instance = new();
        public int MinOperandCount => 1;

        public int MaxOperandCount => 1;

        public string Description => "ST_MaxM takes a geometry object and returns the maximum M value";

        public FunctionCategory Category => FunctionCategory.All;

        static STMaxMFunction()
        {
            CriteriaOperator.RegisterCustomFunction(Instance);
        }
        private STMaxMFunction() { }
        public static void Register()
        {
            // Forza l'esecuzione del costruttore statico.
            _ = Instance;
        }

        public object Evaluate(params object[] operands)
        {
            return STMaxM((Geometry)operands[0]);
        }

        public string Format(Type providerType, params string[] operands)
        {
            if (providerType == typeof(OracleSDEConnectionProvider))
                return $"SDE.ST_MaxM({operands[0]})";

            if (providerType == typeof(MSSqlSpatialProvider))
                return $"STMaxM({operands[0]})";

            throw new NotSupportedException();

        }

        public Type ResultType(params Type[] operands)
        {
            return typeof(double);
        }

        public bool IsValidOperandCount(int count)
        {
            return count == 1;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type)
        {
            return type == typeof(Geometry);
        }

        public static double STMaxM(Geometry geometry)
        {
            if (geometry == null || geometry.IsEmpty)
                return double.NaN;

            double max = double.NaN;

            void Visit(Geometry g)
            {
                if (g is LineString line)
                {
                    var seq = line.CoordinateSequence;

                    for (int i = 0; i < seq.Count; i++)
                    {
                        double m = seq.GetM(i);

                        if (!double.IsNaN(m) && m > max)
                            max = m;
                    }
                }
                else if (g is GeometryCollection collection)
                {
                    for (int i = 0; i < collection.NumGeometries; i++)
                        Visit(collection.GetGeometryN(i));
                }
            }

            Visit(geometry);
            return max;
        }

    }
    public class STContainsFunction : ICustomFunctionOperatorFormattable, ICustomFunctionOperatorBrowsable
    {
        public string Name => nameof(STContains);

        public static readonly STContainsFunction Instance = new();
        public int MinOperandCount => 2;

        public int MaxOperandCount => 2;

        public string Description => "ST_Contains takes two geometry objects and returns true if the first object completely contains the second; otherwise, it returns false";

        public FunctionCategory Category => FunctionCategory.All;

        static STContainsFunction()
        {
            CriteriaOperator.RegisterCustomFunction(Instance);
        }
        private STContainsFunction() { }
        public static void Register()
        {
            // Forza l'esecuzione del costruttore statico.
            _ = Instance;
        }

        public object Evaluate(params object[] operands)
        {
            return STContains((Geometry)operands[0], (Geometry)operands[1]);
        }

        public string Format(Type providerType, params string[] operands)
        {
            if (providerType == typeof(OracleSDEConnectionProvider))
                return $"SDE.ST_Contains({operands[0]},{operands[1]})";

            if (providerType == typeof(MSSqlSpatialProvider))
                return $"({operands[0]}).STContains({operands[1]}) = 1";

            throw new NotSupportedException();

        }

        public Type ResultType(params Type[] operands)
        {
            return typeof(bool);
        }

        public static bool STContains(NetTopologySuite.Geometries.Geometry g1,NetTopologySuite.Geometries.Geometry g2)
        {
            var res =  g1.Contains(g2);
            return res;
        }

        public bool IsValidOperandCount(int count)
        {
            return count == 2;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type)
        {
            return type == typeof(Geometry);
        }
    }
}
