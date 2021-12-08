namespace PetStore.Data.Common
{
    public interface IPetStoreRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        
    }
}