using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int hoursePower, double fuel)
            : base(hoursePower, fuel)
        {
            DefaultFuelConsumption = 10;
        }
    }
}
