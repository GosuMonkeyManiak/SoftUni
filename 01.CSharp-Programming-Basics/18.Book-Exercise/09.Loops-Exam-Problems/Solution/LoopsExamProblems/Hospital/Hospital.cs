using System;

namespace Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());

            int doctors = 7;
            int reviews = 0;
            int notRevies = 0;

            for (int i = 1; i <= period; i++)
            {
                if (i % 3 == 0)
                {
                    if (notRevies > reviews)
                    {
                        doctors++;
                    }
                }

                int pacients = int.Parse(Console.ReadLine());

                if (doctors > pacients)
                {
                    reviews += pacients;
                    continue;
                }
                int currentNotReviews = Math.Abs(pacients - doctors);
                int currentReviews = Math.Abs(pacients - currentNotReviews);

                reviews += currentReviews;
                notRevies += currentNotReviews;
            }

            Console.WriteLine($"Treated patients: {reviews}.");
            Console.WriteLine($"Untreated patients: {notRevies}.");
        }
    }
}
