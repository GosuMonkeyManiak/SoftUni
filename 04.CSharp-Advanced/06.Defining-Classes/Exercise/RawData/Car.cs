using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car()
        {
            
        }
        public Car(string model)
        {
            Model = model;
        }
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
            : this(model)
        {
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public double ATirePressure()
        {
            for (int i = 0; i < tires.Length; i++)
            {
                if (tires[i].Pressure > 0 && tires[i].Pressure < 1)
                {
                    return tires[i].Pressure;
                }
            }

            return 0;
        }
    }
}
