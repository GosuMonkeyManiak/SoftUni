using System;

namespace CustomException
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Go4to", "124");
            }
            catch (InvalidPersonNameException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
