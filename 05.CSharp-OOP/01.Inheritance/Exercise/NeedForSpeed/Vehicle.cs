﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int hoursePower, double fuel)
        {
            HoursePower = hoursePower;
            Fuel = fuel;
            DefaultFuelConsumption = 1.25;
        }

        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption { get; set; }

        public double Fuel { get; set; }

        public int HoursePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= DefaultFuelConsumption * kilometers;
        }
    }
}
