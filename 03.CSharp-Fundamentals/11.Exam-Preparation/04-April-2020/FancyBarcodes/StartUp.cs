using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string pattern = @"([\@][\#]+)(?<item>[A-Z][A-Za-z0-9]{4,}[A-Z])([\@][\#]+)";

            int numberOfBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBarcodes; i++)
            {
                string barcode = Console.ReadLine();

                Match validBarcodes = Regex.Match(barcode, pattern);

                if (validBarcodes.Length > 0)
                {
                    string digitPatter = @"\d";

                    MatchCollection digits = Regex.Matches(barcode, digitPatter);

                    if (digits.Count > 0)
                    {
                        Console.WriteLine($"Product group: {string.Join("",digits)}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
            }
        }
    }
}
