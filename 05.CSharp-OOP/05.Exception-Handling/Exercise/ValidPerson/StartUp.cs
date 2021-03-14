using System;

namespace ValidPerson
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person(string.Empty, "Goshev", 31);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
