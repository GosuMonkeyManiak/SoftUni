using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCatalogue
{
    class Truck
    {
        private string brand;
        private string model;
        private double weight;

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
        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
    }

}
