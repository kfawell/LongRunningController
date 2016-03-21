namespace Domain
{
   public class MeasurementPoint
   {
      public MeasurementPoint(Point3D location, PointError error)
      {
         Location = location;
         Error = error;
      }

      public Point3D Location { get; private set; }

      public PointError Error { get; private set; }
   }
}