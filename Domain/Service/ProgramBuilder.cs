using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class ProgramBuilder
   {
      public Program BuildProgram(IEnumerable<MeasurementSetNode> measurementSetNodes)
      {
         var programNodes = ConnectNodes(measurementSetNodes).ToImmutableList();
         return new Program(programNodes);
      }

      private static IEnumerable<IProgramNode> ConnectNodes(IEnumerable<MeasurementSetNode> measurementSetNodes)
      {
         var previous = measurementSetNodes.First();
         yield return previous;
         foreach (var next in measurementSetNodes.Skip(1))
         {
            yield return GetConnector(previous, next);
            yield return next;
            previous = next;
         }
      }

      public static IProgramNode GetConnector(MeasurementSetNode previous, MeasurementSetNode next)
      {
         if (ReferenceEquals(previous.Tool, next.Tool))
            return new InterMeasurementSetNodeNode(previous, next);
         return new ChangeToolNode(previous, next);
      }
   }
}