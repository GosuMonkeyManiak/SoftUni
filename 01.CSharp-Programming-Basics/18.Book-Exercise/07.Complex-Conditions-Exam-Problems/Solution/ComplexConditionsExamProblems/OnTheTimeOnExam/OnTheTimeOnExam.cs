using System;

namespace OnTheTimeOnExam
{
    class OnTheTimeOnExam
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());

            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinutes = int.Parse(Console.ReadLine());

            int allExamMinutes = examHour * 60 + examMinutes;
            int allArriveMinutes = arriveHour * 60 + arriveMinutes;

            int remainMinutes = allExamMinutes - allArriveMinutes;

            if (remainMinutes == 0 || remainMinutes <= 30 && remainMinutes > 0)
            {
                Console.WriteLine("On time");

                if (remainMinutes != 0)
                {
                    Console.WriteLine($"{remainMinutes} minutes before the start");
                }
            }
            else if (remainMinutes > 30)
            {
                Console.WriteLine("Early");

                if (remainMinutes < 60)
                {
                    Console.WriteLine($"{remainMinutes} minutes before the start");
                }
                else
                {
                    int hour = remainMinutes / 60;
                    int minutes = remainMinutes % 60;

                    if (minutes < 10)
                    {
                        Console.WriteLine($"{hour}:0{minutes} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hour}:{minutes} hours before the start");
                    }
                }
            }
            else if (remainMinutes < 0)
            {
                Console.WriteLine("Late");

                if (remainMinutes > -60)
                {
                    Console.WriteLine($"{Math.Abs(remainMinutes)} minutes after the start");
                }
                else
                {
                    remainMinutes = Math.Abs(remainMinutes);

                    int hour = remainMinutes / 60;
                    int minutes = remainMinutes % 60;

                    if (minutes < 10)
                    {
                        Console.WriteLine($"{hour}:0{minutes} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hour}:{minutes} hours after the start");
                    }
                }
            }
        }
    }
}
