using System.Linq;

namespace Domain
{
   public class InterMeasurementSetNodeNode : IProgramNode
   {
      public InterMeasurementSetNodeNode(MeasurementSetNode previous, MeasurementSetNode next)
      {
         Previous = previous;
         Next = next;
         Duration = (previous.Path.PathCommands.First().Location + next.Path.PathCommands.Last().Location).Duration();
      }

      public MeasurementSetNode Previous { get; private set; }

      public MeasurementSetNode Next { get; private set; }

      public double Duration { get; private set; }
   }
}