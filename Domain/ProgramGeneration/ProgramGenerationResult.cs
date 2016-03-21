using System.Collections.Immutable;

namespace Domain
{
   public class ProgramGenerationResult
   {
      public ProgramGenerationResult(
         Program program,
         IImmutableList<MeasurementSetNodeResult> measurementSetNodeResults,
         IImmutableList<MeasurementSetNode> measurementSetNodes)
      {
         Program = program;
         MeasurementSetNodeResults = measurementSetNodeResults;
         MeasurementSetNodes = measurementSetNodes;
      }

      public Program Program { get; private set; }

      public IImmutableList<MeasurementSetNodeResult> MeasurementSetNodeResults { get; private set; }

      public IImmutableList<MeasurementSetNode> MeasurementSetNodes { get; private set; }

      public ProgramGenerationResult With(Program program, IImmutableList<MeasurementSetNode> measurementSetNodes)
      {
         return new ProgramGenerationResult(program, MeasurementSetNodeResults, measurementSetNodes);
      }
   }
}