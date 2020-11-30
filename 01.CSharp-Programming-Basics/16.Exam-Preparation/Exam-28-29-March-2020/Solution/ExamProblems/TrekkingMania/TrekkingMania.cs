using System;

namespace TrekkingMania
{
    class TrekkingMania
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());

            int allPeople = 0;

            int peopleOnMusala = 0;
            int peopleOnMonblan = 0;
            int peopleOnKilimandjaro = 0;
            int peopleOnKTwo = 0;
            int peopleOnEverest = 0;

            for (int i = 0; i < group; i++)
            {
                int people = int.Parse(Console.ReadLine());
                allPeople += people;

                if (people <= 5)
                {
                    peopleOnMusala += people;
                }
                else if (people <= 12)
                {
                    peopleOnMonblan += people;
                }
                else if (people <= 25)
                {
                    peopleOnKilimandjaro += people;
                }
                else if (people <= 40)
                {
                    peopleOnKTwo += people;
                }
                else
                {
                    peopleOnEverest += people;
                }
            }

            Console.WriteLine($"{1.0 * peopleOnMusala / allPeople * 100:f2}%");
            Console.WriteLine($"{1.0 * peopleOnMonblan / allPeople * 100:f2}%");
            Console.WriteLine($"{1.0 * peopleOnKilimandjaro / allPeople * 100:f2}%");
            Console.WriteLine($"{1.0 * peopleOnKTwo / allPeople * 100:f2}%");
            Console.WriteLine($"{1.0 * peopleOnEverest / allPeople * 100:f2}%");
        }
    }
}
