using System;

namespace DaysOfWeek
{
    class DaysOfWeek
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string day = "";

            switch (num)
            {
                case 1:
                    day = "Monday";
                    break;

                case 2:
                    day = "Tuesday";
                    break;

                case 3:
                    day = "Wednesday";
                    break;

                case 4:
                    day = "Thursday";
                    break;

                case 5:
                    day = "Friday";
                    break;

                case 6:
                    day = "Saturday";
                    break;

                case 7:
                    day = "Sunday";
                    break;

                default:
                    day = "Error";
                    break;
            }

            Console.WriteLine(day);
        }
    }
}
