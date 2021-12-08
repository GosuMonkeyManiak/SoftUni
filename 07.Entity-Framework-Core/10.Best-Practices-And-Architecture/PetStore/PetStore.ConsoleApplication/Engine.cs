namespace PetStore.ConsoleApplication
{
    using Controllers.Contracts;
    using System;
    using Constants;
    using Microsoft.Extensions.DependencyInjection;
    using Utilities.Enums;
    using Views;

    public class Engine
    {
        private IServiceProvider serviceProvider;

        public Engine(IServiceProvider _serviceProvider)
        {
            this.serviceProvider = _serviceProvider;
        }

        public void Run()
        {
            Beginning:

            ViewResult mainViewResult = WelcomeView.Execute();

            if (mainViewResult == ViewResult.Login)
            {
                Login:

                var userCredentials = LoginView.Execute();
                var loginController = serviceProvider.GetService<ILoginController>();
                bool result = loginController.Login(userCredentials);

                if (result)
                {
                    Console.WriteLine(GlobalConstants.Login_Successfully);
                    Console.ReadKey(intercept:true);
                    goto Main;
                }
                else
                {
                    Console.WriteLine(GlobalConstants.Incorrect_Username_Or_Password);
                    ConsoleKeyInfo pressedKey = Console.ReadKey(intercept:true);

                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        goto Login;
                    }
                    else if(pressedKey.Key == ConsoleKey.Backspace)
                    {
                        goto Beginning;
                    }
                }
            }
            else if (mainViewResult == ViewResult.Register)
            {
                var userCredentials = RegisterView.Execute();
                var registerController = serviceProvider.GetService<IRegisterController>();
                bool result = registerController.Register(userCredentials);

                if (result)
                {
                    Console.WriteLine(GlobalConstants.Register_Successfully);
                    Console.ReadKey(intercept:true);
                    goto Beginning;
                }
                else
                {
                    goto Beginning;
                }
            }

            Main:
            Console.Clear();
            Console.WriteLine("Hi from main page");
        }
    }
}
