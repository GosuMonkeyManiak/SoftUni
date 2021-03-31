using System;
using INStock.Contracts;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private int quantity;
        private decimal price;

        public Product(string label, int quantity, decimal price)
        {
            Label = label;
            Quantity = quantity;
            Price = price;
        }

        public string Label
        {
            get => label;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Label can't be empty or white space.");
                }

                label = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity can't be negative number");
                }

                quantity = value;
            }
        }

        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can't be zero or negative number");
                }

                price = value;
            }
        }
    }
}