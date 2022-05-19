namespace FootballManager.Services
{
    using Contracts;
    using System;
    using System.Linq;
    using Data;
    using Data.Models;

    public class UsersService : IUsersService
    {
        private readonly FootballManagerDbContext dbContext;
        private readonly IHashingService hashingService;

        public UsersService(
            FootballManagerDbContext dbContext,
            IHashingService hashingService)
        {
            this.hashingService = hashingService;
            this.dbContext = dbContext;
        }

        public bool RegisterUser(string userName, string email, string password)
        {
            if (IsUserExist(userName))
            {
                return false;
            }

            var user = new User()
            {
                UserName = userName,
                Email = email,
                Password = this.hashingService.HashPassword(password)
            };

            this.dbContext
                .Users
                .Add(user);

            this.dbContext.SaveChanges();

            return true;
        }

        public (bool, string) ValidateUserCredentials(string userName, string password)
        {
            if (!IsUserExist(userName))
            {
                return (false, null);
            }

            var user = this.dbContext
                .Users
                .SingleOrDefault(u => u.UserName == userName);

            var hashedPasswordFromForm = this.hashingService
                .HashPassword(password);

            if (hashedPasswordFromForm != user.Password)
            {
                return (false, null);
            }

            return (true, user.Id);
        }

        private bool IsUserExist(string userName)
            => this.dbContext
                .Users
                .FirstOrDefault(u => u.UserName == userName) != null;
    }
}
