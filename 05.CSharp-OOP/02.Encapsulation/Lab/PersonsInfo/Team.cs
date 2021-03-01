using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        private string name;

        public Team(string name)
        {
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
            Name = name;
        }

        public IReadOnlyList<Person> FirstTeam => firstTeam.AsReadOnly();

        public IReadOnlyList<Person> ReserveTeam => reserveTeam.AsReadOnly();

        public string Name
        {
            get => this.name;
            set => name = value;
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
