namespace PetStore.ConsoleApplication.Views
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using Utilities;
    using Utilities.Enums;

    public static class RegisterView
    {
        public static ICollection<KeyValuePair<string, string>> Execute()
        {
            Console.Clear();

            ViewTitlePrinter.PrintTitle(GlobalConstants.Register_Title);

            Console.Write(GlobalConstants.Username_Field);
            string userName = Console.ReadLine();

            Console.Write(GlobalConstants.Password_Field);
            string password = SecurePasswordReader.Read();

            Console.WriteLine();

            ICollection<KeyValuePair<string, string>> userCredentials = new List<KeyValuePair<string, string>>();

            userCredentials.Add(new KeyValuePair<string, string>(UserCredentials.Username.ToString(), userName));
            userCredentials.Add(new KeyValuePair<string, string>(UserCredentials.Password.ToString(), password));

            return userCredentials;
        }
    }
}
