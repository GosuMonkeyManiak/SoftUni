using System;

namespace CinemaTickets
{
    class CinemaTickets
    {
        static void Main(string[] args)
        {
            int studentTickets = 0;
            int standardTickets = 0;
            int kids = 0;
            int allTickets = 0;
            int allStudentTickets = 0;
            int allStandardTickets = 0;
            int allKidsTickets = 0;

            while (true)
            {
                string movie = Console.ReadLine();
                if (movie == "Finish")
                {
                    Console.WriteLine($"Total tickets: {allTickets}");
                    Console.WriteLine($"{(1.0 * allStudentTickets) / allTickets * 100:f2}% student tickets.");
                    Console.WriteLine($"{(1.0 * allStandardTickets) / allTickets * 100:f2}% standard tickets.");
                    Console.WriteLine($"{(1.0 * allKidsTickets) / allTickets * 100:f2}% kids tickets.");
                    break;
                }

                int freeSet = int.Parse(Console.ReadLine());
                int free = freeSet;

                while (free > 0)
                {
                    string typeTicket = Console.ReadLine();
                    if (typeTicket == "End")
                    {
                        break;
                    }

                    switch (typeTicket)
                    {
                        case "student":
                            studentTickets++;
                            break;

                        case "standard":
                            standardTickets++;
                            break;

                        case "kid":
                            kids++;
                            break;
                    }
                    free -= 1;
                }

                int currentMovieAllTickets = studentTickets + standardTickets + kids;
                allTickets += currentMovieAllTickets;

                Console.WriteLine($"{movie} - {1.0 * currentMovieAllTickets / freeSet * 100:f2}% full.");

                allStudentTickets += studentTickets;
                allStandardTickets += standardTickets;
                allKidsTickets += kids;

                studentTickets = 0;
                standardTickets = 0;
                kids = 0;
            }
        }
    }
}
