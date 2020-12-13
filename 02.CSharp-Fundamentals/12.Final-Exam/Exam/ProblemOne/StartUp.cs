using System;
using System.Collections.Generic;

namespace ProblemOne
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            List<int> asciiCodes = new List<int>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Complete")
                {
                    break;
                }

                string command = tokens[0];

                switch (command)
                {
                    case "Make":
                        if (tokens[1] == "Upper")
                        {
                            email = email.ToUpper();
                            Console.WriteLine(email);
                        }
                        else
                        {
                            email = email.ToLower();
                            Console.WriteLine(email);
                        }
                        break;

                    case "GetDomain":
                        int count = int.Parse(tokens[1]);
                        int startIndex = email.Length - count;

                        for (int i = startIndex; i < email.Length; i++)
                        {
                            Console.Write(email[i]);
                        }

                        Console.WriteLine();
                        
                        break;

                    case "GetUsername":
                        int indexOfSymbol = email.IndexOf('@');

                        if (indexOfSymbol == -1)
                        {
                            Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        }
                        else
                        {
                            string userName = email.Substring(0, indexOfSymbol);
                            Console.WriteLine(userName);
                        }
                        break;

                    case "Replace":
                        char character = char.Parse(tokens[1]);

                        email = email.Replace(character, '-');

                        Console.WriteLine(email);
                        break;

                    case "Encrypt":

                        for (int i = 0; i < email.Length; i++)
                        {
                            int code = (int)(email[i]);
                            asciiCodes.Add(code);
                        }

                        Console.WriteLine(string.Join(' ', asciiCodes));

                        break;
                    default:
                        break;
                }

            }

        }
    }
}
