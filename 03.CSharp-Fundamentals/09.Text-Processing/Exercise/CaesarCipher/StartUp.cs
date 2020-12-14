using System;

namespace CaesarCipher
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string inPut = Console.ReadLine();

            string encryptedString = string.Empty;

            for (int i = 0; i < inPut.Length; i++)
            {
                char currentChar = inPut[i];
                currentChar += (char)3;

                encryptedString += currentChar;
            }

            Console.WriteLine(encryptedString);
        }
    }
}
