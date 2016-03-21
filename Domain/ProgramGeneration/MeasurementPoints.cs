using System.Collections.Immutable;

namespace Domain
{
   public class MeasurementPoints
   {
      public MeasurementPoints(MeasurementSetKey measurementSetKey, IImmutableList<Point3D> points)
      {
         MeasurementSetKey = measurementSetKey;
         Points = points;
      }

      public MeasurementSetKey MeasurementSetKey { get; private set; }

      public IImmutableList<Point3D> Points { get; private set; }
   }
}