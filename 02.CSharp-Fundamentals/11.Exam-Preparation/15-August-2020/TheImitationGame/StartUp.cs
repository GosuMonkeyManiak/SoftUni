using System;
using System.Linq;
using System.Text;

namespace TheImitationGame
{
    class Startup
    {
        static void Main(string[] args)
        {
            string encryptMessage = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Decode")
                {
                    Console.WriteLine($"The decrypted message is: {encryptMessage}");
                    break;
                }

                switch (command[0].ToUpper())
                {
                    case "MOVE":
                        int numberOfLetter = int.Parse(command[1]);

                        if (numberOfLetter == encryptMessage.Length)
                        {
                            char[] characters = encryptMessage.ToCharArray();
                            Array.Reverse(characters);
                            string newMessage = characters.ToString();

                            encryptMessage = newMessage;
                        }
                        else
                        {
                            string newMessage = string.Empty;

                            for (int i = numberOfLetter; i < encryptMessage.Length; i++)
                            {
                                newMessage += encryptMessage[i];
                            }

                            for (int i = 0; i < numberOfLetter; i++)
                            {
                                newMessage += encryptMessage[i];
                            }

                            encryptMessage = newMessage;
                        }
                        break;

                    case "INSERT":
                        int index = int.Parse(command[1]);
                        string value = command[2];

                        //if (index > 0 && index < encryptMessage.Length)
                        //{
                        //    encryptMessage = encryptMessage.Insert(index, value);
                        //}

                        encryptMessage = encryptMessage.Insert(index, value);
                        break;

                    case "CHANGEALL":
                        string subString = command[1];
                        string replacement = command[2];

                        encryptMessage = encryptMessage.Replace(subString, replacement);
                        break;
                }
            }
        }
    }
}
