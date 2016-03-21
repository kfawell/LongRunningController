using System;

namespace Domain
{
   public class RandomNumberGenerator : IRandomNumberGenerator
   {
      private readonly Random _random;

      public RandomNumberGenerator(int? seed = null)
      {
         _random = seed.HasValue ? new Random(seed.Value) : new Random();
      }

      public int Generate(int min, int range)
      {
         return _random.Next(range) + min;
      }

      public double Generate(double min, double range)
      {
         return _random.NextDouble() * range + min;
      }

      public double NextDouble()
      {
         return _random.NextDouble();
      }
   }
}