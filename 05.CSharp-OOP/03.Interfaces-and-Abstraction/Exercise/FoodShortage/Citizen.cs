using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthDate;

        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
            Food = 0;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public int Age
        {
            get => age;
            private set => age = value;
        }

        public string Id
        {
            get => id;
            private set => id = value;
        }

        public string BirthDate
        {
            get => birthDate;
            private set => birthDate = value;
        }

        public int Food { get; set; }


        public void ByFood()
        {
            Food += 10;
        }
    }
}
