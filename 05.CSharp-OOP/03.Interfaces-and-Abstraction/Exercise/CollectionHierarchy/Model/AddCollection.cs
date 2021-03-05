using System;
using System.Collections.Generic;
using System.Text;
using CollectionHierarchy.Contract;

namespace CollectionHierarchy.Model
{
    public class AddCollection : IAddCollection
    {
        private List<string> items;

        public AddCollection()
        {
            items = new List<string>();
        }

        public int Add(string item)
        {
            items.Add(item);
            return items.Count - 1;
        }
    }
}
