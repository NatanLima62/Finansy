using AutoMapper;
using Finansy.Application.Contracts;
using Finansy.Application.Dtos.V1.Unidade;
using Finansy.Application.Notifications;
using Finansy.Domain.Contracts.Repositories;
using Finansy.Domain.Entities;

namespace Finansy.Application.Services;

public class UnidadeService : BaseService, IUnidadeService
{
    private readonly IUnidadeRepository _unidadeRepository;
    public UnidadeService(IMapper mapper, INotificator notificator, IUnidadeRepository unidadeRepository) : base(mapper, notificator)
    {
        _unidadeRepository = unidadeRepository;
    }

    public async Task<UnidadeDto?> Adicionar(AdicionarUnidadeDto dto)
    {
        var unidade = Mapper.Map<Unidade>(dto);
        if (!await Validar(unidade))
        {
            return null;
        }

        _unidadeRepository.Adicionar(unidade);
        if (await _unidadeRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<UnidadeDto>(unidade);
        }
        
        Notificator.Handle("Não foi possivel cadastrar a unidade");
        return null;
    }

    public async Task<UnidadeDto?> Atualizar(int id, AtualizarUnidadeDto dto)
    {
        if (id != dto.Id)
        {
            Notificator.Handle("Os ids não conferem");
            return null;
        }

        var unidade = await _unidadeRepository.ObterPorId(dto.Id);
        if (unidade == null)
        {
            Notificator.HandleNotFoundResourse();
            return null;
        }

        Mapper.Map(dto, unidade);
        if (!await Validar(unidade))
        {
            return null;
        }
        
        _unidadeRepository.Atualizar(unidade);
        if (await _unidadeRepository.UnitOfWork.Commit())
        {
            return Mapper.Map<UnidadeDto>(unidade);
        }
        
        Notificator.Handle("Não foi possivel atualizar a unidade");
        return null;
    }

    public async Task<UnidadeDto?> ObterPorId(int id)
    {
        var unidade = await _unidadeRepository.ObterPorId(id);
        if (unidade != null)
        {
            return Mapper.Map<UnidadeDto>(unidade);
        }
        Notificator.HandleNotFoundResourse();
        return null;
    }

    public async Task Ativar(int id)
    {
        var unidade = await _unidadeRepository.ObterPorId(id);
        if (unidade == null)
        {
            Notificator.HandleNotFoundResourse();
            return;    
        }

        unidade.Desativado = false;
        _unidadeRepository.Atualizar(unidade);
        if (await _unidadeRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível ativar a unidade");
    }

    public async Task Desativar(int id)
    {
        var unidade = await _unidadeRepository.ObterPorId(id);
        if (unidade == null)
        {
            Notificator.HandleNotFoundResourse();
            return;    
        }

        unidade.Desativado = true;
        _unidadeRepository.Atualizar(unidade);
        if (await _unidadeRepository.UnitOfWork.Commit())
        {
            return;
        }
        
        Notificator.Handle("Não foi possível desativar a unidade");
    }
    
    private async Task<bool> Validar(Unidade unidade)
    {
        if (!unidade.Validate(out var validationResult))
        {
            Notificator.Handle(validationResult.Errors);
        }

        var administradorExistente = await _unidadeRepository.Any(c =>
            c.Nome == unidade.Nome && c.Numero == unidade.Numero && c.Id != unidade.Id);
        if (administradorExistente)
        {
            Notificator.Handle($"Já existe uma unidade {(unidade.Desativado ? "desativado" : "ativado")} cadastrada com essas informações");
        }

        return !Notificator.HasNotification;
    }
}