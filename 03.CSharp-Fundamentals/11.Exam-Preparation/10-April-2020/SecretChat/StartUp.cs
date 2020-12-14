using System;
using System.Linq;

namespace SecretChat
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Reveal")
                {
                    break;
                }

                string command = tokens[0];

                switch (command)
                {
                    case "InsertSpace":
                        int insertIndex = int.Parse(tokens[1]);
                        message = message.Insert(insertIndex, " ");

                        Console.WriteLine(message);
                        break;

                    case "Reverse":
                        string subString = tokens[1];

                        if (message.Contains(subString))
                        {
                            int startIndex = message.IndexOf(subString);

                            string firstHalf = message.Substring(0, startIndex);
                            string secondHalf = message.Substring(startIndex + subString.Length);

                            message = firstHalf + secondHalf;

                            char[] characters = subString.ToArray();
                            Array.Reverse(characters);

                            string newMessage = new string(characters);

                            message += newMessage;

                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    case "ChangeAll":
                        string oldString = tokens[1];
                        string newString = tokens[2];

                        message = message.Replace(oldString, newString);

                        Console.WriteLine(message);
                        break;
                }

            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
