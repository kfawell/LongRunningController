using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class DmeBuilder
   {
      private readonly IRandomNumberGenerator _random;

      public DmeBuilder(IRandomNumberGenerator random)
      {
         _random = random;
      }

      public IDme BuildDme(string name, double size, int numberOfTools)
      {
         var tools = Enumerable.Range(0, numberOfTools)
            .Select(index => BuildTool(index, size))
            .ToImmutableArray();
         return new Dme(name, tools);
      }

      private ITool BuildTool(int index, double size)
      {
         var name = "Tool" + index;
         var location = CreateToolLocation(size);
         return new Tool(name, location);
      }

      private Point3D CreateToolLocation(double size)
      {
         var position = _random.Generate(0, 1) * size;
         var side = _random.Generate(0, 4);
         switch (side)
         {
            case 0:
               return new Point3D(0, position, 0);
            case 1:
               return new Point3D(size, position, 0);
            case 2:
               return new Point3D(position, 0, 0);
            default:
               return new Point3D(position, size, 0);
         }
      }
   }
}