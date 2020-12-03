using System;
using System.Collections.Generic;

namespace MorseCodeTranslator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] code = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            string result = string.Empty;

            for (int i = 0; i < code.Length; i++)
            {
                string[] letters = code[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < letters.Length; j++)
                {
                    char decryptChar = Translate(letters[j]);

                    result += decryptChar;
                }

                result += " ";
            }


            Console.WriteLine(result);
        }

        public static char Translate(string morseCode)
        {
            char dot = '.';
            char dash = '-';

            Dictionary<string, char> morseTable = new Dictionary<string, char>()
            {
                { string.Concat(dot, dash), 'A' },
                { string.Concat(dash, dot, dot, dot), 'B' },
                { string.Concat(dash, dot, dash , dot), 'C' },
                { string.Concat(dash, dot, dot), 'D' },
                { string.Concat(dot), 'E' },
                { string.Concat(dot, dot, dash, dot), 'F' },
                { string.Concat(dash, dash , dot), 'G' },
                { string.Concat(dot, dot, dot, dot), 'H' },
                { string.Concat(dot, dot), 'I' },
                { string.Concat(dot, dash, dash, dash), 'J' },
                { string.Concat(dash, dot, dash), 'K' },
                { string.Concat(dot, dash, dot, dot), 'L' },
                { string.Concat(dash, dash), 'M' },
                { string.Concat(dash, dot), 'N' },
                { string.Concat(dash, dash, dash), 'O' },
                { string.Concat(dot, dash, dash, dot), 'P' },
                { string.Concat(dash, dash, dot, dash), 'Q' },
                { string.Concat(dot, dash, dot), 'R' },
                { string.Concat(dot, dot, dot), 'S' },
                { string.Concat(dash), 'T' },
                { string.Concat(dot, dot, dash), 'U' },
                { string.Concat(dot, dot, dot, dash), 'V' },
                { string.Concat(dot, dash, dash), 'W' },
                { string.Concat(dash, dot, dot, dash), 'X' },
                { string.Concat(dash, dot, dash, dash), 'Y' },
                { string.Concat(dash, dash, dot, dot), 'Z'}
            };

            return morseTable[morseCode];
        }
    }
}
