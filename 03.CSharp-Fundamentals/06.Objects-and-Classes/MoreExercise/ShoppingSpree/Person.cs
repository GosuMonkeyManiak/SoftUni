using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private int money;
        private List<Product> products;

        public string PersonName
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int PersonMoney
        {
            get { return this.money; }
            set { this.money = value; }
        }
        public List<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public Person()
        {
            this.products = new List<Product>();
        }
    }
}
