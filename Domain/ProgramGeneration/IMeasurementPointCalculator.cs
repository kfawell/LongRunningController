using System.Collections.Immutable;

namespace Domain
{
   public interface IMeasurementPointCalculator
   {
      IImmutableList<Point3D> CalculatePoints(NodeInput nodeInput);
   }
}