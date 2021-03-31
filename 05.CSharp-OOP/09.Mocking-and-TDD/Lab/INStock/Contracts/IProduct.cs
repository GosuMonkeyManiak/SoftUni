namespace INStock.Contracts
{
    public interface IProduct
    {
        string Label { get; }

        int Quantity { get; }

        decimal Price { get; }
    }
}