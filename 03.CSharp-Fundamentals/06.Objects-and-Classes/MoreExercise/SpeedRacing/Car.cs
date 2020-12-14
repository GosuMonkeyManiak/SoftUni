using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        private string model;
        private double fuelAmount;
        private double consumptionPerKilometer;
        private double traveledDistance = 0;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }
        public double ConsumptionPerKilometer
        {
            get { return this.consumptionPerKilometer; }
            set { this.consumptionPerKilometer = value; }
        }
        public double TraveledDistance
        {
            get { return this.traveledDistance; }
        }

        public Car()
        {

        }
        public Car(string model, double fuelAmount, double comsumption)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.consumptionPerKilometer = comsumption;
        }

        public bool MovingCar(double amountOfKilometers)
        {
            double allConsumpFuel = amountOfKilometers * this.consumptionPerKilometer;

            if (allConsumpFuel <= this.fuelAmount)
            {
                this.fuelAmount -= allConsumpFuel;
                this.traveledDistance += amountOfKilometers;
                return true;
            }

            return false;
        }
    }
}
