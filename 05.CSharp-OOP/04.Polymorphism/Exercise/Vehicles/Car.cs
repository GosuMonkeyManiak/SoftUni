using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirConditionerModifier = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, CarAirConditionerModifier)
        {

        }
        
    }
}