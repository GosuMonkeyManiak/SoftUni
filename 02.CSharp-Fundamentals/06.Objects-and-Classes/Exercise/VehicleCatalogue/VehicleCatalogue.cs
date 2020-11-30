using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCatalogue
{
    class VehicleCatalogue
    {
        private string typeOfVehicle;
        private string modelOfVehicle;
        private string color;
        private double horsePower;

        public string TypeOfVehicle
        {
            get { return this.typeOfVehicle; }
            set { this.typeOfVehicle = value; }
        }
        public string ModelOfVehicle
        {
            get { return this.modelOfVehicle; }
            set { this.modelOfVehicle = value; }
        }
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public double HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }

        public VehicleCatalogue()
        {

        }

        public VehicleCatalogue(string typeOfVehicle, string model, string color, double horsePower)
        {
            this.typeOfVehicle = typeOfVehicle;
            this.modelOfVehicle = model;
            this.color = color;
            this.horsePower = horsePower;
        }
    }
}
