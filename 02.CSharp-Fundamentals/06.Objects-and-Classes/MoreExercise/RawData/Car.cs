using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public Car()
        {
            this.engine = new Engine();
            this.cargo = new Cargo();
        }
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
        {
            this.model = model;
            this.engine = new Engine(engineSpeed, enginePower);
            this.cargo = new Cargo(cargoWeight, cargoType);
        }
    }
}
