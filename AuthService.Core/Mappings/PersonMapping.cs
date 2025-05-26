using AuthService.Core.DTO.Auth;
using AutoMapper;
using WarehouseMaster.Domain.Entities;

namespace AuthService.Core.Mappings
{
    public class PersonMapping: Profile
    {
        public PersonMapping()
        {
            CreateMap<AuthRequest, Person>();
            CreateMap<SignupRequest, Person>();

            CreateMap<Person, AuthResponse>();
            CreateMap<Person, PersonResponse>();

           // CreateMap<PersonResponse, PersonalMessageResponse>()
            //   .ForMember(dest => dest.SenderLogin, opt => opt.MapFrom(src => src.Login));
        }
    }
}
