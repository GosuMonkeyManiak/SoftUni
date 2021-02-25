using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string typeOfAnimal = Console.ReadLine();
                if (typeOfAnimal == "Beast!")
                {
                    break;
                }
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                if (string.IsNullOrEmpty(info[0]) ||
                    int.Parse(info[1]) < 0 ||
                    string.IsNullOrEmpty(info[2]))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (typeOfAnimal)
                {
                    case "cat":
                        animals.Add(new Cat(info[0], int.Parse(info[1]), info[2]));
                        break;

                    case "dog":
                        animals.Add(new Dog(info[0], int.Parse(info[1]), info[2]));
                        break;

                    case "frog":
                        animals.Add(new Frog(info[0], int.Parse(info[1]), info[2]));
                        break;

                    case "kitten":
                        animals.Add(new Kitten(info[0], int.Parse(info[1])));
                        break;

                    case "tomcat":
                        animals.Add(new Tomcat(info[0], int.Parse(info[1])));
                        break;
                }
            }


            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                animal.ProduceSound();
            }
        }
    }
}
