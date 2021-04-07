using System.Collections.Generic;

namespace EasterRaces.Repositories.Contracts
{
    public interface IRepository<T>
    {
        T GetByName(string name);

        IReadOnlyCollection<T> GetAll();

        void Add(T model);

        bool Remove(T model);
    }
}