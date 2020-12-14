using System;

namespace DigitsLettersAndOther
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] result = new string[3];

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (char.IsDigit(currentChar))
                {
                    result[0] += currentChar;
                }
                else if (char.IsLetter(currentChar))
                {
                    result[1] += currentChar;
                }
                else
                {
                    result[2] += currentChar;
                }
            }

            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
