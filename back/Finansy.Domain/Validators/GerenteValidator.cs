using Finansy.Domain.Entities;
using FluentValidation;

namespace Finansy.Domain.Validators;

public class GerenteValidator : AbstractValidator<Gerente>
{
    public GerenteValidator()
    {
        RuleFor(g => g.Email)
            .EmailAddress();
        
        RuleFor(g => g.Nome)
            .Length(3, 120)
            .WithMessage("Nome deve ter entre 3 e 120 caracteres");
        
        RuleFor(g => g.Senha)
            .Length(8, 20)
            .WithMessage("Nome deve ter entre 8 e 20 caracteres");

        RuleFor(g => g.Cpf)
            .Length(11, 14)
            .WithMessage("Cpf deve ter entre 11 e 14 caracteres");
        
        RuleFor(g => g.Cnpj)
            .Length(14, 18)
            .WithMessage("Cnpj deve ter entre 14 e 18 caracteres");
        
        RuleFor(g => g.Telefone)
            .Length(9, 14)
            .WithMessage("Telefone deve ter entre 9 e 14 caracteres");
    }
}