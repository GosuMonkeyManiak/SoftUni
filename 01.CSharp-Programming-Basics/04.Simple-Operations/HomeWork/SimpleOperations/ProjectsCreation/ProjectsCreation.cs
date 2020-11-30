using System;

namespace ProjectsCreation
{
    class ProjectsCreation
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());

            int timeForProjects = projects * 3;

            Console.WriteLine($"The architect {name} will need {timeForProjects} hours to complete {projects} project/s.");
        }
    }
}
