namespace Domain
{
   public interface ISimulatedAnnealingStrategy<T>
   {
      T GetStartingValue();

      T GetNextValue(T value);

      double GetEnergy(T value);
   }
}