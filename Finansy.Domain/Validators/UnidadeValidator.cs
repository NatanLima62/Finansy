using Finansy.Domain.Entities;
using FluentValidation;

namespace Finansy.Domain.Validators;

public class UnidadeValidator : AbstractValidator<Unidade>
{
    public UnidadeValidator()
    {
        RuleFor(u => u.Nome)
            .Length(3, 120)
            .WithMessage("Nome deve ter entre 3 e 120 caracteres");
        
        RuleFor(u => u.Telefone)
            .Length(9, 14)
            .WithMessage("Telefone deve ter entre 9 e 14 caracteres");
        
        RuleFor(u => u.Nire)
            .Length(11, 11)
            .WithMessage("Nire deve ter 11 caracteres");
        
        RuleFor(u => u.Cep)
            .Length(8, 9)
            .WithMessage("Cep deve ter entre 8 e 9 caracteres");
        
        RuleFor(u => u.Logradouro)
            .Length(3, 120)
            .WithMessage("Logradouro deve ter entre 3 e 120 caracteres");
        
        RuleFor(u => u.Complemento)
            .Length(3, 120)
            .WithMessage("Complemento deve ter entre 3 e 120 caracteres");
        
        RuleFor(u => u.Bairro)
            .Length(3, 120)
            .WithMessage("Bairro deve ter entre 3 e 120 caracteres");
        
        RuleFor(u => u.Cidade)
            .Length(3, 120)
            .WithMessage("Cidade deve ter entre 3 e 120 caracteres");
        
        RuleFor(u => u.Estado)
            .Length(3, 120)
            .WithMessage("Estado deve ter entre 3 e 120 caracteres");
    }
}