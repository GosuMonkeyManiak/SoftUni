using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkProjects
{
    class Team
    {
        private string teamName;
        private string founder;
        private List<string> members;

        public string TeamName
        {
            get { return this.teamName; }
            set { this.teamName = value; }
        }
        public string Founder
        {
            get { return this.founder; }
            set { this.founder = value; }
        }
        public List<string> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public Team()
        {
            this.members = new List<string>();
        }
        public Team(string teamName, string founder) : this()
        {
            this.teamName = teamName;
            this.founder = founder;

            this.members.Add(this.founder);
        }
    }
}
