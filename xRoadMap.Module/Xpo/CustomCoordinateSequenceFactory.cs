using DevExpress.Xpo.Metadata;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Implementation;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xRoadMap.Xpo
{

    class CustomCoordinateSequenceFactory : CoordinateSequenceFactory
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
            return new CoordinateArraySequence(coordinates, dimensions, measures);
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

}
