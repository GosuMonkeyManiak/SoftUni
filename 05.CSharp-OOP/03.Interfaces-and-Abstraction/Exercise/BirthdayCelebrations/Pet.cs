using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IBirthdateable
    {
        private string name;

        public Pet(string name, string birthdate)
        {
            Name = name;
            BirthDate = birthdate;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public string BirthDate { get; set; }
    }
}
