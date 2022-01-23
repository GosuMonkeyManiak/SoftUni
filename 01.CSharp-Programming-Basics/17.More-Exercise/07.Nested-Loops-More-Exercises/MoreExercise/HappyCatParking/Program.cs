namespace HappyCatParking
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double sumToPay = 0;

            for (int i = 1; i <= days; i++)
            {
                double currentDay = 0;

                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        currentDay += 2.50;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        currentDay += 1.25;
                    }
                    else
                    {
                        currentDay += 1;
                    }
                }

                Console.WriteLine($"Day: {i} - {currentDay:f2} leva");
                sumToPay += currentDay;
            }

            Console.WriteLine($"Total: {sumToPay:f2} leva");
        }
    }
}
