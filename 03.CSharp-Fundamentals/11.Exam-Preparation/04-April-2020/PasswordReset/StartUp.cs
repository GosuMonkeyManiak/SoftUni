using System;

namespace PasswordReset
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string oldPassword = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Done")
                {
                    break;
                }

                string command = tokens[0];

                switch (command)
                {
                    case "TakeOdd":
                        string OddCharacters = string.Empty;

                        for (int i = 0; i < oldPassword.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                OddCharacters += oldPassword[i];
                            }
                        }

                        oldPassword = OddCharacters;

                        Console.WriteLine(oldPassword);
                        break;

                    case "Cut":
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);

                        string firstHalf = oldPassword.Substring(0, index);
                        string secondHalf = oldPassword.Substring(index + length);

                        oldPassword = firstHalf + secondHalf;

                        Console.WriteLine(oldPassword);
                        break;

                    case "Substitute":
                        string substring = tokens[1];
                        string substitute = tokens[2];

                        if (oldPassword.Contains(substring))
                        {
                            oldPassword = oldPassword.Replace(substring, substitute);
                            Console.WriteLine(oldPassword);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }

            }

            Console.WriteLine($"Your password is: {oldPassword}");
        }
    }
}
