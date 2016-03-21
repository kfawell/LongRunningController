namespace Domain
{
   public class Tool : ITool
   {
      public Tool(string name, Point3D location)
      {
         Id = new ToolId();
         Name = name;
         Location = location;
      }

      public ToolId Id { get; private set; }

      public string Name { get; private set; }

      public Point3D Location { get; private set; }
   }
}