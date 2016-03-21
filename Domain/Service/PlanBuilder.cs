using System;
using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class PlanBuilder
   {
      private readonly IRandomNumberGenerator _random;

      public PlanBuilder(IRandomNumberGenerator random)
      {
         _random = random;
         NumberOfMeasurementSets = 1;
      }

      public int NumberOfMeasurementSets { get; set; }

      public int MinimumPoints { get; set; }

      public int MaximumPoints { get; set; }

      public Plan BuildPlan(DesignModel designModel, int featureCount)
      {
         var planFeatures = Enumerable.Range(0, featureCount)
            .Select(index => BuildPlanFeature(index, designModel)).ToImmutableList();
         return new Plan(planFeatures);
      }

      private PlanFeature BuildPlanFeature(int index, DesignModel designModel)
      {
         var feature = designModel.Features[index % designModel.Features.Count];
         return BuildPlanFeature(feature);
      }

      public PlanFeature BuildPlanFeature(Feature feature)
      {
         var planFeature = new PlanFeature("Plan" + feature.Name, feature);
         var count = _random.Generate(1, NumberOfMeasurementSets);
         var measurementSets = Enumerable.Range(0, count)
            .Select(i => BuildMeasurementSet(planFeature)).ToImmutableList();
         return planFeature.With(measurementSets);
      }

      private MeasurementSet BuildMeasurementSet(PlanFeature planFeature)
      {
         int minimumPoints = _random.Generate(1, MinimumPoints);
         int maximumPoints = Math.Max(minimumPoints, _random.Generate(1, MaximumPoints));
         return new MeasurementSet(planFeature.Id, planFeature.Feature, minimumPoints, maximumPoints);
      }
   }
}