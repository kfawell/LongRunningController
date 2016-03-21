using System;

namespace Domain
{
    public struct Vector3D
    {
       public Vector3D(double x, double y, double z) : this()
       {
          X = x;
          Y = y;
          Z = z;
          Norm = Math.Sqrt(X * X + Y * Y + Z * Z);
       }

       public double X { get; private set; }

       public double Y { get; private set; }

       public double Z { get; private set; }

       public double Norm { get; private set; }

       public Direction3D ToDirection3D()
       {
          return new Direction3D(X, Y, Z);
       }
    }
}
