namespace PetStore.Core.Contracts
{
    using System.Collections.Generic;

    public interface IUserRegisterService
    {
        bool Register(ICollection<KeyValuePair<string, string>> userCredentials);
    }
}
