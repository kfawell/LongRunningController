using System;
using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class ToolCoverageCalculator : IToolCoverageCalculator
   {
      private readonly IRandomNumberGenerator _random;
      private static readonly PointError[] PointErrors = (PointError[])Enum.GetValues(typeof (PointError));

      public ToolCoverageCalculator(IRandomNumberGenerator random)
      {
         _random = random;
         MininumToolCoverage = -40.0;
         MaximumToolCoverage = 200.0;
      }

      public double MininumToolCoverage { get; set; }

      public double MaximumToolCoverage { get; set; }

      public ToolCoverage CalculateToolCoverage(NodeInput nodeInput, ITool tool, IImmutableList<Point3D> points)
      {
         var coverage = CalculateCoverage();
         var measurementPoints = CalculateMeasurementPoints(points, coverage);
         var measurablePoints = GetMeasureablePoints(measurementPoints);
         var nodeError = CalculateNodeError(nodeInput, measurablePoints.Count);
         return new ToolCoverage(tool, measurementPoints, measurablePoints, nodeError);
      }

      private double CalculateCoverage()
      {
         var range = MaximumToolCoverage - MininumToolCoverage;
         var rawCoverage = _random.Generate(MininumToolCoverage, range);
         return rawCoverage.Clip(0, 100);
      }

      private ImmutableList<MeasurementPoint> CalculateMeasurementPoints(IImmutableList<Point3D> points, double coverage)
      {
         return points
            .Select(point => CalcuateMeasuredPoint(point, coverage))
            .ToImmutableList();
      }

      private MeasurementPoint CalcuateMeasuredPoint(Point3D location, double coverage)
      {
         var measurable = _random.Generate(0, 1) <= coverage;
         var error = CalculatePointError(measurable);
         return new MeasurementPoint(location, error);
      }

      private static ImmutableList<MeasurementPoint> GetMeasureablePoints(ImmutableList<MeasurementPoint> measurementPoints)
      {
         return measurementPoints
            .Where(i => i.Error == PointError.None)
            .ToImmutableList();
      }

      private PointError CalculatePointError(bool measurable)
      {
         if (measurable)
            return PointError.None;
         return PointErrors[_random.Generate(1, PointErrors.Length - 1)];
      }

      private NodeError CalculateNodeError(NodeInput nodeInput, int measurablePoints)
      {
         if (nodeInput.MinimumPoints > measurablePoints)
            return NodeError.NotEnoughCoverage;
         return NodeError.None;
      }
   }
}