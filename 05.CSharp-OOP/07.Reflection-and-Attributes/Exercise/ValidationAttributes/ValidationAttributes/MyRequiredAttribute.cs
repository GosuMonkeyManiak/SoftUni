using System;

namespace ValidationAttributes.ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            string temp = (string)obj;

            return !string.IsNullOrEmpty(temp);
        }
    }
}