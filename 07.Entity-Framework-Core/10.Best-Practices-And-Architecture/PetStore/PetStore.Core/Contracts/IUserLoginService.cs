namespace PetStore.Core.Contracts
{
    using System.Collections.Generic;

    public interface IUserLoginService
    {
        bool Login(ICollection<KeyValuePair<string, string>> userCredentials);
    }
}