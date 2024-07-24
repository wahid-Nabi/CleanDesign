using AutoMapper;
using CleanDesign.Application.Commands.Auth.ConfirmPassword;
using CleanDesign.Application.Commands.Auth.Register;
using CleanDesign.Application.Commands.Auth.ResetPassword;
using CleanDesign.Application.Queries.Auth.Login;
using CleanDesign.Application.ViewModels;

namespace CleanDesign.Application.Mappings
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            CreateMap<LoginQuery, LoginViewModel>().ReverseMap();
            CreateMap<RegisterCommand, RegisterViewModel>().ReverseMap();
            CreateMap<ConfirmEmailCommand, ConfirmEmailViewModel>().ReverseMap();
            CreateMap<ResetPasswordCommand, ResetPasswordViewModel>().ReverseMap();
        }
    }
}
