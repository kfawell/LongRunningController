namespace Domain
{
   public interface ITool
   {
      ToolId Id { get; }
      Point3D Location { get; }
   }
}