using System;

namespace Bills
{
    class Bills
    {
        static void Main(string[] args)
        {
            int month = int.Parse(Console.ReadLine());

            double electricityPerMonth = 0.0;
            double waterPerMonth = 0.0;
            double internetPerMonth = 0.0;
            double otherPerMonth = 0.0;

            double allElectricity = 0.0;
            double allWater = 0.0;
            double allInternet = 0.0;
            double allOther = 0.0;

            for (int i = 0; i < month; i++)
            {
                electricityPerMonth = double.Parse(Console.ReadLine());
                allElectricity += electricityPerMonth;

                waterPerMonth = 20;
                allWater += waterPerMonth;

                internetPerMonth = 15;
                allInternet += internetPerMonth;

                otherPerMonth = (electricityPerMonth + waterPerMonth + internetPerMonth) + ((electricityPerMonth + waterPerMonth + internetPerMonth) * 0.20);
                allOther += otherPerMonth;

            }

            Console.WriteLine($"Electricity: {allElectricity:f2} lv");
            Console.WriteLine($"Water: {allWater:f2} lv");
            Console.WriteLine($"Internet: {allInternet:f2} lv");
            Console.WriteLine($"Other: {allOther:f2} lv");
            Console.WriteLine($"Average: {(allElectricity + allWater + allInternet + allOther) / month:f2} lv");
        }
    }
}
