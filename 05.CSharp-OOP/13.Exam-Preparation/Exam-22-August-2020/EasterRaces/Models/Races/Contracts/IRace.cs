using System.Collections.Generic;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Races.Contracts
{
    public interface IRace
    {
        string Name { get; }

        int Laps { get; }

        IReadOnlyCollection<IDriver> Drivers { get; }

        void AddDriver(IDriver driver);

    }
}