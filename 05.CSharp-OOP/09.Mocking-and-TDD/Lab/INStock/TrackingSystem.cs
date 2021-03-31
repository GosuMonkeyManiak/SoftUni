using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock
{
    public class TrackingSystem : ITrackingSystem, IEnumerable<IProduct>
    {
        private List<IProduct> products;
        public TrackingSystem()
        {
            products = new List<IProduct>();
        }

        public int Count => products.Count;

        public IProduct this[int index]
        {
            get => products[index];
            set => products[index] = value;
        }

        public void Add(IProduct product)
        {
            IProduct currentProduct = products
                .FirstOrDefault(p => p.Label == product.Label);

            if (currentProduct != null)
            {
                throw new ArgumentException("That product is exist!");
            }

            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            IProduct currentProduct = products
                .FirstOrDefault(p => p.Label == product.Label);

            return currentProduct != null;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new IndexOutOfRangeException("Index was out of range!");
            }

            return products[index];
        }

        public IProduct FindByLabel(string label)
        {
            if (products.Any(p => p.Label == label) == false)
            {
                throw new ArgumentException("The product does't exist!");
            }

            return products.FirstOrDefault(p => p.Label == label);
        }

        public List<IProduct> FindAllInPriceRange(decimal lowerPrice, decimal higherPrice)
        {
            List<IProduct> productsInPriceRange = products
                .Where(p => p.Price >= lowerPrice && p.Price <= higherPrice)
                .ToList();

            return productsInPriceRange == null ? new List<IProduct>() : productsInPriceRange;
        }

        public List<IProduct> FindAllByPrice(decimal price)
        {
            List<IProduct> productsByPrice = products
                .Where(p => p.Price == price)
                .ToList();

            return productsByPrice == null ? new List<IProduct>() : productsByPrice;
        }
        

        public IProduct FindMostExpensiveProducts()
        {
            decimal maxProductPrice = 0;

            try
            {
                maxProductPrice = products.Max(p => p.Price);
            }
            catch (Exception)
            {
                return null;
            }

            return products.FirstOrDefault(p => p.Price == maxProductPrice);
        }

        public List<IProduct> FindAllByQuantity(int quantity)
        {
            List<IProduct> productsByQuantity = products
                .Where(p => p.Quantity == quantity)
                .ToList();

            return productsByQuantity == null ? new List<IProduct>() : productsByQuantity;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return products[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}