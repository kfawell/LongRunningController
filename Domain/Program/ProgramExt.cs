using System.Collections.Generic;
using System.Linq;

namespace Domain
{
   public static class ProgramExt
   {
      public static double Duration(this IPath path)
      {
         return path.PathCommands.Select(i => i.Location).Duration();
      }

      public static double Duration(this IEnumerable<Point3D> points)
      {
         var previous = points.First();
         var duration = 0.0;
         foreach (var point in points.Skip(1))
         {
            duration += (point - previous).Norm;
            previous = point;
         }
         return duration;
      }
   }
}