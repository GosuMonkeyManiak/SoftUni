using System;

namespace PasswordValidator
{
    class PasswordValidator
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            //6 – 10 characters(inclusive)
            //Consists only of letters and digits
            //Have at least 2 digits
            bool passwordLenght = PasswordLenght(password);
            bool passwordLetterAndDigits = PasswordLetterAndDigits(password);
            bool passwordDigitCounter = PasswordDigitCounter(password);

            if (passwordLenght && passwordLetterAndDigits && passwordDigitCounter)
            {
                Console.WriteLine("Password is valid");
            }

            if (!passwordLenght)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!passwordLetterAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!passwordDigitCounter)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        private static bool PasswordLenght(string password)
        {
            bool isFromSixToTenChars = false;
            int charCounter = 0;
            foreach (var item in password)
            {
                charCounter++;
            }
            if (charCounter >= 6 && charCounter <= 10)
            {
                isFromSixToTenChars = true;
            }

            return isFromSixToTenChars;
        }

        private static bool PasswordDigitCounter(string password)
        {
            bool IsMoreThanTwo = false;
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;
                }
            }
            if (counter >= 2)
            {
                IsMoreThanTwo = true;
            }
            return IsMoreThanTwo;
        }

        private static bool PasswordLetterAndDigits(string password)
        {
            bool IsLetterAndDigitOnly = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (!(char.IsLetterOrDigit(password[i])))
                {
                    IsLetterAndDigitOnly = false;
                }
            }
            return IsLetterAndDigitOnly;
        }

    }
}

