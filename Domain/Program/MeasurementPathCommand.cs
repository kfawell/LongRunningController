namespace Domain
{
   public class MeasurementPathCommand : IPathCommand
   {
      public MeasurementPathCommand(Point3D location)
      {
         Location = location;
      }

      public Point3D Location { get; private set; }
   }
}