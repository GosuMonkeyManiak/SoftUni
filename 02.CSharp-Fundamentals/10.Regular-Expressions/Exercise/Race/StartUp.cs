using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();

            string[] participantsInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < participantsInput.Length; i++)
            {
                if (participants.ContainsKey(participantsInput[i]) == false)
                {
                    participants.Add(participantsInput[i], 0);
                }
            }

            string pattern = @"[A-Za-z]";

            Regex regex = new Regex(pattern);

            while (true)
            {
                string info = Console.ReadLine();
                if (info == "end of race")
                {
                    break;
                }

                string nameOfPaticipants = "";

                MatchCollection matches = regex.Matches(info);

                foreach (Match letter in matches)
                {
                    string character = letter.ToString();

                    nameOfPaticipants += character;
                }

                int travelKilometers = LetterSum(info);

                if (participants.ContainsKey(nameOfPaticipants))
                {
                    participants[nameOfPaticipants] += travelKilometers;
                }
            }

            participants = participants.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            int counter = 1;

            foreach (var item in participants)
            {
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                    counter++;
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                    counter++;
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                    counter++;
                }
                else
                {
                    break;
                }
            }

        }

        public static int LetterSum(string info)
        {
            string patters = @"\d";
            int sum = 0;

            Regex regex = new Regex(patters);

            MatchCollection matches = regex.Matches(info);

            foreach (Match item in matches)
            {
                sum += int.Parse(item.ToString());
            }

            return sum;
        }
    }
}
