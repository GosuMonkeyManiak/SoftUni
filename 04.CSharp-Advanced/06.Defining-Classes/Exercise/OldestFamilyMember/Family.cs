using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            familyMembers = new List<Person>();
        }

        public List<Person> FamilyMembers
        {
            get { return familyMembers; }
        }

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldest = familyMembers
                .OrderByDescending(x => x.Age)
                .First();

            return oldest;
        }
    }
}
