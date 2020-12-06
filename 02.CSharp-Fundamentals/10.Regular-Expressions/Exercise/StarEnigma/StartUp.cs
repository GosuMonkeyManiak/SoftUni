using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace StarEnigma
{
    class StartUp
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            string pattern = @"[^\@\-\!\:\>]*[@](?<planetName>[A-Za-z]+)[^\@\-\!\:\>]*[\:](?<population>\d+)[^\@\-\!\:\>]*\!(?<attackType>(?:[A]|[D]))\![^\@\-\!\:\>]*[-][>](?<soldiers>\d+)[^\@\-\!\:\>]*";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();


            for (int i = 0; i < n; i++)
            {
                string encryptMessage = Console.ReadLine();

                int count = 0;

                for (int j = 0; j < encryptMessage.Length; j++)
                {
                    string character = encryptMessage[j].ToString().ToUpper();

                    if (character == "S" || character == "T" || character == "A" || character == "R")
                    {
                        count++;
                    }
                }

                string afterDecrypt = "";

                for (int k = 0; k < encryptMessage.Length; k++)
                {
                    char encryptChar = encryptMessage[k];
                    encryptChar -= (char)count;

                    afterDecrypt += encryptChar;
                }

                MatchCollection matches = Regex.Matches(afterDecrypt, pattern);

                foreach (Match match in matches)
                {
                    string dOrA = match.Groups["attackType"].Value;

                    if (dOrA == "A")
                    {
                        string planetName = match.Groups["planetName"].Value;
                        attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        string planetName = match.Groups["planetName"].Value;
                        destroyedPlanets.Add(planetName);
                    }
                }

            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var item in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var item in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
