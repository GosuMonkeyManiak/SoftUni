using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
        private double airConditionerModifier;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double airConditionerModifier)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditionerModifier = airConditionerModifier;
        }

        protected double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > tankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        protected double FuelConsumption
        {
            get => fuelConsumption;
            set
            {
                fuelConsumption = value;
            }
        }

        protected double TankCapacity
        {
            get => tankCapacity;
            set
            {
                tankCapacity = value;
            }
        }

        protected double AirConditionerModifier
        {
            get => airConditionerModifier;
            set
            {
                airConditionerModifier = value;
            }
        }

        public void Drive(double distance)
        {
            double requiredFuel = distance * (FuelConsumption + airConditionerModifier);

            if (requiredFuel > FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
                return;
            }

            FuelQuantity -= requiredFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void ReFuel(double liters)
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

            FuelQuantity += liters;
        }

        
        
        public override string ToString()
        {
            return $"{this.GetType().Name}: {fuelQuantity:f2}";
        }
    }
}