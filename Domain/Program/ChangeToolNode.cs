using System.Linq;

namespace Domain
{
   public class ChangeToolNode : IProgramNode
   {
      public ChangeToolNode(MeasurementSetNode previous, MeasurementSetNode next)
      {
         Previous = previous;
         Next = next;
         Duration =
            (previous.Path.PathCommands.First().Location
            + previous.Tool.Location
            + next.Tool.Location
            + previous.Path.PathCommands.Last().Location).Duration();
      }

      public MeasurementSetNode Previous { get; private set; }

      public MeasurementSetNode Next { get; private set; }

      public double Duration { get; private set; }
   }
}