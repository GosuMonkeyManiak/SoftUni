using System;

namespace Volleyball
{
    class Volleyball
    {
        static void Main(string[] args)
        {
            string typeYear = Console.ReadLine();
            int celebrate = int.Parse(Console.ReadLine());
            int weekend = int.Parse(Console.ReadLine());

            int sofiaWeekends = 48 - weekend;
            double notWork = sofiaWeekends * (3.0 / 4.0);
            double celebratePlay = celebrate * (2.0 / 3.0);
            double totalplay = notWork + celebratePlay + weekend;

            if (typeYear == "leap")
            {
                double bonus = totalplay * 0.15;
                totalplay += bonus;
                totalplay = Math.Floor(totalplay);
            }
            else
            {
                totalplay = Math.Floor(totalplay);
            }

            Console.WriteLine(totalplay);
        }
    }
}
