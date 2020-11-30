using System;

namespace VowelsCount
{
    class VowelsCount
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int numberVowels = VowelsNumber(word);

            Console.WriteLine(numberVowels);
        }

        public static int VowelsNumber(string word)
        {
            int count = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char currentLetter = word[i];

                switch (currentLetter)
                {
                    case 'a':
                    case 'A':
                    case 'e':
                    case 'E':
                    case 'i':
                    case 'I':
                    case 'o':
                    case 'O':
                    case 'u':
                    case 'U':
                        count++;
                        break;
                }
            }

            return count;
        }
    }
}
