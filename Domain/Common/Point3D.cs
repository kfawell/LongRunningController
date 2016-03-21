using System.Collections.Immutable;

namespace Domain
{
    public struct Point3D
    {
       public Point3D(double x, double y, double z) : this()
       {
          X = x;
          Y = y;
          Z = z;
       }

       public double X { get; private set; }

       public double Y { get; private set; }

       public double Z { get; private set; }

       public Vector3D ToVector3D()
       {
          return new Vector3D(X, Y, Z);
       }

       public static Vector3D operator -(Point3D a, Point3D b)
       {
          return new Vector3D(b.X - a.X, b.Y - a.Y, b.Z - a.Z);
       }

       public static Point3D operator +(Point3D a, Vector3D b)
       {
          return new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
       }

       public static IImmutableList<Point3D> operator +(Point3D a, Point3D b)
       {
          return ImmutableList<Point3D>.Empty.Add(a).Add(b);
       }

       public static IImmutableList<Point3D> operator +(IImmutableList<Point3D> list, Point3D b)
       {
          return list.Add(b);
       }

       public static readonly Point3D Origin = new Point3D(0, 0, 0);
    }
}
