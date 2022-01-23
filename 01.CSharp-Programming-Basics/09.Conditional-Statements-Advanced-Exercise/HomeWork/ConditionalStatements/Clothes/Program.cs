namespace Clothes
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string format = "It's {0} degrees, get your {1} and {2}.";
            string result = string.Empty;


            switch (time.ToLower())
            {
                case "morning":
                    if (degrees >= 10 && degrees <= 18)
                    {
                        result = string.Format(format, degrees, "Sweatshirt", "Sneakers");
                    }
                    else if (degrees <= 24)
                    {
                        result = string.Format(format, degrees, "Shirt", "Moccasins");
                    }
                    else
                    {
                        result = string.Format(format, degrees, "T-Shirt", "Sandals");
                    }
                    break;

                case "afternoon":
                    if (degrees >= 10 && degrees <= 18)
                    {
                        result = string.Format(format, degrees, "Shirt", "Moccasins");
                    }
                    else if (degrees <= 24)
                    {
                        result = string.Format(format, degrees, "T-Shirt", "Sandals");
                    }
                    else
                    {
                        result = string.Format(format, degrees, "Swim Suit", "Barefoot");
                    }
                    break;

                case "evening":
                    if (degrees >= 10 && degrees <= 18)
                    {
                        result = string.Format(format, degrees, "Shirt", "Moccasins");
                    }
                    else if (degrees <= 24)
                    {
                        result = string.Format(format, degrees, "Shirt", "Moccasins");
                    }
                    else
                    {
                        result = string.Format(format, degrees, "Shirt", "Moccasins");
                    }
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
