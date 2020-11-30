using System;

namespace Operations
{
    class Operations
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char Operator = char.Parse(Console.ReadLine());

            switch (Operator)
            {
                case '+':
                    int resultPlus = n1 + n2;
                    if (resultPlus % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {Operator} {n2} = {resultPlus} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {Operator} {n2} = {resultPlus} - odd");
                    }
                    break;

                case '-':
                    int resultMinus = n1 - n2;
                    if (resultMinus % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {Operator} {n2} = {resultMinus} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {Operator} {n2} = {resultMinus} - odd");
                    }
                    break;

                case '*':
                    int resultMultiply = n1 * n2;
                    if (resultMultiply % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {Operator} {n2} = {resultMultiply} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {Operator} {n2} = {resultMultiply} - odd");
                    }
                    break;

                case '/':
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }

                    double resultDevided = (1.0 * n1) / (1.0 * n2);
                    Console.WriteLine($"{n1} / {n2} = {resultDevided:f2}");
                    break;

                case '%':
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                        break;
                    }

                    int resultModolo = n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {resultModolo}");
                    break;
                default:
                    break;
            }

        }
    }
}
