namespace PetStore.ConsoleApplication.Controllers
{
    using Contracts;
    using Core.Contracts;
    using System.Collections.Generic;

    public class RegisterController : IRegisterController
    {
        private IUserRegisterService registerService;

        public RegisterController(IUserRegisterService _registerService)
        {
            registerService = _registerService;
        }

        public bool Register(ICollection<KeyValuePair<string, string>> userCredentials)
        {
            return registerService.Register(userCredentials);
        }
    }
}
