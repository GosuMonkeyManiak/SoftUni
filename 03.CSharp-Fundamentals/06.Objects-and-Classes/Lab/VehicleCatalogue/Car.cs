using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCatalogue
{
    class Car
    {
        private string brand;
        private string model;
        private int hoursePower;

        public string Brand
        {
            get { return this.brand; }
            set { this.brand = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int HoursePower
        {
            get { return this.hoursePower; }
            set { this.hoursePower = value; }
        }
    }
}
