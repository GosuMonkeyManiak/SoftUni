using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] peopleInfo = Console.ReadLine()
                .Split(";");
            string[] productInfo = Console.ReadLine()
                .Split(";");

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < peopleInfo.Length; i++)
            {
                string[] currentPerson = peopleInfo[i].Split("=");

                try
                {
                    people.Add(new Person(currentPerson[0], decimal.Parse(currentPerson[1])));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            for (int i = 0; i < productInfo.Length; i++)
            {
                string[] currentProduct = productInfo[i].Split("=");

                try
                {
                    products.Add(new Product(currentProduct[0], decimal.Parse(currentProduct[1])));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }


            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "END")
                {
                    break;
                }

                string name = command[0];
                string productName = command[1];

                Product product = products.FirstOrDefault(x => x.Name == productName);

                foreach (var person in people.Where(x => x.Name == name))
                {
                    if (person.Money < product.Cost)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                        continue;
                    }

                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
