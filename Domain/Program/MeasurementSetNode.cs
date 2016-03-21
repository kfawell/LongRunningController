namespace Domain
{
   public class MeasurementSetNode : IProgramNode
   {
      public MeasurementSetNode(MeasurementSetId measurementSetId, ITool tool, Path<MeasurementPathCommand> path)
      {
         MeasurementSetId = measurementSetId;
         Tool = tool;
         Path = path;
         Duration = path.Duration();
      }

      public MeasurementSetId MeasurementSetId { get; private set; }

      public ITool Tool { get; private set; }

      public double Duration { get; private set; }

      public Path<MeasurementPathCommand> Path { get; private set; }
   }
}