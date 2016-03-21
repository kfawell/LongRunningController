using System.Collections.Immutable;
using System.Linq;

namespace Domain
{
   public class DesignModelBuilder
   {
      private readonly IRandomNumberGenerator _random;

      public DesignModelBuilder(IRandomNumberGenerator random)
      {
         _random = random;
      }

      public DesignModel BuilDesignModel(int partSize, int featureCount)
      {
         var features = Enumerable.Range(0, featureCount)
            .Select(i => BuildFeature(partSize, i))
            .ToImmutableList();
         return new DesignModel("DesignModel", features);
      }

      private Feature BuildFeature(int partSize, int index)
      {
         var name = "Feature" + index;
         var center = _random.Generate(Point3D.Origin, partSize);
         var direction = _random.Generate(Point3D.Origin, 1)
            .ToVector3D().ToDirection3D();
         var featureSize = _random.Generate(0, partSize);
         return new Feature(name, center, direction, featureSize);
      }
   }
}