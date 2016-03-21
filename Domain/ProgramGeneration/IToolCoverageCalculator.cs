using System.Collections.Immutable;

namespace Domain
{
   public interface IToolCoverageCalculator
   {
      ToolCoverage CalculateToolCoverage(NodeInput nodeInput, ITool tool, IImmutableList<Point3D> points);
   }
}