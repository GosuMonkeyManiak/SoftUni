using System;
using System.Collections.Generic;
using System.Text;

namespace StoreBoxes
{
    class Box
    {
        private int serialnumber;
        private Item item;
        private int itemQuantity;
        private double priceForBox;

        public int SerialNumber
        {
            get { return this.serialnumber; }
            set { this.serialnumber = value; }
        }
        public Item Item
        {
            get { return this.item; }
            set { this.item = value; }
        }
        public int ItemQuantity
        {
            get { return this.itemQuantity; }
            set { this.itemQuantity = value; }
        }
        public double PriceForBox
        {
            get { return this.priceForBox; }
            set { this.priceForBox = value; }
        }

        public Box()
        {
            serialnumber = 0;
            item = new Item();
            itemQuantity = 0;
            priceForBox = 0.0;
        }
    }
}
