namespace OnTimeExam
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());

            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinutes = int.Parse(Console.ReadLine());

            int examInMinutes = examMinutes + (examHour * 60);
            int arriveInMinutes = arriveMinutes + (arriveHour * 60);



            if (examInMinutes - arriveInMinutes < 0)
            {
                Console.WriteLine("Late");
                int timeAfterExamStart = arriveInMinutes - examInMinutes;

                if (timeAfterExamStart > 59)
                {
                    Console.WriteLine($"{timeAfterExamStart / 60}:{timeAfterExamStart % 60:d2} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{timeAfterExamStart} minutes after the start");
                }
            }
            else if (examInMinutes == arriveInMinutes)
            {
                Console.WriteLine("On time");
            }
            else if (examInMinutes - arriveInMinutes <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{examInMinutes - arriveInMinutes} minutes before the start");
            }
            else if (examInMinutes - arriveInMinutes > 30)
            {
                Console.WriteLine("Early");
                int remainTimeToExam = examInMinutes - arriveInMinutes;

                if (remainTimeToExam > 59)
                {
                    Console.WriteLine($"{remainTimeToExam / 60}:{remainTimeToExam % 60:d2} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{remainTimeToExam} minutes before the start");
                }
            }
        }
    }
}
