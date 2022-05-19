namespace CarShop.Services.Contracts
{
    public interface IUsersService
    {
        bool Register(
            string username,
            string email,
            string password,
            string typeOfUser);

        (bool, string) Login(string username, string password);

        bool IsMechanic(string userId);
    }
}
