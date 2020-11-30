using System;

namespace Company
{
    class Company
    {
        static void Main(string[] args)
        {
            //intPut 
            //hour?
            //have some days?
            //10% of time worker have a education
            //one work day is 8 hours
            //workOvertime for 2 hours a day
            int neededHours = int.Parse(Console.ReadLine());
            int haveDays = int.Parse(Console.ReadLine());
            int workersWorkOvertime = int.Parse(Console.ReadLine());

            double workDays = haveDays - (haveDays * 0.1);
            double workHours = workDays * 8;
            double workOvertime = workersWorkOvertime * (2 * haveDays);
            workHours += workOvertime;

            if (workHours >= neededHours)
            {
                Console.WriteLine($"Yes!{Math.Floor(workHours - neededHours)} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Ceiling(neededHours - workHours)} hours needed.");
            }
        }
    }
}
