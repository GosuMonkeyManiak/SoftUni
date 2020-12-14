using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int nCommand = int.Parse(Console.ReadLine());

            Dictionary<string, string> registeredPeople = new Dictionary<string, string>(); 

            for (int i = 0; i < nCommand; i++)
            {
                string[] infoAboutUserCar = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = infoAboutUserCar[0];
                string username = infoAboutUserCar[1];

                if (command == "register")
                {
                    string licensePlateNumber = infoAboutUserCar[2];

                    if (registeredPeople.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registeredPeople[username]}");
                    }
                    else
                    {
                        registeredPeople.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else
                {
                    if (registeredPeople.ContainsKey(username))
                    {
                        registeredPeople.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var item in registeredPeople)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
