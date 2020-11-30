using System;

namespace SoftUniReception
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //can help per hour
            int firstEmployeer = int.Parse(Console.ReadLine());
            int secondEmployeer = int.Parse(Console.ReadLine());
            int thirdEmployeer = int.Parse(Console.ReadLine());

            //all people
            int numberOfPeople = int.Parse(Console.ReadLine());

            int neededTime = 0;

            while (numberOfPeople > 0)
            {
                neededTime++;

                if (neededTime % 4 == 0)
                {
                    neededTime++;
                }

                int allAnswer = firstEmployeer + secondEmployeer + thirdEmployeer;

                numberOfPeople -= allAnswer;

            }



            Console.WriteLine($"Time needed: {neededTime}h.");
        }
    }
}
