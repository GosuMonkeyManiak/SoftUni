using System;

namespace HoneyWinterReserves
{
    class HoneyWinterReserves
    {
        static void Main(string[] args)
        {
            double neededHoneyForWinter = double.Parse(Console.ReadLine());

            double allHoneyIncome = 0.0;

            bool isWinterHasCome = false;

            while (allHoneyIncome < neededHoneyForWinter)
            {
                string beeName = Console.ReadLine();
                if (beeName == "Winter has come")
                {
                    isWinterHasCome = true;
                    break;
                }

                double incomePerBee = 0.0;

                for (int i = 0; i < 6; i++)
                {
                    double incomeHoney = double.Parse(Console.ReadLine());
                    allHoneyIncome += incomeHoney;
                    incomePerBee += incomeHoney;
                }

                if (incomePerBee < 0)
                {
                    Console.WriteLine($"{beeName} was banished for gluttony");
                }
            }

            if (allHoneyIncome >= neededHoneyForWinter)
            {
                Console.WriteLine($"Well done! Honey surplus {allHoneyIncome - neededHoneyForWinter:f2}.");
            }
            else
            {
                Console.WriteLine($"Hard Winter! Honey needed {neededHoneyForWinter - allHoneyIncome:f2}.");
            }
        }
    }
}
