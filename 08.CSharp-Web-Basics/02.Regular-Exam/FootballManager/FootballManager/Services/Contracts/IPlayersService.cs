namespace FootballManager.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IPlayersService
    {
        bool TryAdd(
            string userId,
            string fullName,
            string imageUrl,
            string position,
            byte speed,
            byte endurance,
            string description);

        IEnumerable<PlayerDto> All();

        IEnumerable<PlayerDto> All(string userId);

        bool IsPlayerExist(int playerId);

        bool AddPlayerToUser(int playerId, string userId);

        bool Remove(int playerId, string userId);
    }
}
