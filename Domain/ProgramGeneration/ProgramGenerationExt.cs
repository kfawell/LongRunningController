namespace Domain
{
   public static class ProgramGenerationExt
   {
      public static bool HasError(this MeasurementSetNodeResult measurementSetNodeResult)
      {
         return measurementSetNodeResult.NodeError != NodeError.None;
      }
   }
}