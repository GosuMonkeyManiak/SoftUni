using System;
using System.Collections.Generic;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = InPut();

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public static List<Animal> InPut()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] animalInfo = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string[] foodInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Food currentFood = ChooseFood(foodInfo[0], int.Parse(foodInfo[1]));
                Animal currentAnimal = ChooseAnimal(animalInfo, currentFood);

                animals.Add(currentAnimal);
                currentAnimal.ProducingSound();
                currentAnimal.Feed();
            }

            return animals;
        }

        public static Animal ChooseAnimal(string[] animalInfo, Food currentFood)
        {
            Animal animal = null;

            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            switch (type.ToLower())
            {
                case "hen":
                    animal = new Hen(name, weight, currentFood, double.Parse(animalInfo[3]));
                    break;

                case "owl":
                    animal = new Owl(name, weight, currentFood, double.Parse(animalInfo[3]));
                    break;

                case "mouse":
                    animal = new Mouse(name, weight, currentFood, animalInfo[3]);
                    break;

                case "cat":
                    animal = new Cat(name, weight, currentFood, animalInfo[3], animalInfo[4]);
                    break;

                case "dog":
                    animal = new Dog(name, weight, currentFood, animalInfo[3]);
                    break;

                case "tiger":
                    animal = new Tiger(name, weight, currentFood, animalInfo[3], animalInfo[4]);
                    break;
            }

            return animal;
        }

        private static Food ChooseFood(string foodName, int quantity)
        {
            Food food = null;

            switch (foodName.ToLower())
            {
                case "vegetable":
                    food = new Vegetable(quantity);
                    break;

                case "fruit":
                    food = new Fruit(quantity);
                    break;

                case "meat":
                    food = new Meat(quantity);
                    break;

                case "seeds":
                    food = new Seeds(quantity);
                    break;
            }

            return food;
        }
    }
}
