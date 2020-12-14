using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> allPersons = new List<Person>();
            List<Product> avaliableProducts = new List<Product>();

            string[] infoPerson = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] infoProducts = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < infoPerson.Length; i++)
            {
                string[] currentPerson = infoPerson[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person newPerson = new Person();
                newPerson.PersonName = currentPerson[0];
                newPerson.PersonMoney = int.Parse(currentPerson[1]);

                allPersons.Add(newPerson);
            }

            for (int i = 0; i < infoProducts.Length; i++)
            {
                string[] currentProduct = infoProducts[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Product newProduct = new Product();
                newProduct.ProductName = currentProduct[0];
                newProduct.ProductCost = int.Parse(currentProduct[1]);

                avaliableProducts.Add(newProduct);
            }

            while (true)
            {
                string inPut = Console.ReadLine();
                if (inPut == "END")
                {
                    break;
                }
                string[] purchaseInfo = inPut
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person thatPerson = allPersons.Where(x => x.PersonName == purchaseInfo[0]).FirstOrDefault();
                Product thatProduct = avaliableProducts.Where(x => x.ProductName == purchaseInfo[1]).FirstOrDefault();

                if (thatPerson.PersonMoney >= thatProduct.ProductCost)
                {
                    thatPerson.PersonMoney -= thatProduct.ProductCost;
                    thatPerson.Products.Add(thatProduct);
                    Console.WriteLine($"{thatPerson.PersonName} bought {thatProduct.ProductName}");
                }
                else
                {
                    Console.WriteLine($"{thatPerson.PersonName} can't afford {thatProduct.ProductName}");
                }
            }

            List<Person> nothing = allPersons.Where(x => x.Products.Count == 0).ToList();
            allPersons = allPersons.Where(x => x.Products.Count > 0).ToList();

            for (int i = 0; i < allPersons.Count; i++)
            {
                Console.Write($"{allPersons[i].PersonName} - ");

                for (int j = 0; j < allPersons[i].Products.Count; j++)
                {
                    if (j == allPersons[i].Products.Count - 1)
                    {
                        Console.Write($"{allPersons[i].Products[j].ProductName}");
                    }
                    else
                    {
                        Console.Write($"{allPersons[i].Products[j].ProductName}, ");
                    }
                }

                Console.WriteLine();
            }


            if (nothing.Count > 0)
            {
                foreach (var item in nothing)
                {
                    Console.WriteLine($"{item.PersonName} - Nothing bought");
                }
            }
            
        }
    }
}
