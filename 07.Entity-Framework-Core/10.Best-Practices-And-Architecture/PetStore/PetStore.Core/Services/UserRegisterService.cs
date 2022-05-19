namespace PetStore.Core.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Contracts;
    using Data.Common;
    using Microsoft.EntityFrameworkCore;
    using Models.Input;
    using PetStore.Models;
    using Utilities;

    public class UserRegisterService : IUserRegisterService
    {
        private IPetStoreRepository<User> userRepository;
        private IMapper mapper;

        public UserRegisterService(IPetStoreRepository<User> _userRepository, IMapper _mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;
        }

        public bool Register(ICollection<KeyValuePair<string, string>> userCredentials)
        {
            UserRegisterInput userDto = Transformation(userCredentials);

            if (!DtoValidator.IsValid(userDto))
            {
                return false;
            }

            User userToAdd = mapper.Map<User>(userDto);

            userRepository.AddAsync(userToAdd);
            userRepository.SaveChangesAsync();
            
            return true;
        }

        private UserRegisterInput Transformation(ICollection<KeyValuePair<string, string>> userCredentials)
        {
            UserRegisterInput user = new UserRegisterInput();

            var userCredentialsLocal = userCredentials.ToList();

            user.UserName = userCredentialsLocal[0].Value;
            user.Password = userCredentialsLocal[1].Value;

            return user;
        }
    }
}
