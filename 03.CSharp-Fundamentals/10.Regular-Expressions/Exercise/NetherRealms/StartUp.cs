using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace NetherRealms
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string letterPattern = @"[^\+\-\*\/\d\.\s\,]";
            string numberPattern = @"(?<sign>[\-\+]*)(?<number>\d+(?:[\.]\d+)*)";
            string mathematicsPatternMultiply = @"[\*]";
            string mathematicsPatternDivide = @"[\/]";

            List<string> participants = Console.ReadLine()
                .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, Demon> demons = new Dictionary<string, Demon>();

            for (int i = 0; i < participants.Count; i++)
            {
                int demonHealth = 0;

                MatchCollection letterMatches = Regex.Matches(participants[i], letterPattern);

                foreach (Match letter in letterMatches)
                {
                    char character = char.Parse(letter.ToString());
                    demonHealth += (int)character;
                }

                MatchCollection numberMaches = Regex.Matches(participants[i], numberPattern);

                double demonDamage = 0.0;

                foreach (Match number in numberMaches)
                {
                    double fullNumber = double.Parse(number.Groups["sign"].Value + number.Groups["number"].Value);

                    demonDamage += fullNumber;
                }

                MatchCollection multiply = Regex.Matches(participants[i], mathematicsPatternMultiply);

                foreach (Match sign in multiply)
                {
                    demonDamage *= 2;
                }

                MatchCollection divide = Regex.Matches(participants[i], mathematicsPatternDivide);

                foreach (Match sign in divide)
                {
                    demonDamage /= 2;
                }

                if (demons.ContainsKey(participants[i]) == false)
                {
                    demons.Add(participants[i], new Demon()
                    {
                        Health = demonHealth,
                        Damage = demonDamage
                    });
                }

            }

            foreach (var demon in demons.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{demon.Key} - {demon.Value.Health} health, {demon.Value.Damage:f2} damage");
            }
        }

    }

    class Demon
    {
        public int Health { get; set; }

        public double Damage { get; set; }
    }

}
