namespace PetStore.ConsoleApplication.Utilities
{
    using System;

    public static class ViewTitlePrinter
    {
        public static void PrintTitle(string title)
        {
            Console.SetCursorPosition(4, 0);
            Console.WriteLine(title);
        }
    }
}
