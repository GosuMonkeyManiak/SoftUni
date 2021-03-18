using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] arrayOfFieldName)
        {
            Type classType = Type.GetType(nameOfClass);
            FieldInfo[] classField = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            var instance = Activator.CreateInstance(classType);

            sb.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (var fieldInfo in classField.Where(f => arrayOfFieldName.Contains(f.Name)))
            {
                sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(instance)}");
            }

            return sb.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] fieldsInfo = classType.GetFields((BindingFlags)60);
            PropertyInfo[] propInfo = classType.GetProperties((BindingFlags)60);

            StringBuilder sb = new StringBuilder();

            foreach (var field in fieldsInfo.Where(f => f.IsPublic))
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var prop in propInfo
                .Select(x => x.GetMethod)
                .Where(m => m.IsPrivate || m.IsFamily))
            {
                sb.AppendLine($"{prop.Name} have to be public!");
            }

            foreach (var propertyInfo in propInfo
                .Select(x => x.SetMethod)
                .Where(s => !s.IsPrivate))
            {
                sb.AppendLine($"{propertyInfo.Name} have to be private!");
            }

            return sb.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] methods = classType.GetMethods(
                BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var methodInfo in methods)
            {
                sb.AppendLine($"{methodInfo.Name}");
            }

            return sb.ToString();
        }

        public string MethodsInfo(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methodInfos = classType.GetMethods((BindingFlags)60);

            StringBuilder sb = new StringBuilder();

            foreach (var method in methodInfos.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in methodInfos.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.ReturnType}");
            }

            return sb.ToString();
        }

    }
}