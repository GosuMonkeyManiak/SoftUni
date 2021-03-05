namespace CollectionHierarchy.Contract
{
    public interface IMyList : IAddRemoveCollection
    {
        int Used { get; }
    }
}