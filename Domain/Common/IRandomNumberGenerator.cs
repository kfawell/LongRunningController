namespace Domain
{
   public interface IRandomNumberGenerator
   {
      int Generate(int min, int range);

      double Generate(double min, double range);

      double NextDouble();
   }
}