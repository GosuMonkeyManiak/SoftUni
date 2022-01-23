namespace Operations
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            char operationSign = char.Parse(Console.ReadLine());

            string format = "{0} {1} {2} = {3}";
            string result = String.Empty;

            switch (operationSign)
            {
                case '+':
                    double additionResult = firstNumber + secondNumber;

                    result = string.Format(format, firstNumber, operationSign, secondNumber, additionResult)
                        + " - " + (additionResult % 2 == 0
                            ? "even"
                            : "odd");
                    break;

                case '-':
                    double subTractionResult = firstNumber - secondNumber;

                    result = string.Format(format, firstNumber, operationSign, secondNumber, subTractionResult)
                             + " - " + (subTractionResult % 2 == 0
                                 ? "even"
                                 : "odd");
                    break;

                case '*':
                    double multiplicationResult = firstNumber * secondNumber;

                    result = string.Format(format, firstNumber, operationSign, secondNumber, multiplicationResult)
                             + " - " + (multiplicationResult % 2 == 0
                                 ? "even"
                                 : "odd");
                    break;

                case '/':
                    if (secondNumber == 0)
                    {
                        result = $"Cannot divide {firstNumber} by zero";
                        break;
                    }

                    double divideResult = firstNumber / secondNumber;

                    result = string.Format(format, firstNumber, operationSign, secondNumber, $"{divideResult:f2}");
                    break;

                case '%':
                    if (secondNumber == 0)
                    {
                        result = $"Cannot divide {firstNumber} by zero";
                        break;
                    }

                    double remainder = firstNumber % secondNumber;

                    result = string.Format(format, firstNumber, operationSign, secondNumber, remainder);
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
