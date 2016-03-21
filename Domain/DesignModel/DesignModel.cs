using System.Collections.Immutable;

namespace Domain
{
   public class DesignModel
   {
      public DesignModel(string name, double size, IImmutableList<Feature> features)
      {
         Name = name;
         Size = size;
         Features = features;
      }

      public string Name { get; private set; }

      public double Size { get; private set; }

      public IImmutableList<Feature> Features { get; private set; }
   }
}