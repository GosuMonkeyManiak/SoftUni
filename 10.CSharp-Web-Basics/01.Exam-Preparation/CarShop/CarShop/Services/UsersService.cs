namespace CarShop.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Model;

    public class UsersService : IUsersService
    {
        private readonly IHashingService hashingService;
        private readonly CarShopDbContext dbContext;

        public UsersService(
            IHashingService hashingService,
            CarShopDbContext dbContext)
        {
            this.hashingService = hashingService;
            this.dbContext = dbContext;
        }

        public bool Register(
            string username, 
            string email, 
            string password, 
            string typeOfUser)
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
                IsMechanic = typeOfUser.ToLower() != "client"
            };

            this.dbContext
                .Users
                .Add(user);

            this.dbContext.SaveChanges();

            return true;
        }

        public (bool, string) Login(string username, string password)
        {
            var user = this.dbContext
                .Users
                .SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                return (false, null);
            }

            var hashedFormPassword = this.hashingService
                .HashPassword(password);

            if (hashedFormPassword != user.Password)
            {
                return (false, null);
            }

            return (true, user.Id);
        }

        public bool IsMechanic(string userId)
            => this.dbContext
                .Users
                .SingleOrDefault(u => u.Id == userId)
                .IsMechanic;

        private bool IsUserExist(string username)
            => this.dbContext
                .Users
                .FirstOrDefault(u => u.Username == username) != null;

    }
}
