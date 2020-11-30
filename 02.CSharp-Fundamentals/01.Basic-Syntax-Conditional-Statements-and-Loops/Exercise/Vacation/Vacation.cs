using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine().ToLower();
            string dayOfWeek = Console.ReadLine().ToLower();

            double price = double.NaN;

            switch (dayOfWeek)
            {
                case "friday":
                    if (typeOfGroup == "students") // 8.45 each
                    {
                        price = numberOfPeople * 8.45;

                        if (numberOfPeople >= 30)
                        {
                            double discount = 0.15 * price;
                            price -= discount;
                        }
                    }
                    else if (typeOfGroup == "business") // 10.90 each
                    {
                        if (numberOfPeople >= 100)
                        {
                            numberOfPeople -= 10;
                        }

                        price = numberOfPeople * 10.90;
                    }
                    else // 15 each
                    {
                        price = numberOfPeople * 15;

                        if (numberOfPeople >= 10 && numberOfPeople <= 20)
                        {
                            double discount = 0.05 * price;
                            price -= discount;
                        }
                    }
                    break;

                case "saturday":
                    if (typeOfGroup == "students") // 9.80
                    {
                        price = numberOfPeople * 9.80;

                        if (numberOfPeople >= 30)
                        {
                            double discount = 0.15 * price;
                            price -= discount;
                        }
                    }
                    else if (typeOfGroup == "business") // 15.60
                    {
                        if (numberOfPeople >= 100)
                        {
                            numberOfPeople -= 10;
                        }

                        price = numberOfPeople * 15.60;
                    }
                    else // 20
                    {
                        price = numberOfPeople * 20;

                        if (numberOfPeople >= 10 && numberOfPeople <= 20)
                        {
                            double discount = 0.05 * price;
                            price -= discount;
                        }
                    }
                    break;

                case "sunday":
                    if (typeOfGroup == "students") // 10.46
                    {
                        price = numberOfPeople * 10.46;

                        if (numberOfPeople >= 30)
                        {
                            double discount = 0.15 * price;
                            price -= discount;
                        }
                    }
                    else if (typeOfGroup == "business") // 16
                    {
                        if (numberOfPeople >= 100)
                        {
                            numberOfPeople -= 10;
                        }

                        price = numberOfPeople * 16;
                    }
                    else // 22.50
                    {
                        price = numberOfPeople * 22.50;

                        if (numberOfPeople >= 10 && numberOfPeople <= 20)
                        {
                            double discount = 0.05 * price;
                            price -= discount;
                        }
                    }
                    break;

                default:
                    break;
            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
