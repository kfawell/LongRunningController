using System.Collections.Immutable;

namespace Domain
{
   public class ToolCoverage
   {
      public ToolCoverage(
         ITool tool,
         ImmutableList<MeasurementPoint> measurementPoints,
         ImmutableList<MeasurementPoint> measurablePoints,
         NodeError nodeError)
      {
         Tool = tool;
         PercentCoverage = (double)measurablePoints.Count / measurementPoints.Count;
         MeasurementPoints = measurementPoints;
         MeasurablePoints = measurablePoints;
         NodeError = nodeError;
      }

      public ITool Tool { get; private set; }

      public double PercentCoverage { get; private set; }

      public ImmutableList<MeasurementPoint> MeasurementPoints { get; private set; }

      public ImmutableList<MeasurementPoint> MeasurablePoints { get; private set; }

      public NodeError NodeError { get; private set; }
   }
}