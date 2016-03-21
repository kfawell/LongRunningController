using System.Collections.Generic;

namespace Domain
{
   public interface IPath
   {
      IEnumerable<IPathCommand> PathCommands { get; }
   }
}