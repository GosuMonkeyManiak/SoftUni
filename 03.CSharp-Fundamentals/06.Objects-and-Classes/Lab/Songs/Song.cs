using System;
using System.Collections.Generic;
using System.Text;

namespace Songs
{
    class Song
    {
        private string typelist;
        private string name;
        private string time;

        public string TypeList
        {
            get { return this.typelist; }
            set { this.typelist = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Time
        {
            get { return this.time; }
            set { this.time = value; }
        }

    }
}
