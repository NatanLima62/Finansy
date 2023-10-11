using AutoMapper;
using Finansy.Application.Dtos.v1.Administrador;
using Finansy.Domain.Entities;

namespace Finansy.Application.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region Administrador

        CreateMap<Administrador, AdministradorDto>().ReverseMap();
        CreateMap<Administrador, AdicionarAdministradorDto>().ReverseMap();
        CreateMap<Administrador, AtualizarAdministradorDto>().ReverseMap();

        #endregion
    }
}