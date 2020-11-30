using System;

namespace Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());

            int doctors = 7;
            int reviewsPatients = 0;
            int notReviewsPatients = 0;
            int allReviews = 0;
            int allNotRevies = 0;

            for (int i = 1; i <= period; i++)
            {
                if (i % 3 == 0 && allNotRevies > allReviews)
                {
                    doctors++;
                }

                int patients = int.Parse(Console.ReadLine());
                notReviewsPatients = patients - doctors;
                reviewsPatients = patients - notReviewsPatients;

                if (notReviewsPatients < 0)
                {
                    notReviewsPatients = 0;
                    reviewsPatients = patients;
                }

                allNotRevies += notReviewsPatients;
                allReviews += reviewsPatients;

                notReviewsPatients = 0;
                reviewsPatients = 0;
            }

            Console.WriteLine($"Treated patients: {allReviews}.");
            Console.WriteLine($"Untreated patients: {allNotRevies}.");
        }
    }
}
