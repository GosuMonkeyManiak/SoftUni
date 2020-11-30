using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Product
    {
        private string productName;
        private int productCost;

        public string ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }
        public int ProductCost
        {
            get { return this.productCost; }
            set { this.productCost = value; }
        }
    }
}
