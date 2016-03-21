using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Domain
{
   public class ToolSet : IEnumerable<ITool>
   {
      public ToolSet(IImmutableList<ITool> tools)
      {
         Tools = tools;
      }

      public IImmutableList<ITool> Tools { get; private set; }

      public IEnumerator<ITool> GetEnumerator()
      {
         return Tools.GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
   }
}