using System.Collections.Generic;

namespace INStock.Contracts
{
    public interface ITrackingSystem
    {
        int Count { get; }
        // – Returns the number of products currently in stock.

        IProduct this[int index] { get; set; }
        // - Indexer
        // 

        void Add(IProduct product);
        // – Add the new manufactured Product in stock. 

        bool Contains(IProduct product);
        // – Checks if a particular product is in stock. *Keep in mind that only labels are unique.

        IProduct Find(int index);
        // – Return the N-th product that was added in stock. The index is based on insertion order in the data structure. If such index is not present, throw IndexOutOfRangeException.

        IProduct FindByLabel(string label);
        // – Returns the product with a given label, throws ArgumentException if no such product is in stock.

        List<IProduct> FindAllInPriceRange(decimal lowerPrice, decimal higherPrice);
        // – Returns all products within given price range (lower end and higher end are inclusive). Keep in mind that they should be returned in descending order. If there are no such products, return empty enumeration (collection).

        List<IProduct> FindAllByPrice(decimal price);
        // – Returns all products in stock with given price or empty collection if none were found.

        IProduct FindMostExpensiveProducts();
        // – Returns the most expensive product in stock.

        List<IProduct> FindAllByQuantity(int quantity);
        // – Returns all products in stock with given remaining quantity. If there is no product with identical quantity, return empty enumeration.

        //IEnumerable<IProduct> GetEnumerator<IProduct>();
        // – Returns all products in stock.
    }
}