using System;

namespace WorldTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] {':',' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Travel")
                {
                    break;
                }

                string command = tokens[0];

                switch (command.ToUpper())
                {
                    case "ADD":
                        int index = int.Parse(tokens[2]);

                        if (index >= 0 && index < stops.Length)
                        {
                            stops = stops.Insert(index, tokens[3]);
                        }

                        Console.WriteLine(stops);
                        break;

                    case "REMOVE":
                        int startIndex = int.Parse(tokens[2]);
                        int endIndex = int.Parse(tokens[3]);

                        if ((startIndex >= 0 && startIndex < stops.Length) && (endIndex >= 0 && endIndex < stops.Length) && startIndex <= endIndex)
                        {
                            string firstHalf = stops.Substring(0, startIndex);
                            string secondHalf = stops.Substring(endIndex + 1);

                            stops = firstHalf + secondHalf;
                        }

                        Console.WriteLine(stops);
                        break;

                    case "SWITCH":
                        string oldString = tokens[1];
                        string newString = tokens[2];

                        stops = stops.Replace(oldString, newString);

                        Console.WriteLine(stops);
                        break;

                }

            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
