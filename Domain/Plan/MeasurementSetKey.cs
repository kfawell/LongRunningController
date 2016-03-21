namespace Domain
{
   public class MeasurementSetKey
   {
      private readonly FeatureId _featureId;
      private readonly int _minimumPoints;
      private readonly int _maximumPoints;

      public MeasurementSetKey(Feature feature, MeasurementSet measurementSet)
      {
         _featureId = feature.Id;
         _minimumPoints = measurementSet.MinimumPoints;
         _maximumPoints = measurementSet.MaximumPoints;
      }

      protected bool Equals(MeasurementSetKey other)
      {
         return _featureId.Equals(other._featureId)
            && _minimumPoints == other._minimumPoints
            && _maximumPoints == other._maximumPoints;
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != GetType()) return false;
         return Equals((MeasurementSetKey) obj);
      }

      public override int GetHashCode()
      {
         unchecked
         {
            var hashCode = _featureId.GetHashCode();
            hashCode = (hashCode * 397) ^ _minimumPoints;
            hashCode = (hashCode * 397) ^ _maximumPoints;
            return hashCode;
         }
      }
   }
}