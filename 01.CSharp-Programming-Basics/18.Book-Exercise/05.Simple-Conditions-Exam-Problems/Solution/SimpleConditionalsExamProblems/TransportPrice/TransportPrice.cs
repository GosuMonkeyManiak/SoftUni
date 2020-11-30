using System;

namespace TransportPrice
{
    class TransportPrice
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string typeOfDay = Console.ReadLine();

            double price = 0.0;

            if (kilometers >= 100)
            {
                price = kilometers * 0.06;
            }
            else if (kilometers >= 20)
            {
                price = kilometers * 0.09;
            }
            else
            {
                price += 0.70;

                if (typeOfDay == "day")
                {
                    price += kilometers * 0.79;
                }
                else
                {
                    price += kilometers * 0.90;
                }
            }

            Console.WriteLine(price);
        }
    }
}
