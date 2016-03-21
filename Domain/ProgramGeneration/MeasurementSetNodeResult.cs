using System.Collections.Immutable;

namespace Domain
{
   public class MeasurementSetNodeResult
   {
      public MeasurementSetNodeResult(NodeError nodeError, IImmutableList<MeasurementSetNode> measurementSetNodes)
      {
         NodeError = nodeError;
         MeasurementSetNodes = measurementSetNodes;
      }

      public NodeError NodeError { get; private set; }

      public IImmutableList<MeasurementSetNode> MeasurementSetNodes { get; private set; }
   }
}