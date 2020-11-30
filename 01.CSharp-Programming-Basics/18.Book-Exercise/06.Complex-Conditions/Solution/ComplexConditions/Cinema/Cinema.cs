using System;

namespace Cinema
{
    class Cinema
    {
        static void Main(string[] args)
        {
            string typeCinema = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            int allPeople = row * column;
            double price = 0.0;

            switch (typeCinema)
            {
                case "Premiere":
                    price = allPeople * 12.00;
                    break;

                case "Normal":
                    price = allPeople * 7.50;
                    break;

                case "Discount":
                    price = allPeople * 5.00;
                    break;

                default:
                    break;
            }

            Console.WriteLine($"{price:f2} leva");
        }
    }
}
