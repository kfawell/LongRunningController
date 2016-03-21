using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class Path<T> : IPath where T : IPathCommand
   {
      public Path(IImmutableList<T> pathCommands)
      {
         PathCommands = pathCommands;
      }

      public IImmutableList<T> PathCommands { get; private set; }

      IEnumerable<IPathCommand> IPath.PathCommands
      {
         get { return PathCommands.Cast<IPathCommand>(); }
      }
   }
}