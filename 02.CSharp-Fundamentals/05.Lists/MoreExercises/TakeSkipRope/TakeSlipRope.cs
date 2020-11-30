using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeSkipRope
{
    class TakeSlipRope
    {
        static void Main(string[] args)
        {
            string encrypt = Console.ReadLine();
            StringBuilder encryptedMessages = new StringBuilder(encrypt);

            StringBuilder result = new StringBuilder();

            List<int> digits = new List<int>(); //take list
            List<string> nonNumber = new List<string>();


            for (int i = 0; i < encryptedMessages.Length; i++)
            {
                if (char.IsDigit(encryptedMessages[i]))
                {
                    digits.Add(int.Parse(encryptedMessages[i].ToString()));
                    encryptedMessages.Remove(i , 1);
                    i--;
                    continue;
                }
                nonNumber.Add(encryptedMessages[i].ToString());
            }

            List<int> skipList = new List<int>();
            List<int> takeLsit = new List<int>();

            for (int i = 0; i < digits.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeLsit.Add(digits[i]);
                }
                else
                {
                    skipList.Add(digits[i]);
                }
            }

            int skippedIndex = 0;

            for (int i = 0; i < takeLsit.Count; i++)
            {
                List<string> temp = new List<string>(nonNumber);

                temp = temp.Skip(skippedIndex).Take(takeLsit[i]).ToList();

                result.Append(string.Join("", temp));

                skippedIndex += takeLsit[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());
        }
    }
}
