namespace FootballManager.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class PlayersService : IPlayersService
    {
        private readonly FootballManagerDbContext dbContext;

        public PlayersService(FootballManagerDbContext dbContext) 
            => this.dbContext = dbContext;

        public bool TryAdd(
            string userId,
            string fullName, 
            string imageUrl, 
            string position, 
            byte speed, 
            byte endurance, 
            string description)
        {
            if (IsPlayerExist(fullName))
            {
                return false;
            }

            var player = new Player()
            {
                FullName = fullName,
                ImageUrl = imageUrl,
                Position = position,
                Speed = speed,
                Endurance = endurance,
                Description = description
            };

            player
                .UserPlayers
                .Add(new UserPlayer()
                {
                    UserId = userId
                });

            this.dbContext
                .Players
                .Add(player);

            this.dbContext
                .SaveChanges();

            return true;
        }

        public IEnumerable<PlayerDto> All()
            => this.dbContext
                .Players
                .Select(p => new PlayerDto()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description
                })
                .ToList();

        public IEnumerable<PlayerDto> All(string userId) 
            => this.dbContext
                .Users
                .Include(u => u.UserPlayers)
                .ThenInclude(u => u.Player)
                .SingleOrDefault(u => u.Id == userId)
                .UserPlayers
                .Select(up => new PlayerDto()
                {
                    Id = up.PlayerId,
                    FullName = up.Player.FullName,
                    ImageUrl = up.Player.ImageUrl,
                    Position = up.Player.Position,
                    Speed = up.Player.Speed,
                    Endurance = up.Player.Endurance,
                    Description = up.Player.Description
                })
                .ToList();

        public bool IsPlayerExist(int playerId)
            => this.dbContext
                .Players
                .FirstOrDefault(p => p.Id == playerId) != null;

        public bool AddPlayerToUser(int playerId, string userId)
        {
            var user = this.dbContext
                .Users
                .Include(u => u.UserPlayers)
                .SingleOrDefault(u => u.Id == userId);

            bool isUserHavePlayer = user
                .UserPlayers
                .FirstOrDefault(up => up.PlayerId == playerId) != null;

            if (isUserHavePlayer)
            {
                return false;
            }

            var player = this.dbContext
                .Players
                .SingleOrDefault(p => p.Id == playerId);

            user.UserPlayers
                .Add(new UserPlayer()
                {
                    Player = player
                });

            this.dbContext
                .SaveChanges();

            return true;
        }

        public bool Remove(int playerId, string userId)
        {
            var user = this.dbContext
                .Users
                .Include(u => u.UserPlayers)
                .ThenInclude(up => up.Player)
                .SingleOrDefault(u => u.Id == userId);

            var userPlayer = user.UserPlayers
                .FirstOrDefault(up => up.PlayerId == playerId);

            if (userPlayer == null)
            {
                return false;
            }

            this.dbContext
                .UsersPlayers
                .Remove(userPlayer);

            this.dbContext
                .SaveChanges();

            return true;
        }

        private bool IsPlayerExist(string fullName)
            => this.dbContext
                .Players
                .FirstOrDefault(p => p.FullName == fullName) != null;
    }
}
