using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsTwoPointZero
{
    class Student
    {
        private string firstName;
        private string lastName;
        private byte age;
        private string homeTown;

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public byte Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string HomeTown
        {
            get { return this.homeTown; }
            set { this.homeTown = value; }
        }
    }
}

