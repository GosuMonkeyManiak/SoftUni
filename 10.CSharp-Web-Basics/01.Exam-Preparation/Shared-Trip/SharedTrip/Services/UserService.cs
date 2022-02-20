namespace SharedTrip.Services
{
    using Contracts;
    using Models;
    using System;
    using System.Linq;
    using Data;
    using Data.Models;
    using SharedTrip.Models;

    public class UserService : IUserService
    {
        private readonly SharedTripDbContext dbContext;
        private readonly IHashingService hashingService;

        public UserService(
            SharedTripDbContext dbContext,
            IHashingService hashingService)
        {
            this.dbContext = dbContext;
            this.hashingService = hashingService;
        }

        public bool RegisterUser(string userName, string email, string password)
        {
            if (GetUserByUsername(userName) != null)
            {
                return false;
            }

            var user = new User()
            {
                Username = userName,
                Email = email,
                Password = hashingService.HashPassword(password)
            };

            dbContext.Users.Add(user);

            dbContext.SaveChanges();

            return true;
        }

        public (bool, string) ValidateUserCredentials(string userName, string password)
        {
            var user = this.dbContext
                .Users
                .SingleOrDefault(u => u.Username == userName);

            if (user == null)
            {
                return (false, null);
            }

            var formHashedPassword = this.hashingService.HashPassword(password);

            if (formHashedPassword != user.Password)
            {
                return (false, null);
            }

            return (true, user.Id);
        }

        private User GetUserByUsername(string username)
            => dbContext.Users.FirstOrDefault(u => u.Username == username);
    }
}
