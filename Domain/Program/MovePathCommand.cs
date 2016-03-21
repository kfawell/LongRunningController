namespace Domain
{
   public class MovePathCommand : IPathCommand
   {
      public MovePathCommand(Point3D location)
      {
         Location = location;
      }

      public Point3D Location { get; private set; }
   }
}