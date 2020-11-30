using System;

namespace FitnessCard
{
    class FitnessCard
    {
        static void Main(string[] args)
        {
            double currenMoney = double.Parse(Console.ReadLine()); //have money
            char mOrf = char.Parse(Console.ReadLine()); // m or f
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double needMoney = 0.0;

            //Gym	Boxing	Yoga	Zumba	Dances	Pilates
            switch (sport)
            {
                case "Gym":
                    if (mOrf == 'm')
                    {
                        needMoney = 42;
                    }
                    else
                    {
                        needMoney = 35;
                    }
                    break;

                case "Boxing":
                    if (mOrf == 'm')
                    {
                        needMoney = 41;
                    }
                    else
                    {
                        needMoney = 37;
                    }
                    break;

                case "Yoga":
                    if (mOrf == 'm')
                    {
                        needMoney = 45;
                    }
                    else
                    {
                        needMoney = 42;
                    }
                    break;

                case "Zumba":
                    if (mOrf == 'm')
                    {
                        needMoney = 34;
                    }
                    else
                    {
                        needMoney = 31;
                    }
                    break;

                case "Dances":
                    if (mOrf == 'm')
                    {
                        needMoney = 51;
                    }
                    else
                    {
                        needMoney = 53;
                    }
                    break;

                case "Pilates":
                    if (mOrf == 'm')
                    {
                        needMoney = 39;
                    }
                    else
                    {
                        needMoney = 37;
                    }
                    break;
            }

            if (age <= 19)
            {
                double disocunt = needMoney * 0.2;
                needMoney -= disocunt;
            }

            if (needMoney <= currenMoney)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${needMoney - currenMoney:f2} more.");
            }

        }
    }
}
