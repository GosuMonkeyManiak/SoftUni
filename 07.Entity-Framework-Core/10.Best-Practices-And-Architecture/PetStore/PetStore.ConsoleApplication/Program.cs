namespace PetStore.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartUp startUp = new StartUp();

            Engine engine = new Engine(startUp.BuildServiceProvider());
            engine.Run();
        }
    }
}
