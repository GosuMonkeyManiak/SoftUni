using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartPhone = new Smartphone();
            StationaryPhone phone = new StationaryPhone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (int.TryParse(phoneNumbers[i], out int number))
                {
                    if (phoneNumbers[i].Length == 7)
                    {
                        phone.Call(phoneNumbers[i]);
                    }
                    else if (phoneNumbers[i].Length == 10)
                    {
                        smartPhone.Call(phoneNumbers[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }


            for (int i = 0; i < urls.Length; i++)
            {
                if (urls[i].Any(char.IsDigit)) //have a digit
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartPhone.Browse(urls[i]);
                }
            }
        }
    }
}
