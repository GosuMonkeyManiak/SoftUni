using System;

namespace Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            double vacationPrice = double.Parse(Console.ReadLine());
            double haveMoney = double.Parse(Console.ReadLine());

            int speedingDays = 0;
            int allDays = 0;

            while (haveMoney < vacationPrice && speedingDays < 5)
            {
                string action = Console.ReadLine(); // spend or save
                double actionMoney = double.Parse(Console.ReadLine());

                if (action == "spend")
                {
                    if (actionMoney > haveMoney)
                    {
                        haveMoney = 0;
                        speedingDays++;
                    }
                    else
                    {
                        haveMoney -= actionMoney;
                        speedingDays++;
                    }
                }
                else
                {
                    haveMoney += actionMoney;
                    speedingDays = 0;
                }

                allDays++;
            }

            if (speedingDays >= 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(allDays);
            }
            else
            {
                Console.WriteLine($"You saved the money for {allDays} days.");
            }
        }
    }
}
