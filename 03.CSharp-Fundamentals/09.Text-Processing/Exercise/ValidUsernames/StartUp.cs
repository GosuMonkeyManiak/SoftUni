using System;
using System.Collections.Generic;

namespace ValidUsernames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> validUsernames = new List<string>();

            bool letter = false;
            bool digit = false;
            bool underscores = false;
            bool hyphens = false;

            foreach (string item in usernames)
            {
                if (item.Length > 3 && item.Length < 16)
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        char currentCharacter = item[i];

                        if (char.IsLetter(currentCharacter))
                        {
                            letter = true;
                        }
                        else if (char.IsDigit(currentCharacter))
                        {
                            digit = true;
                        }
                        else if (currentCharacter == '-')
                        {
                            hyphens = true;
                        }
                        else if (currentCharacter == '_')
                        {
                            underscores = true;
                        }
                        else
                        {
                            letter = false;
                            digit = false;
                            underscores = false;
                            hyphens = false;
                            break;
                        }
                    }

                    if (letter || digit || underscores || hyphens)
                    {
                        validUsernames.Add(item);
                    }

                }

            }

            foreach (var item in validUsernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
