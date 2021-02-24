using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int hoursePower, double fuel)
            : base(hoursePower, fuel)
        {
            DefaultFuelConsumption = 3;
        }
    }
}
