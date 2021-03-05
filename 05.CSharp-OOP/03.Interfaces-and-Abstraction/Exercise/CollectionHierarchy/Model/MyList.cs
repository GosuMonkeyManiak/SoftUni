using System;
using System.Collections.Generic;
using CollectionHierarchy.Contract;

namespace CollectionHierarchy.Model
{
    public class MyList : IMyList
    {
        private List<string> items;

        public MyList()
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
                string firstElement = items[0];
                items.RemoveAt(0);

                return firstElement;
            }
            catch (Exception e)
            {

            }

            return null;
        }

        public int Used => items.Count;
    }
}