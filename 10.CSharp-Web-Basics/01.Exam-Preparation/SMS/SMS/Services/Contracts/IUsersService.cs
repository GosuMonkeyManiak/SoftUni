namespace SMS.Services.Contracts
{
    public interface IUsersService
    {
        bool Register(
            string username,
            string email,
            string password);

        (bool, string) Login(string username, string password);

        string GetUsernameById(string id);
    }
}
