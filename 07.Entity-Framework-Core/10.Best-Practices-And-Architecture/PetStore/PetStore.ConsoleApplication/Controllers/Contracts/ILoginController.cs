namespace PetStore.ConsoleApplication.Controllers.Contracts
{
    using System.Collections.Generic;

    public interface ILoginController
    {
        bool Login(ICollection<KeyValuePair<string, string>> userCredentials);
    }
}