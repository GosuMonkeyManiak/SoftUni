using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car()
        {

        }
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            Weight = weight;
        }
        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }
        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            Weight = weight;
            Color = color;
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

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        } //optional

        public string Color
        {
            get { return color; }
            set { color = value; }
        } //optional

        public override string ToString()
        {
            string empty = "n/a";
            string displacement = Engine.Displacement is 0 ? empty : Engine.Displacement.ToString();
            string efficiency = Engine.Efficiency is null ? empty : Engine.Efficiency.ToString();
            string weight = Weight is 0 ? empty : Weight.ToString();
            string color = Color is null ? empty : Color.ToString();

            return $"{Model}:\n  {Engine.Model}:\n    Power: {Engine.Power}\n    Displacement: {displacement}\n    Efficiency: {efficiency}\n  Weight: {weight}\n  Color: {color}";
        }
    }
}
