using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods((BindingFlags) 60);

            foreach (var methodInfo in methods)
            {
                if (methodInfo.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = methodInfo.GetCustomAttributes(false);

                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
                    }
                }
            }

            //var classAttributes = type.CustomAttributes.Any(t => t.AttributeType == typeof(AuthorAttribute));

            //if (classAttributes)
            //{
            //    var attributes = type.GetCustomAttributes();

            //    foreach (AuthorAttribute att in attributes)
            //    {
            //        Console.WriteLine($"{type.Name} is written by {att.Name}");
            //    }
            //}
        }
    }
}