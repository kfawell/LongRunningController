namespace Domain
{
   public class NodeInput
   {
      public NodeInput(Feature feature, MeasurementSet measurementSet, ToolSet toolSet)
      {
         MinimumPoints = measurementSet.MinimumPoints;
         MaximumPoints = measurementSet.MaximumPoints;
         Feature = feature;
         ToolSet = toolSet;
         MeasurementSetId = measurementSet.Id;
      }

      public int MinimumPoints { get; private set; }

      public int MaximumPoints { get; private set; }

      public Feature Feature { get; private set; }

      public MeasurementSetId MeasurementSetId { get; private set; }

      public ToolSet ToolSet { get; private set; }

      protected bool Equals(NodeInput other)
      {
         return Feature.Id.Equals(other.Feature.Id)
            && MinimumPoints == other.MinimumPoints
            && MaximumPoints == other.MaximumPoints
            && ToolSet.Equals(other.ToolSet);
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != this.GetType()) return false;
         return Equals((NodeInput)obj);
      }

      public override int GetHashCode()
      {
         unchecked
         {
            var hashCode = Feature.Id.GetHashCode();
            hashCode = (hashCode * 397) ^ MinimumPoints;
            hashCode = (hashCode * 397) ^ MaximumPoints;
            hashCode = (hashCode * 397) ^ ToolSet.GetHashCode();
            return hashCode;
         }
      }
   }
}