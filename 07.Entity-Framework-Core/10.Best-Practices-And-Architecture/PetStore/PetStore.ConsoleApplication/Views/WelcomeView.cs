namespace PetStore.ConsoleApplication.Views
{
    using System;
    using Constants;
    using Utilities;
    using Utilities.Enums;

    public static class WelcomeView
    {
        public static ViewResult Execute()
        {
            Beginning:

            Console.Clear();
            ViewTitlePrinter.PrintTitle(GlobalConstants.Welcome_Title);

            Console.WriteLine(GlobalConstants.Welcome_Nav);

            int firstSectionAnswer = int.Parse(Console.ReadLine());

            if (firstSectionAnswer == GlobalConstants.Login_Number)
            {
                return ViewResult.Login;
            }
            else if (firstSectionAnswer == GlobalConstants.Register_Number)
            {
                return ViewResult.Register;
            }
            else if (firstSectionAnswer == GlobalConstants.Exit_Number)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(GlobalConstants.Welcome_Nav_Incorrect_Entered_Value);
                Console.ReadKey();
                Console.Clear();
                goto Beginning;
            }

            return ViewResult.Nothing;
        }
    }
}
