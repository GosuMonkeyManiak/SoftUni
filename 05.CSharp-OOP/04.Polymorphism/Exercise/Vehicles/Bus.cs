using System;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionerModifier = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, BusAirConditionerModifier)
        {

        }

        public void TurnOnAir()
        {
            AirConditionerModifier = 1.4;
        }

        public void TurnOffAir()
        {
            AirConditionerModifier = 0;
        }

    }
}