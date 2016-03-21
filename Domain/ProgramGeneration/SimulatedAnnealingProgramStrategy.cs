using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class SimulatedAnnealingProgramStrategy : ISimulatedAnnealingStrategy<ProgramGenerationResult>
   {
      private readonly IRandomNumberGenerator _random;
      private readonly IImmutableList<MeasurementSetNodeResult> _measurementSetNodeResults;
      private readonly ProgramBuilder _programBuilder;

      public SimulatedAnnealingProgramStrategy(IRandomNumberGenerator random, IImmutableList<MeasurementSetNodeResult> measurementSetNodeResults)
      {
         _random = random;
         _measurementSetNodeResults = measurementSetNodeResults.Where(i => !i.HasError()).ToImmutableArray();
         _programBuilder = new ProgramBuilder();
      }

      public ProgramGenerationResult GetStartingValue()
      {
         var shuffled = _measurementSetNodeResults.OrderBy(i => _random.NextDouble()).ToImmutableList();
         var measurementSetNodes = SortMeasurementSetNodes(shuffled).ToImmutableArray();
         var program = _programBuilder.BuildProgram(measurementSetNodes);
         return new ProgramGenerationResult(program, shuffled, measurementSetNodes);
      }

      private IEnumerable<MeasurementSetNode> SortMeasurementSetNodes(IImmutableList<MeasurementSetNodeResult> measurementSetNodeResults)
      {
         foreach (var measurementSetNodeResult in measurementSetNodeResults)
         {
            var measurementSetNodes = measurementSetNodeResult.MeasurementSetNodes;
            if (measurementSetNodes.Count == 1)
               yield return measurementSetNodes.First();
            var index = _random.Generate(0, measurementSetNodes.Count);
            yield return measurementSetNodes[index];
         }
      }

      public ProgramGenerationResult GetNextValue(ProgramGenerationResult programGenerationResult)
      {
         if (programGenerationResult.MeasurementSetNodes.Count == 0)
            return programGenerationResult;
         var measurementSetNodeResults = programGenerationResult.MeasurementSetNodeResults;
         if (programGenerationResult.MeasurementSetNodes.Count == 1)
            return ReplaceMeasurementSetNode(programGenerationResult, measurementSetNodeResults.Single());
         return GetNextValueHelper(programGenerationResult, measurementSetNodeResults);
      }

      private ProgramGenerationResult GetNextValueHelper(ProgramGenerationResult programGenerationResult,
         IImmutableList<MeasurementSetNodeResult> measurementSetNodeResults)
      {
         while (true)
         {
            var index0 = _random.Generate(0, measurementSetNodeResults.Count);
            var index1 = _random.Generate(0, measurementSetNodeResults.Count);
            if (index0 == index1)
            {
               var measurementSetNodeResult = measurementSetNodeResults[index0];
               var measurementSetNodes = measurementSetNodeResult.MeasurementSetNodes;
               if (measurementSetNodes.Count >= 2)
                  return ReplaceMeasurementSetNode(programGenerationResult, measurementSetNodeResult);
               continue;
            }
            return SwapNodes(programGenerationResult, index0, index1);
         }
      }

      private ProgramGenerationResult ReplaceMeasurementSetNode(
         ProgramGenerationResult programGenerationResult,
         MeasurementSetNodeResult measurementSetNodeResult)
      {
         var measurementSetNodes = measurementSetNodeResult.MeasurementSetNodes;
         if (measurementSetNodes.Count <= 1)
            return programGenerationResult;
         var nodeIndex = _random.Generate(0, measurementSetNodes.Count);
         var measurementSetNode = measurementSetNodeResult.MeasurementSetNodes[nodeIndex];
         var newNodes = measurementSetNodes.SetItem(nodeIndex, measurementSetNode);
         var program = _programBuilder.BuildProgram(newNodes);
         return programGenerationResult.With(program, newNodes);
      }

      private ProgramGenerationResult SwapNodes(ProgramGenerationResult programGenerationResult, int index0, int index1)
      {
         var measurementSetNodeResults = programGenerationResult.MeasurementSetNodeResults.Swap(index0, index1);
         var measurementSetNodes = programGenerationResult.MeasurementSetNodes.Swap(index0, index1);
         var program = _programBuilder.BuildProgram(measurementSetNodes);
         return new ProgramGenerationResult(program, measurementSetNodeResults, measurementSetNodes);
      }

      public double GetEnergy(ProgramGenerationResult programGenerationResult)
      {
         return programGenerationResult.Program.Duration;
      }
   }
}