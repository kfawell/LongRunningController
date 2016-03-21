namespace Domain
{
    public struct Direction3D
    {
       public Direction3D(double x, double y, double z) : this()
       {
          var vector = new Vector3D(x, y, z);
          X = x / vector.Norm;
          Y = y / vector.Norm;
          Z = z / vector.Norm;
       }

       public double X { get; private set; }

       public double Y { get; private set; }

       public double Z { get; private set; }

       public static Vector3D operator *(Direction3D direction, double scale)
       {
          return new Vector3D(direction.X * scale, direction.Y * scale, direction.Z * scale);
       }
    }
}
