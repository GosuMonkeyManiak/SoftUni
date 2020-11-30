using System;

namespace DataTypes
{
    class DataTypes
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int number = int.Parse(Console.ReadLine());
                    DataType(number);
                    break;

                case "real":
                    double num = double.Parse(Console.ReadLine());
                    DataType(num);
                    break;

                case "string":
                    string sample = Console.ReadLine();
                    DataType(sample);
                    break;
            }
        }

        static void DataType(int num)
        {
            Console.WriteLine(num * 2);
        }

        static void DataType(double num)
        {
            Console.WriteLine($"{num * 1.5:f2}");
        }

        static void DataType(string sample)
        {
            Console.WriteLine("${0}$",sample);
        }
    }
}
