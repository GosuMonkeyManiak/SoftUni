using System;

namespace Train
{
    class Train
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] peopleOnEachWagon = new int[wagons];

            int allPeople = 0;

            for (int i = 0; i < wagons; i++)
            {
                peopleOnEachWagon[i] = int.Parse(Console.ReadLine());
                allPeople += peopleOnEachWagon[i];
            }

            Console.WriteLine(string.Join(" ",peopleOnEachWagon));
            Console.WriteLine(allPeople);
        }
    }
}
