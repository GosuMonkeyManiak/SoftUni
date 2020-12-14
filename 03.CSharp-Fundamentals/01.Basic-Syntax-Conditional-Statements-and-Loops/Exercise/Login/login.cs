using System;

namespace Login
{
    class login
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = string.Empty;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }

            int error = 0;

            while (true)
            {
                string currentPassword = Console.ReadLine();

                if (password != currentPassword)
                {
                    error++;

                    if (error == 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }

                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
            }

        }
    }
}
