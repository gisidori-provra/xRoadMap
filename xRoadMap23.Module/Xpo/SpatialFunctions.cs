using DevExpress.Data.Filtering;
using System;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using DevExpress.Xpo.DB;

namespace xRoadMap.Module.Xpo
{
    public class STContainsFunction : ICustomFunctionOperatorFormattable, ICustomFunctionOperatorBrowsable
    {
        public string Name => nameof(STContains);

        public int MinOperandCount => 2;

        public int MaxOperandCount => 2;

        public string Description => "ST_Contains takes two geometry objects and returns true if the first object completely contains the second; otherwise, it returns false";

        public FunctionCategory Category => FunctionCategory.All;

        public object Evaluate(params object[] operands)
        {
            return STContains((Geometry)operands[0], (Geometry)operands[1]);
        }

        public string Format(Type providerType, params string[] operands)
        {
            if (providerType == typeof(MySqlConnectionProvider))
                return $"SDE.ST_Contains({operands[0]},{operands[1]})";

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
