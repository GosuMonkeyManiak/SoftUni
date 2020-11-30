using System;
using System.Collections.Generic;
using System.Text;

namespace OrderByAge
{
    class Person
    {
        private string name;
        private string id;
        private int age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Person(string name, string id, int age)
        {
            this.name = name;
            this.id = id;
            this.age = age;
        }
    }
}
