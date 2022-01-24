namespace SoftUniCoursePlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "course start")
                {
                    for (int i = 0; i < schedule.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{schedule[i]}");
                    }
                    break;
                }

                string[] commandParts = command
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandParts[0] == "Add")
                {
                    if (!schedule.Contains(commandParts[1]))
                    {
                        schedule.Add(commandParts[1]);
                    }
                }
                else if (commandParts[0] == "Insert")
                {
                    int index = int.Parse(commandParts[2]);

                    if (!schedule.Contains(commandParts[1]) && (index >= 0 && index < schedule.Count))
                    {
                        schedule.Insert(index, commandParts[1]);
                    }
                }
                else if (commandParts[0] == "Remove")
                {
                    if (schedule.Contains(commandParts[1]))
                    {
                        schedule.Remove(commandParts[1]);
                        schedule.Remove($"{commandParts[1]}-Exercise");
                    }
                }
                else if (commandParts[0] == "Swap")
                {
                    if (schedule.Contains(commandParts[1]) 
                        && schedule.Contains($"{commandParts[1]}-Exercise") 
                        && schedule.Contains(commandParts[2])
                        && schedule.Contains($"{commandParts[2]}-Exercise"))
                    {
                        int indexFirstLesson = schedule.IndexOf(commandParts[1]);
                        int indexFirstExercise = schedule.IndexOf($"{commandParts[1]}-Exercise");
                        int indexSecondLesson = schedule.IndexOf(commandParts[2]);
                        int indexSecondExercise = schedule.IndexOf($"{commandParts[2]}-Exercise");

                        schedule[indexFirstLesson] = commandParts[2];
                        schedule[indexSecondLesson] = commandParts[1];

                        schedule[indexFirstExercise] = commandParts[2] + "-Exercise";
                        schedule[indexSecondExercise] = commandParts[1] + "-Exercise";
                    }
                    else if (schedule.Contains(commandParts[1])
                        && schedule.Contains($"{commandParts[1]}-Exercise")
                        && schedule.Contains(commandParts[2]))
                    {
                        int indexFirstExercise = schedule.IndexOf($"{commandParts[1]}-Exercise");
                        schedule.RemoveAt(indexFirstExercise);

                        int indexFirstLesson = schedule.IndexOf(commandParts[1]);
                        int indexSecondLesson = schedule.IndexOf(commandParts[2]);

                        schedule[indexFirstLesson] = commandParts[2];
                        schedule[indexSecondLesson] = commandParts[1];

                        if (indexSecondLesson + 1 >= schedule.Count)
                        {
                            schedule.Add($"{commandParts[1]}-Exercise");
                        }
                        else
                        {
                            schedule.Insert(indexSecondLesson + 1, $"{commandParts[1]}-Exercise");
                        }

                    }
                    else if (schedule.Contains(commandParts[1])
                             && schedule.Contains(commandParts[2])
                             && schedule.Contains($"{commandParts[2]}-Exercise"))
                    {
                        int indexSecondExercise = schedule.IndexOf($"{commandParts[2]}-Exercise");
                        schedule.RemoveAt(indexSecondExercise);

                        int indexFirstLesson = schedule.IndexOf(commandParts[1]);
                        int indexSecondLesson = schedule.IndexOf(commandParts[2]);

                        schedule[indexFirstLesson] = commandParts[2];
                        schedule[indexSecondLesson] = commandParts[1];

                        if (indexFirstLesson + 1 >= schedule.Count)
                        {
                            schedule.Add($"{commandParts[2]}-Exercise");
                        }
                        else
                        {
                            schedule.Insert(indexFirstLesson + 1, $"{commandParts[2]}-Exercise");
                        }
                        
                    }
                    else if (schedule.Contains(commandParts[1]) 
                             && schedule.Contains(commandParts[2]))
                    {
                        int indexFirstLesson = schedule.IndexOf(commandParts[1]);
                        int indexSecondLesson = schedule.IndexOf(commandParts[2]);

                        schedule[indexFirstLesson] = commandParts[2];
                        schedule[indexSecondLesson] = commandParts[1];
                    }
                }
                else if (commandParts[0] == "Exercise")
                {
                    if (schedule.Contains(commandParts[1]) 
                        && !schedule.Contains($"{commandParts[1]}-Exercise"))
                    {
                        int lessonIndex = schedule.IndexOf(commandParts[1]);

                        if (lessonIndex == schedule.Count - 1)
                        {
                            schedule.Add($"{commandParts[1]}-Exercise");
                        }
                        else
                        {
                            schedule.Insert(lessonIndex + 1, $"{commandParts[1]}-Exercise");
                        }
                    }
                    else if(!schedule.Contains(commandParts[1]) 
                            && !schedule.Contains($"{commandParts[1]}-Exercise"))
                    {
                        schedule.Add(commandParts[1]);
                        schedule.Add($"{commandParts[1]}-Exercise");
                    }
                }
            }
        }
    }
}
