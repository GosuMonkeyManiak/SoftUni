using System;
using System.Threading;

namespace StreamOfLetters
{
    class StreamOfLetters
    {
        static void Main(string[] args)
        {
            string let = Console.ReadLine();

            string emptyText = "";
            string secretWord = "";
            int countSecretLetterC = 0;
            int countSecretLettrO = 0;
            int countSecretLettrN = 0;

            while (let != "End")
            {
                char letter = char.Parse(let);

                if ((letter > 'a' && letter < 'z') || (letter > 'A' && letter < 'Z'))
                {
                    if (letter == 'c')
                    {
                        if (countSecretLetterC >= 1)
                        {
                            emptyText += letter;
                        }
                        else
                        {
                            secretWord += letter;
                            countSecretLetterC++;
                        }
                    }
                    else if (letter == 'o')
                    {
                        if (countSecretLettrO >= 1)
                        {
                            emptyText += letter;
                        }
                        else
                        {
                            secretWord += letter;
                            countSecretLettrO++;
                        }
                    }
                    else if (letter == 'n')
                    {
                        if (countSecretLettrN >= 1)
                        {
                            emptyText += letter;
                        }
                        else
                        {
                            secretWord += letter;
                            countSecretLettrN++;
                        }
                    }
                    else
                    {
                        emptyText += letter;
                    }

                    if (secretWord == "con" || secretWord == "noc")
                    {
                        secretWord = "";
                        emptyText += " ";
                        countSecretLetterC = 0;
                        countSecretLettrN = 0;
                        countSecretLettrO = 0;
                    }
                }

                let = Console.ReadLine();
            }

            Console.WriteLine(emptyText);
        }
    }
}
