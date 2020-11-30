using System;

namespace Dishwasher
{
    class Dishwasher
    {
        static void Main(string[] args)
        {
            //inPut
            //one bottle 750ml
            //one dish 5ml
            //one pot 15ml
            //while until End
            //frist dishes
            //second dishes
            //thirt pots

            int bottes = int.Parse(Console.ReadLine());
            double ml = bottes * 750;

            bool flag = false;

            string numtext = Console.ReadLine();
            int count = 1;

            int countDishes = 0;
            int countPots = 0;

            while (numtext != "End")
            {
                int num = int.Parse(numtext);

                if (count % 3 == 0)
                {
                    double neededMlPot = num * 15;
                    ml -= neededMlPot;
                    countPots += num;
                }
                else
                {
                    double needeMlDishes = num * 5;
                    ml -= needeMlDishes;
                    countDishes += num;
                }

                if (ml < 0)
                {
                    flag = true;
                    break;
                }

                numtext = Console.ReadLine();
                count++;
            }

            if (flag)
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(ml)} ml. more necessary!");
            }
            else
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{countDishes} dishes and {countPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {ml} ml.");
            }
        }
    }
}
