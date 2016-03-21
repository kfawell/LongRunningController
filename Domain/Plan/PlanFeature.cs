using System.Collections.Generic;
using System.Collections.Immutable;

namespace Domain
{
   public class PlanFeature
   {
      public PlanFeature(string name, Feature feature)
         : this(new PlanFeatureId(), name, feature, ImmutableList<MeasurementSet>.Empty)
      {
      }

      private PlanFeature(PlanFeatureId id, string name, Feature feature, IImmutableList<MeasurementSet> measurementSets)
      {
         Id = id;
         Name = name;
         Feature = feature;
         MeasurementSets = measurementSets;
      }

      public PlanFeatureId Id { get; private set; }

      public string Name { get; private set; }

      public Feature Feature { get; private set; }

      public IImmutableList<MeasurementSet> MeasurementSets { get; private set; }

      public PlanFeature With(IEnumerable<MeasurementSet> measurementSets)
      {
         return new PlanFeature(Id, Name, Feature, measurementSets.ToImmutableList());
      }
   }
}