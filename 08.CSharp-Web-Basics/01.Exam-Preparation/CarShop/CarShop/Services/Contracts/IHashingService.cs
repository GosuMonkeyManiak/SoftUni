namespace CarShop.Services.Contracts
{
    public interface IHashingService
    {
        string HashPassword(string password);
    }
}
