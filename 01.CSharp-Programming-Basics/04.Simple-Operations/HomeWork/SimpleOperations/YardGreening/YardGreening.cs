using System;

namespace YardGreening
{
    class YardGreening
    {
        static void Main(string[] args)
        {
            double squareMeters = double.Parse(Console.ReadLine());

            double allSum = squareMeters * 7.61;
            double discount = 0.18 * allSum;

            double finalSum = allSum - discount;

            Console.WriteLine($"The final price is: {finalSum:f2} lv.");
            Console.WriteLine($"The discount is: {discount:f2} lv.");
        }
    }
}
