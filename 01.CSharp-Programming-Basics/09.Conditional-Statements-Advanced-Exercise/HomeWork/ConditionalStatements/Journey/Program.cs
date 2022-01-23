namespace Journey
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string formatDestination = "Somewhere in {0}";
            string formatHoliday = "{0} - {1}";

            string result = string.Empty;

            if (budget <= 100)
            {
                result += string.Format(formatDestination, "Bulgaria") + Environment.NewLine;

                if (season == "summer")
                {
                    double moneyToSpend = budget * 0.3;
                    result += string.Format(formatHoliday, "Camp", $"{moneyToSpend:f2}");
                }
                else
                {
                    double moneyToSpend = budget * 0.7;
                    result += string.Format(formatHoliday, "Hotel", $"{moneyToSpend:f2}");
                }
            }
            else if (budget <= 1000)
            {
                result += string.Format(formatDestination, "Balkans") + Environment.NewLine;

                if (season == "summer")
                {
                    double moneyToSpend = budget * 0.4;
                    result += string.Format(formatHoliday, "Camp", $"{moneyToSpend:f2}");
                }
                else
                {
                    double moneyToSpend = budget * 0.8;
                    result += string.Format(formatHoliday, "Hotel", $"{moneyToSpend:f2}");
                }
            }
            else
            {
                result += string.Format(formatDestination, "Europe") + Environment.NewLine;

                double moneyToSpend = budget * 0.9;
                result += string.Format(formatHoliday, "Hotel", $"{moneyToSpend:f2}");
            }

            Console.WriteLine(result);
        }
    }
}
