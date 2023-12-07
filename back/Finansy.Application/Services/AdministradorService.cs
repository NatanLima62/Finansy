using AutoMapper;
using Finansy.Application.Contracts;
using Finansy.Application.Dtos.v1.Administrador;
using Finansy.Application.Notifications;
using Finansy.Domain.Contracts.Repositories;
using Finansy.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Finansy.Application.Services;

public class AdministradorService : BaseService, IAdministradorService
{
    private readonly IAdministradorRepository _administradorRepository;
    private readonly IPasswordHasher<Administrador> _passwordHasher;
    public AdministradorService(IMapper mapper, INotificator notificator, IAdministradorRepository administradorRepository, IPasswordHasher<Administrador> passwordHasher) : base(mapper, notificator)
    {
        _administradorRepository = administradorRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<AdministradorDto?> Adicionar(AdicionarAdministradorDto dto)
    {
        var administrador = Mapper.Map<Administrador>(dto);
        if (!await Validar(administrador))
        {
            return null;
        }

        administrador.Senha = _passwordHasher.HashPassword(administrador, administrador.Senha);
        _administradorRepository.Adicionar(administrador);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<AdministradorDto>(administrador);
        }
        
        Notificator.Handle("Não foi possivel cadastrar o administrador");
        return null;
    }

    public async Task<AdministradorDto?> Atualizar(int id, AtualizarAdministradorDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem");
            return null;
        }

        var administrador = await _administradorRepository.ObterPorId(dto.Id);
        if (administrador == null)
        {
            Notificator.HandleNotFoundResourse();
            return null;
        }

        Mapper.Map(dto, administrador);
        if (!await Validar(administrador))
        {
            return null;
        }
        
        _administradorRepository.Atualizar(administrador);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<AdministradorDto>(administrador);
        }
        
        Notificator.Handle("Não foi possivel atualizar o administrador");
        return null;
    }

    public async Task<AdministradorDto?> ObterPorId(int id)
    {
        var administrador = await _administradorRepository.ObterPorId(id);
        if (administrador != null)
        {
            return Mapper.Map<AdministradorDto>(administrador);
        }
        Notificator.HandleNotFoundResourse();
        return null;
    }

    public async Task<AdministradorDto?> ObterPorEmail(string email)
    {
        var administrador = await _administradorRepository.ObterPorEmail(email);
        if (administrador != null)
        {
            return Mapper.Map<AdministradorDto>(administrador);
        }
        Notificator.HandleNotFoundResourse();
        return null;
    }

    public async Task Ativar(int id)
    {
        var administrador = await _administradorRepository.ObterPorId(id);
        if (administrador == null)
        {
            Notificator.HandleNotFoundResourse();
            return;    
        }

        administrador.Desativado = false;
        _administradorRepository.Atualizar(administrador);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível ativar o administrador");
    }

    public async Task Desativar(int id)
    {
        var administrador = await _administradorRepository.ObterPorId(id);
        if (administrador == null)
        {
            Notificator.HandleNotFoundResourse();
            return;    
        }

        administrador.Desativado = true;
        _administradorRepository.Atualizar(administrador);
        if (await _administradorRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível desativar o administrador");
    }

    private async Task<bool> Validar(Administrador administrador)
    {
        if (!administrador.Validate(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }

        var administradorExistente = await _administradorRepository.Any(c =>
            (c.Email == administrador.Email || c.Cpf == administrador.Cpf) && c.Id != administrador.Id);
        if (administradorExistente)
        {
            Notificator.Handle($"Já existe um administrador {(administrador.Desativado ? "desativado" : "ativado")} cadastrado com essas informações");
        }

        return !Notificator.HasNotification;
    }
}