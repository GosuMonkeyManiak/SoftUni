namespace SharedTrip.Services.Contracts
{
    public interface IHashingService
    {
        string HashPassword(string password);
    }
}
