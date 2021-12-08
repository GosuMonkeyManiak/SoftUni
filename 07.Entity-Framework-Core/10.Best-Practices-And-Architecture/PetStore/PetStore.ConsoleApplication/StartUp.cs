namespace PetStore.ConsoleApplication
{
    using Controllers;
    using Controllers.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using AutoMapper;
    using Core.Contracts;
    using Core.MapperProfiler;
    using Core.Services;
    using Data;
    using Data.Common;
    using Data.Repositories;
    using Models;

    public class StartUp
    {
        public StartUp()
        {
            
        }

        public IServiceProvider BuildServiceProvider()
        {
            return ServiceCollection().BuildServiceProvider();
        }

        private IServiceCollection ServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IRegisterController, RegisterController>();
            services.AddScoped<IUserRegisterService, UserRegisterService>();
            services.AddScoped<IPetStoreRepository<User>, PetStoreRepository<User>>();
            services.AddDbContext<PetStoreContext>();
            services.AddAutoMapper(config => config.AddProfile(new PetStoreProfile()));
            services.AddScoped<ILoginController, LoginController>();
            services.AddScoped<IUserLoginService, UserLoginService>();

            return services;
        }
    }
}
