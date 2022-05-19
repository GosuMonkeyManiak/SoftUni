namespace FootballManager.Services.Contracts
{
    public interface IUsersService
    {
        bool RegisterUser(string userName, string email, string password);

        (bool, string) ValidateUserCredentials(string userName, string password);
    }
}
