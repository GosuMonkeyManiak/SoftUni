using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption; //per kilometer
        private double travelledDistance;

        public Car()
        {
            travelledDistance = 0;
        }
        public Car(string model, double fuelAmount, double fuelConsumption)
            : this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Drive(double kilometers)
        {
            if (fuelAmount - (kilometers * fuelConsumption) >= 0)
            {
                TravelledDistance += kilometers;
                fuelAmount -= kilometers * fuelConsumption;
                return;
            }

            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
