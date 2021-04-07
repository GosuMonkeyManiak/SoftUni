using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IRace GetByName(string name)
        {
            return races.FirstOrDefault(r => r.Name == name);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return races.AsReadOnly();
        }

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}