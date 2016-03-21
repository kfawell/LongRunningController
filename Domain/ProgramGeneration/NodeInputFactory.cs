using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class NodeInputFactory
   {
      public NodeInput Create(PlanFeature planFeature, MeasurementSet measurementSet, ToolSet toolSet)
      {
         return new NodeInput(planFeature.Feature, measurementSet, toolSet);
      }

      public IImmutableList<NodeInput> CreateNodeInputs(Plan plan, ToolSet toolSet)
      {
         return plan.PlanFeatures
            .Select(i => new NodeInput(i.Feature, i.MeasurementSets.First(), toolSet))
            .ToImmutableArray();
      }
   }
}