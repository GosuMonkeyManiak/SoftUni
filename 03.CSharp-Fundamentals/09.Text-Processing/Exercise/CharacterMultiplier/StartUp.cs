using System;

namespace CharacterMultiplier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstWord = words[0];
            string secondWord = words[1];

            int sum = SumOfTwoWord(firstWord, secondWord);

            Console.WriteLine(sum);
        }

        public static int SumOfTwoWord(string firstWord, string secondWord)
        {
            int sum = 0;

            if (firstWord.Length > secondWord.Length)
            {
                for (int i = 0; i < secondWord.Length; i++)
                {
                    char firstChar = firstWord[i];
                    char secondChar = secondWord[i];

                    sum += firstChar * secondChar;
                }


                for (int i = secondWord.Length; i < firstWord.Length; i++)
                {
                    char firsChar = firstWord[i];

                    sum += firsChar;
                }
            }
            else if (firstWord.Length == secondWord.Length)
            {
                for (int i = 0; i < secondWord.Length; i++)
                {
                    char firstChar = firstWord[i];
                    char secondChar = secondWord[i];

                    sum += firstChar * secondChar;
                }
            }
            else
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    char firstChar = firstWord[i];
                    char secondChar = secondWord[i];

                    sum += firstChar * secondChar;
                }


                for (int i = firstWord.Length; i < secondWord.Length; i++)
                {
                    char secondChar = secondWord[i];

                    sum += secondChar;
                }
            }

            return sum;
        }

    }
}
