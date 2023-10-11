using AutoMapper;
using Finansy.Application.Dtos.v1.Administrador;
using Finansy.Core.Extensions;
using Finansy.Domain.Entities;

namespace Finansy.Application.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region Administrador

        CreateMap<AdministradorDto, Administrador>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();
        CreateMap<AdicionarAdministradorDto, Administrador>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();
        CreateMap<AtualizarAdministradorDto, Administrador>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .ReverseMap();

        #endregion
    }
}