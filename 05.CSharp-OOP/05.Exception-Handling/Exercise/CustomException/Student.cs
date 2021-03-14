using System.Linq;

namespace CustomException
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            Name = name;
            this.email = email;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Any(x => char.IsDigit(x)))
                {
                    throw new InvalidPersonNameException("Cannot have digit in the name");
                }

                this.name = value;
            }
        }


    }
}