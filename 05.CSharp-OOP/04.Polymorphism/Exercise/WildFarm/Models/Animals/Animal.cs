using System;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;
        private Food food;

        protected Animal(string name, double weight, Food food)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
            this.food = food;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public double Weight
        {
            get => weight;
            protected set => weight = value;
        }

        public int FoodEaten
        {
            get => foodEaten;
            protected set => foodEaten = value;
        }

        public Food Food
        {
            get => food;
            private set => food = value;
        }

        protected void MessageForNotCorrectFood()
        {
            Console.WriteLine($"{this.GetType().Name} does not eat {Food.GetType().Name}!");
        }

        public abstract void ProducingSound();

        public abstract void Feed();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, ";
        }
    }
}