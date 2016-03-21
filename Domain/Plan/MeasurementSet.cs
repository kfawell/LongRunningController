namespace Domain
{
   public class MeasurementSet
   {
      public MeasurementSet(PlanFeatureId planFeatureId, Feature feature, int minimumPoints, int maximumPoints)
      {
         Id = new MeasurementSetId();
         PlanFeatureId = planFeatureId;
         MinimumPoints = minimumPoints;
         MaximumPoints = maximumPoints;
         MeasurementSetKey = new MeasurementSetKey(feature, this);
      }

      public MeasurementSetId Id { get; private set; }

      public PlanFeatureId PlanFeatureId { get; private set; }

      public MeasurementSetKey MeasurementSetKey { get; private set; }

      public int MinimumPoints { get; private set; }

      public int MaximumPoints { get; private set; }
   }
}