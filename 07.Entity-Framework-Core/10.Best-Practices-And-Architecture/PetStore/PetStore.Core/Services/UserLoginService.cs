namespace PetStore.Core.Services
{
    using AutoMapper;
    using Contracts;
    using Data.Common;
    using Models.Input;
    using PetStore.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;

    public class UserLoginService : IUserLoginService
    {
        private IPetStoreRepository<User> usersRepository;
        private IMapper mapper;

        public UserLoginService(
            IPetStoreRepository<User> _usersRepository,
            IMapper _mapper)
        {
            usersRepository = _usersRepository;
            mapper = _mapper;
        }

        public bool Login(ICollection<KeyValuePair<string, string>> userCredentials)
        {
            UserLoginInput userDto = Transformation(userCredentials);

            if (!DtoValidator.IsValid(userDto))
            {
                return false;
            }

            User userToFind = mapper.Map<User>(userDto);

            User user = usersRepository
                .AllAsNoTracking()
                .SingleOrDefault(u => u.UserName == userToFind.UserName);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        private UserLoginInput Transformation(ICollection<KeyValuePair<string, string>> userCredentials)
        {
            UserLoginInput user = new UserLoginInput();

            var userCredentialsLocal = userCredentials.ToList();

            user.UserName = userCredentialsLocal[0].Value;
            user.Password = userCredentialsLocal[1].Value;

            return user;
        }
    }
}
