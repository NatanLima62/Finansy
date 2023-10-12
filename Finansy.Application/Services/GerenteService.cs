using AutoMapper;
using Finansy.Application.Contracts;
using Finansy.Application.Dtos.V1.Gerente;
using Finansy.Application.Notifications;
using Finansy.Domain.Contracts.Repositories;
using Finansy.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Finansy.Application.Services;

public class GerenteService : BaseService, IGerenteService
{
    private readonly IGerenteRepository _gerenteRepository;
    private readonly IPasswordHasher<Gerente> _passwordHasher;
    public GerenteService(IMapper mapper, INotificator notificator, IGerenteRepository gerenteRepository, IPasswordHasher<Gerente> passwordHasher) : base(mapper, notificator)
    {
        _gerenteRepository = gerenteRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<GerenteDto?> Adicionar(AdicionarGerenteDto dto)
    {
        var gerente = Mapper.Map<Gerente>(dto);
        if (!await Validar(gerente))
        {
            return null;
        }

        gerente.Senha = _passwordHasher.HashPassword(gerente, gerente.Senha);
        _gerenteRepository.Adicionar(gerente);
        if (await _gerenteRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<GerenteDto>(gerente);
        }
        
        Notificator.Handle("Não foi possivel cadastrar o gerente");
        return null;
    }

    public async Task<GerenteDto?> Atualizar(int id, AtualizarGerenteDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem");
            return null;
        }

        var gerente = await _gerenteRepository.ObterPorId(dto.Id);
        if (gerente == null)
        {
            Notificator.HandleNotFoundResourse();
            return null;
        }

        Mapper.Map(dto, gerente);
        if (!await Validar(gerente))
        {
            return null;
        }
        
        _gerenteRepository.Atualizar(gerente);
        if (await _gerenteRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<GerenteDto>(gerente);
        }
        
        Notificator.Handle("Não foi possivel atualizar o gerente");
        return null;
    }

    public async Task<GerenteDto?> ObterPorId(int id)
    {
        var gerente = await _gerenteRepository.ObterPorId(id);
        if (gerente != null)
        {
            return Mapper.Map<GerenteDto>(gerente);
        }
        Notificator.HandleNotFoundResourse();
        return null;
    }

    public async Task<GerenteDto?> ObterPorEmail(string email)
    {
        var gerente = await _gerenteRepository.ObterPorEmail(email);
        if (gerente != null)
        {
            return Mapper.Map<GerenteDto>(gerente);
        }
        Notificator.HandleNotFoundResourse();
        return null;
    }

    public async Task Ativar(int id)
    {
        var gerente = await _gerenteRepository.ObterPorId(id);
        if (gerente == null)
        {
            Notificator.HandleNotFoundResourse();
            return;    
        }

        gerente.Desativado = false;
        _gerenteRepository.Atualizar(gerente);
        if (await _gerenteRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível ativar o gerente");
    }

    public async Task Desativar(int id)
    {
        var gerente = await _gerenteRepository.ObterPorId(id);
        if (gerente == null)
        {
            Notificator.HandleNotFoundResourse();
            return;    
        }

        gerente.Desativado = true;
        _gerenteRepository.Atualizar(gerente);
        if (await _gerenteRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível desativar o gerente");
    }
    
    private async Task<bool> Validar(Gerente gerente)
    {
        if (!gerente.Validate(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }

        var administradorExistente = await _gerenteRepository.Any(c =>
            c.Email == gerente.Email || c.Cpf == gerente.Cpf || c.Cnpj == gerente.Cnpj && c.Id != gerente.Id);
        if (administradorExistente)
        {
            Notificator.Handle($"Já existe um gerente {(gerente.Desativado ? "desativado" : "ativado")} cadastrado com essas informações");
        }

        return !Notificator.HasNotification;
    }
}