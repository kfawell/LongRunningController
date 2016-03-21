using System.Collections.Immutable;

namespace Domain
{
   public class Plan
   {
      public Plan(IImmutableList<PlanFeature> planFeatures)
      {
         PlanFeatures = planFeatures;
      }

      public IImmutableList<PlanFeature> PlanFeatures { get; private set; }
   }
}