using System;

namespace TranningLab
{
    class TranningLab
    {
        static void Main(string[] args)
        {
            //Едно работно място заема 70 на 120 cm (маса с размер 70 на 40 cm + място за стол и преминаване с размер 70 на 80 cm).
            //Коридорът е широк поне 100 cm
            //входната врата (която е с отвор 160 cm) 1 място
            //катедрата (която е с размер 160 на 120 cm) 2 места
            
            double length = double.Parse(Console.ReadLine()); //дължина 
            double width = double.Parse(Console.ReadLine()); //широчина

            length *= 100;
            width *= 100;

            width -= 100;

            int chair = (int)(width / 70);

            int chairs = (int)(length / 120);

            int allChairs = (chair * chairs) - 3;

            Console.WriteLine(allChairs);
        }
    }
}
