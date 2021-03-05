using System;
using System.Collections.Generic;
using CollectionHierarchy.Contract;

namespace CollectionHierarchy.Model
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> items;

        public AddRemoveCollection()
        {
            items = new List<string>();
        }

        public int Add(string item)
        {
            items.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            try
            {
                string lastElement = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);

                return lastElement;
            }
            catch (Exception )
            {

            }

            return null;
        }
    }
}