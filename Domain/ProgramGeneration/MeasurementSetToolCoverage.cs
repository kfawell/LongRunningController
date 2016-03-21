using System.Collections.Immutable;

namespace Domain
{
   public class MeasurementSetToolCoverage
   {
      public MeasurementSetToolCoverage(MeasurementSetKey measurementSetKey, IImmutableList<ToolCoverage> toolCoverages)
      {
         MeasurementSetKey = measurementSetKey;
         ToolCoverages = toolCoverages;
      }

      public MeasurementSetKey MeasurementSetKey { get; private set; }

      public IImmutableList<ToolCoverage> ToolCoverages { get; private set; }
   }
}