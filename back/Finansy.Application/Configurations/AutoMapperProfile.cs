using AutoMapper;
using Finansy.Application.Dtos.v1.Administrador;
using Finansy.Application.Dtos.V1.Gerente;
using Finansy.Application.Dtos.V1.Unidade;
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
        
        #region Gerente

        CreateMap<GerenteDto, Gerente>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cnpj = dest.Cnpj.SomenteNumeros())
            .ReverseMap();
        CreateMap<AdicionarGerenteDto, Gerente>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cnpj = dest.Cnpj.SomenteNumeros())
            .ReverseMap();
        CreateMap<AtualizarGerenteDto, Gerente>()
            .AfterMap((_, dest) => dest.Cpf = dest.Cpf.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros())
            .AfterMap((_, dest) => dest.Cnpj = dest.Cnpj.SomenteNumeros())
            .ReverseMap();

        #endregion
        
        #region Unidade

        CreateMap<UnidadeDto, Unidade>()
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Nire = dest.Nire.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros()!)
            .ReverseMap();
        CreateMap<AdicionarUnidadeDto, Unidade>()
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Nire = dest.Nire.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros()!)
            .ReverseMap();
        CreateMap<AtualizarUnidadeDto, Unidade>()
            .AfterMap((_, dest) => dest.Telefone = dest.Telefone.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Nire = dest.Nire.SomenteNumeros()!)
            .AfterMap((_, dest) => dest.Cep = dest.Cep.SomenteNumeros()!)
            .ReverseMap();

        #endregion
    }
}