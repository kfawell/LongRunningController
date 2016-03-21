using System;
using System.Collections.Generic;

namespace Domain
{
   public class SimulatedAnnealing<T>
   {
      private readonly IRandomNumberGenerator _random;
      private readonly ISimulatedAnnealingStrategy<T> _annealingStrategy;

      public SimulatedAnnealing(IRandomNumberGenerator random, ISimulatedAnnealingStrategy<T> annealingStrategy)
      {
         _random = random;
         _annealingStrategy = annealingStrategy;
         StartingTemperature = 10000.0;
         CoolingRate = 0.997;
         AbsoluteTemperature = 1.0;
      }

      public double StartingTemperature { get; set; }

      public double CoolingRate { get; set; }

      public double AbsoluteTemperature { get; set; }

      public double CurrentEnergy { get; private set; }

      public double Temperature { get; private set; }

      public int Iteration { get; private set; }

      public IEnumerable<T> Anneal()
      {
         Iteration = 0;
         var currentValue = _annealingStrategy.GetStartingValue();
         CurrentEnergy = _annealingStrategy.GetEnergy(currentValue);
         yield return currentValue;

         Temperature = StartingTemperature;
         while (Temperature > AbsoluteTemperature)
         {
            var newValue = _annealingStrategy.GetNextValue(currentValue);
            var newEnergy = _annealingStrategy.GetEnergy(newValue);
            if (UseNewValue(newEnergy, CurrentEnergy, Temperature))
            {
               currentValue = newValue;
               CurrentEnergy = newEnergy;
               yield return currentValue;
            }
            Iteration++;
            Temperature *= CoolingRate;
         }
      }

      private bool UseNewValue(double newEnergy, double currentEnergy, double temperature)
      {
         if (newEnergy < currentEnergy)
            return true;
         if (newEnergy.Equals(currentEnergy))
            return false;
         var extraEnergy = currentEnergy - newEnergy;
         var probability = Math.Exp(-extraEnergy / temperature);
         if (probability > _random.NextDouble())
            return true;
         return false;
      }
   }
}