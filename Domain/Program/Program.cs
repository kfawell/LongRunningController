using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class Program
   {
      public Program(IImmutableList<IProgramNode> programNodes)
      {
         Duration = programNodes.Sum(i => i.Duration);
         ProgramNodes = programNodes;
      }

      public double Duration { get; private set; }

      public IImmutableList<IProgramNode> ProgramNodes { get; private set; }
   }
}