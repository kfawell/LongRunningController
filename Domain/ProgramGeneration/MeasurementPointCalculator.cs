using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class MeasurementPointCalculator : IMeasurementPointCalculator
   {
      public IImmutableList<Point3D> CalculatePoints(NodeInput nodeInput)
      {
         var count = nodeInput.MaximumPoints - 1;
         return Enumerable.Range(0, nodeInput.MaximumPoints)
            .Select(i => CalculatePoint(nodeInput.Feature, i, count))
            .ToImmutableList();
      }

      private static Point3D CalculatePoint(Feature feature, int i, int count)
      {
         return feature.Center + feature.Direction * (feature.Size * i / count);
      }
   }
}