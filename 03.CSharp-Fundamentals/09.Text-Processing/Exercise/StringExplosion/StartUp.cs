using System;

namespace StringExplosion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    int strength = int.Parse(text[i + 1].ToString());
                    i++;

                    while (strength > 0 && i < text.Length)
                    {
                        if (text[i] == '>')
                        {
                            strength += int.Parse(text[i + 1].ToString());
                            i++;
                        }

                        text = text.Remove(i, 1);
                        strength--;
                    }

                    i--;
                }
            }

            Console.WriteLine(text);
        }
    }
}
