using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCatalogue
{
    class Catalog
    {
        private List<Car> cars;
        private List<Truck> trucks;

        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
        public List<Truck> Trucks
        {
            get { return this.trucks; }
            set { this.trucks = value; }
        }

        public Catalog()
        {
            this.cars = new List<Car>();
            this.trucks = new List<Truck>();
        }
    }
}
