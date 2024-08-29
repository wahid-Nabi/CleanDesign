

namespace CleanDesign.Application.Design_Principals
{
    public class Laws
    {
    }
   public interface IVehicle
    {
        double CalculateCarbonFootPrint(double averageFuelComsumed);
    }
   public class DieselVehicle : IVehicle
    {
        public
        const double DieselCarbonFootPrintEmissionFactor = 12.9;
        public double CalculateCarbonFootPrint(double averageFuelComsumed) => DieselCarbonFootPrintEmissionFactor * averageFuelComsumed;
    }
  public  class ElectricVehicle : IVehicle
    {
        public
        const double ElectricCarbonFootPrintEmissionFactor = 4.5;
        public double CalculateCarbonFootPrint(double averageFuelComsumed) => ElectricCarbonFootPrintEmissionFactor * averageFuelComsumed;
    }
   public class HybridVehicle : IVehicle
    {
        public
        const double HybridCarbonFootPrintEmissionFactor = 10.5;
        public double CalculateCarbonFootPrint(double averageFuelComsumed) => HybridCarbonFootPrintEmissionFactor * averageFuelComsumed;
    }
     public class CarbonFootPrintCalculator
    {
        public double TotalCarbonFootPrintEmission(List<IVehicle> vehicles, double averageFuelComsumed)
        {
            double totalCarbonFootPrintEmission = 0;
            foreach (var vehicle in vehicles)
            {
                totalCarbonFootPrintEmission += vehicle.CalculateCarbonFootPrint(averageFuelComsumed);
            }
            Console.WriteLine($"Total CO2 Emission is {totalCarbonFootPrintEmission}");
            return totalCarbonFootPrintEmission;
        }
    }
}
