using System;

namespace PadawanEquipment
{
    class Equipment
    {
        static void Main(string[] args)
        {
            double hasMoney = double.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int freeBelt = studentCount / 6;
            int moreSabers = (int)(Math.Ceiling(0.1 * studentCount));

            double neededMoney = 0;
            neededMoney += (studentCount + moreSabers) * lightsabersPrice;
            neededMoney += studentCount * robesPrice;
            neededMoney += (studentCount - freeBelt) * beltPrice;

            if (neededMoney <= hasMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {neededMoney - hasMoney:f2}lv more.");
            }
        }
    }
}
