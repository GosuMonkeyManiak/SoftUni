namespace SMS.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;

    public class UsersService : IUsersService
    {
        private readonly SMSDbContext dbContext;
        private readonly IHashingService hashingService;

        public UsersService(
            SMSDbContext dbContext,
            IHashingService hashingService)
        {
            this.dbContext = dbContext;
            this.hashingService = hashingService;
        }

        public bool Register(string username, string email, string password)
        {
            if (IsUserExist(username))
            {
                return false;
            }

            var user = new User()
            {
                Username = username,
                Email = email,
                Password = this.hashingService.HashPassword(password),
                Cart = new Cart()
            };

            this.dbContext
                .Users
                .Add(user);

            this.dbContext.SaveChanges();

            return true;
        }

        public (bool, string) Login(string username, string password)
        {
            if (!IsUserExist(username))
            {
                return (false, null);
            }

            var user = GetUserByUsername(username);

            var formHashedPassword = this.hashingService
                .HashPassword(password);

            if (user.Password != formHashedPassword)
            {
                return (false, null);
            }

            return (true, user.Id);
        }

        public string GetUsernameById(string id)
            => this.dbContext
                .Users
                .SingleOrDefault(u => u.Id == id)
                .Username;

        private bool IsUserExist(string username)
            => this.dbContext
                .Users
                .FirstOrDefault(u => u.Username == username) != null;

        private User GetUserByUsername(string username)
            => this.dbContext
                .Users
                .SingleOrDefault(u => u.Username == username);
    }
}
