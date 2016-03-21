namespace Domain
{
   public class Feature
   {
      public Feature(string name, Point3D center, Direction3D direction, double size)
      {
         Id = new FeatureId();
         Name = name;
         Center = center;
         Direction = direction;
         Size = size;
      }

      public FeatureId Id { get; private set; }

      public string Name { get; private set; }

      public Point3D Center { get; private set; }

      public Direction3D Direction { get; private set; }

      public double Size { get; private set; }
   }
}