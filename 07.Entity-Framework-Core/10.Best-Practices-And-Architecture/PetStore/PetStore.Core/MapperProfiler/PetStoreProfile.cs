namespace PetStore.Core.MapperProfiler
{
    using AutoMapper;
    using Models.Input;
    using PetStore.Models;
    using Utilities;

    public class PetStoreProfile : Profile
    {
        public PetStoreProfile()
        {
            CreateMap<UserRegisterInput, User>()
                .ForMember(m => m.Password, cfg => cfg.MapFrom(f => PasswordHasher.Hash(f.Password)));
            CreateMap<UserLoginInput, User>()
                .ForMember(m => m.Password, cfg => cfg.MapFrom(f => PasswordHasher.Hash(f.Password)));
        }
    }
}
