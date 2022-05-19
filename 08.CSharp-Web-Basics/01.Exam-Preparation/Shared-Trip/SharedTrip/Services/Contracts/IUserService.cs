namespace SharedTrip.Services.Contracts
{
    using Models;
    using SharedTrip.Models;

    public interface IUserService
    {
        bool RegisterUser(string userName, string email, string password);

        (bool, string) ValidateUserCredentials(string userName, string password);
    }
}
