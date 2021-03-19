using System.Linq;
using System.Reflection;
using ValidationAttributes.ValidationAttributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            bool result = true;

            foreach (PropertyInfo propertyInfo in properties)
            {
                var attributes = propertyInfo.GetCustomAttributes()
                    .Where(t => typeof(MyValidationAttribute).IsAssignableFrom(t.GetType()))
                    .ToList();

                var value = propertyInfo.GetValue(obj);

                foreach (MyValidationAttribute att in attributes)
                {
                    result = result && att.IsValid(value);
                }
            }

            return result;
        }
    }
}