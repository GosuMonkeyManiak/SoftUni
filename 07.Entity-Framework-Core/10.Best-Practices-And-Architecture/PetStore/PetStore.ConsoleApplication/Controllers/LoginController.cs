namespace PetStore.ConsoleApplication.Controllers
{
    using System.Collections.Generic;
    using Contracts;
    using Core.Contracts;

    public class LoginController : ILoginController
    {
        private IUserLoginService loginService;

        public LoginController(IUserLoginService _loginService)
        {
            loginService = _loginService;
        }

        public bool Login(ICollection<KeyValuePair<string, string>> userCredentials)
        {
            return loginService.Login(userCredentials);
        }
    }
}
