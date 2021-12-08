namespace PetStore.Core.MapperProfiler
{
    using AutoMapper;
    using Models.Input;
    using PetStore.Models;

    public class PetStoreProfile : Profile
    {
        public PetStoreProfile()
        {
            CreateMap<UserRegisterInput, User>();
            CreateMap<UserLoginInput, User>();
        }
    }
}
