using System;

namespace TimePlusFifteenMinutes
{
    class TimePlusFifteenMinutes
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int allminutes = minutes;
            allminutes += hours * 60;

            allminutes += 15;

            int resultHours = allminutes / 60;
            if (resultHours == 24)
            {
                resultHours = 0;
            }
            else if (resultHours > 24)
            {
                int remain = resultHours - 23;
                resultHours = remain;
            }
            int resultMinutes = allminutes % 60;

            if (resultMinutes < 10)
            {
                Console.WriteLine($"{resultHours}:0{resultMinutes}");
            }
            else
            {
                Console.WriteLine($"{resultHours}:{resultMinutes}");
            }
        }
    }
}
