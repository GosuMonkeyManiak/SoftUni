<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> 9299a2e62c9f45f103ba727135c4c4b91d4ac277

namespace Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            //intPut 
            //buget and season
            //two seasons Summer and Winter
            //location Alaska Morocco
            //type room Hotel Hut Camp

            double buget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string typeAccommodation = "";
            string accommodationLocation = "";
            double price = 0.0;

            if (buget <= 1000)
            {
                typeAccommodation = "Camp";

                if (season == "Summer")
                {
                    accommodationLocation = "Alaska";
                    price = buget * 0.65;
                }
                else
                {
                    accommodationLocation = "Morocco";
                    price = buget * 0.45;
                }
            }
            else if (buget <= 3000)
            {
                typeAccommodation = "Hut";

                if (season == "Summer")
                {
                    accommodationLocation = "Alaska";
                    price = buget * 0.80;
                }
                else
                {
                    accommodationLocation = "Morocco";
                    price = buget * 0.60;
                }
            }
            else
            {
                typeAccommodation = "Hotel";
                price = buget * 0.90;

                if (season == "Summer")
                {
                    accommodationLocation = "Alaska";
                }
                else
                {
                    accommodationLocation = "Morocco";
                }
            }
			
            Console.WriteLine($"{accommodationLocation} - {typeAccommodation} - {price:f2}");
        }
    }
}
