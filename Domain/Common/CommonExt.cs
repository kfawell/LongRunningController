using System;
using System.Collections.Immutable;

namespace Domain
{
   public static class CommonExt
   {
      public static double Clip(this double value, double min, double max)
      {
         return Math.Max(min, Math.Min(value, max));
      }

      public static Point3D Generate(this IRandomNumberGenerator random, Point3D center, double size)
      {
         var x = RandomCoordinate(random, center.X, size);
         var y = RandomCoordinate(random, center.Y, size);
         var z = RandomCoordinate(random, center.Z, size);
         return new Point3D(x, y, z);
      }

      private static double RandomCoordinate(IRandomNumberGenerator random, double center, double size)
      {
         return random.Generate(center, 2 * size) - size;
      }

      public static IImmutableList<T> Swap<T>(this IImmutableList<T> array, int index0, int index1)
      {
         var item = array[index0];
         array = array.SetItem(index0, array[index1]);
         return array.SetItem(index1, item);
      }
   }
}