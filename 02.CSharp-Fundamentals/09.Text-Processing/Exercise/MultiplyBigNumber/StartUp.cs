using System;
using System.Linq;

namespace MultiplyBigNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            string result = string.Empty;

            int onMind = 0;

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int lastBigNumber = int.Parse(bigNumber[i].ToString());

                int currentSum = lastBigNumber * multiplier;

                currentSum += onMind;

                if (i == 0)
                {
                    if (currentSum >= 10)
                    {
                        result = currentSum.ToString() + result;
                    }
                    else
                    {
                        result = currentSum.ToString() + result;

                        onMind = 0;
                    }

                    continue;
                }

                if (currentSum >= 10)
                {
                    result = currentSum.ToString()[1] + result;

                    onMind = currentSum / 10;
                }
                else
                {
                    result = currentSum.ToString() + result;

                    onMind = 0;
                }
            }

            while (result[0] == '0' && result.Length > 1)
            {
                result = result.Remove(0, 1);
            }

            Console.WriteLine(result);
        }
    }
}
