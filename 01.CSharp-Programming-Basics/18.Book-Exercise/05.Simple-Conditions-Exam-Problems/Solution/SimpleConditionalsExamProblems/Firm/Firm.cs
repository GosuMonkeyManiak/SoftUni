using System;

namespace Firm
{
    class Firm
    {
        static void Main(string[] args)
        {
            int needHours = int.Parse(Console.ReadLine());
            int haveDays = int.Parse(Console.ReadLine());
            int allWorkers = int.Parse(Console.ReadLine());

            double workDays = haveDays - (haveDays * 0.1);
            double workHours = workDays * 8 * allWorkers;
            double overWork = workDays * allWorkers * 2;
            workHours += overWork;
            workHours = Math.Floor(workHours);

            if (workHours >= needHours)
            {
                Console.WriteLine($"Yes!{workHours - needHours} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{needHours - workHours} hours needed.");
            }
        }
    }
}
