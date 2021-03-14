using System;

namespace CustomException
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string msg)
            : base(msg)
        {}
    }
}