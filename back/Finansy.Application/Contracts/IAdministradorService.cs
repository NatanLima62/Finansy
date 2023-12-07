using Finansy.Application.Dtos.v1.Administrador;

namespace Finansy.Application.Contracts;

public interface IAdministradorService
{
    Task<AdministradorDto?> Adicionar(AdicionarAdministradorDto dto);
    Task<AdministradorDto?> Atualizar(int id, AtualizarAdministradorDto dto);
    Task<AdministradorDto?> ObterPorId(int id);
    Task<AdministradorDto?> ObterPorEmail(string email);
    Task Ativar(int id);
    Task Desativar(int id);
}