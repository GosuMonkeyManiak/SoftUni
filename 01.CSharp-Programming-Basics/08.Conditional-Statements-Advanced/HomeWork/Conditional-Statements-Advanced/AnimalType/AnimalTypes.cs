using System;

namespace AnimalType
{
    class AnimalTypes
    {
        static void Main(string[] args)
        {
            //2.	crocodile, tortoise, snake -> reptile
            //3.others->unknown

            string animalName = Console.ReadLine();
            string animalType = "";

            switch (animalName)
            {
                case "dog":
                    animalType = "mammal";
                    break;

                case "crocodile":
                case "tortoise":
                case "snake":
                    animalType = "reptile";
                    break;

                default:
                    animalType = "unknown";
                    break;
            }

            Console.WriteLine(animalType);
        }
    }
}
