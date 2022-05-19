namespace FootballManager.Services.Contracts
{
    public interface IHashingService
    {
        string HashPassword(string password);
    }
}
