using System;

namespace MiddleCharacters
{
    class MiddleCharacters
    {
        static void Main(string[] args)
        {
            string someString = Console.ReadLine();
            string result = MiddleCharacter(someString);

            Console.WriteLine(result);
        }

        static string MiddleCharacter(string someString)
        {
            if (someString.Length % 2 == 0)
            {
                int index = someString.Length / 2;

                char fistCharacter = someString[index - 1];
                char secondCharacte = someString[index];

                string result = fistCharacter.ToString() + secondCharacte.ToString();

                return result;
            }
            else
            {
                int result = someString.Length / 2;
                char stringResult = someString[result];
                return stringResult.ToString();
            }
        }
    }
}
