namespace SMS.Services.Contracts
{
    public interface IHashingService
    {
        string HashPassword(string password);
    }
}
