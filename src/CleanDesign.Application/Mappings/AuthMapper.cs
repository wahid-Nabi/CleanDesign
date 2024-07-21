using AutoMapper;
using CleanDesign.Application.Auth.Commands.Register;
using CleanDesign.Application.Auth.Queries.Login;
using CleanDesign.Application.ViewModels;

namespace CleanDesign.Application.Mappings
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            CreateMap<LoginQuery, LoginViewModel>().ReverseMap();
            CreateMap<RegisterCommand, RegisterViewModel>().ReverseMap();
        }
    }
}
