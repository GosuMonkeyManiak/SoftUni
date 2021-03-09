using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionerModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, TruckAirConditionerModifier)
        {

        }

        public override void ReFuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            double availableSpace = TankCapacity - FuelQuantity;

            if (liters > availableSpace)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }

            FuelQuantity += liters * 0.95;
        }
    }
}