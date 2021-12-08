namespace PetStore.ConsoleApplication.Controllers.Contracts
{
    using System.Collections.Generic;

    public interface IRegisterController
    {
        bool Register(ICollection<KeyValuePair<string, string>> userCredentials);
    }
}
