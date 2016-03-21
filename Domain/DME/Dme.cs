namespace Domain
{
   public class Dme : IDme
   {
      public Dme(string name, ToolSet tools)
      {
         Name = name;
         Tools = tools;
      }

      public string Name { get; private set; }

      public ToolSet Tools { get; private set; }
   }
}