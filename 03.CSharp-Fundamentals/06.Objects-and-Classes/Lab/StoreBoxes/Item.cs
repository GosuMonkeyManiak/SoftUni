using System;
using System.Collections.Generic;
using System.Text;

namespace StoreBoxes
{
    class Item
    {
        private string name;
        private double price;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

    }
}
