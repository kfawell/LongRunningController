using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class MeasurementSetNodeResultGenerator
   {
      private readonly IMeasurementPointCalculator _measurementPointCalculator;
      private readonly IToolCoverageCalculator _toolCoverageCalculator;

      public MeasurementSetNodeResultGenerator(IMeasurementPointCalculator measurementPointCalculator, IToolCoverageCalculator toolCoverageCalculator)
      {
         _measurementPointCalculator = measurementPointCalculator;
         _toolCoverageCalculator = toolCoverageCalculator;
      }

      public MeasurementSetNodeResult CalculateMeasurementSetNodeResult(IDme dme, NodeInput nodeInput)
      {
         var points = _measurementPointCalculator.CalculatePoints(nodeInput);
         var toolCoverages = CalculateToolCoverages(nodeInput, points);
         var measurementSetNodes = CreateMeasurementSetNodes(nodeInput, toolCoverages);
         var nodeError = CalculateNodeError(measurementSetNodes.Any());
         return new MeasurementSetNodeResult(nodeError, measurementSetNodes);
      }

      private ImmutableList<ToolCoverage> CalculateToolCoverages(NodeInput nodeInput, IImmutableList<Point3D> points)
      {
         return nodeInput.ToolSet
            .Select(tool => _toolCoverageCalculator.CalculateToolCoverage(nodeInput, tool, points)).ToImmutableList();
      }

      private IImmutableList<MeasurementSetNode> CreateMeasurementSetNodes(NodeInput nodeInput, ImmutableList<ToolCoverage> toolCoverages)
      {
         return toolCoverages
            .Where(i => i.NodeError == NodeError.None)
            .Select(i => CalculateMeasurementSetNode(nodeInput, i))
            .ToImmutableList();
      }

      private MeasurementSetNode CalculateMeasurementSetNode(NodeInput nodeInput, ToolCoverage toolCoverage)
      {
         var path = CreatePath(toolCoverage);
         return new MeasurementSetNode(nodeInput.MeasurementSetId, toolCoverage.Tool, path);
      }

      private static Path<MeasurementPathCommand> CreatePath(ToolCoverage toolCoverage)
      {
         var pathCommands = toolCoverage.MeasurementPoints
            .Select(i => new MeasurementPathCommand(i.Location)).ToImmutableList();
         return new Path<MeasurementPathCommand>(pathCommands);
      }

      private NodeError CalculateNodeError(bool hasMeasurmentSetNodes)
      {
         if (hasMeasurmentSetNodes)
            return NodeError.None;
         return NodeError.NotEnoughCoverage;
      }
   }
}