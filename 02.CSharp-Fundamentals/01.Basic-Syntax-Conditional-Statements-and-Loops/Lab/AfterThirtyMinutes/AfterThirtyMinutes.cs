using System;

namespace AfterThirtyMinutes
{
    class AfterThirtyMinutes
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;

            if (minutes >= 60)
            {
                hour++;
                minutes -= 60;
            }

            if (hour >= 24)
            {
                hour = hour - 24;
            }

            Console.WriteLine($"{hour}:{minutes:d2}");
        }
    }
}
