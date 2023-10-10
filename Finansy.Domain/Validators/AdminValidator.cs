using Finansy.Domain.Entities;
using FluentValidation;

namespace Finansy.Domain.Validators;

public class AdminValidator : AbstractValidator<Administrador>
{
    public AdminValidator()
    {
        RuleFor(a => a.Email)
            .EmailAddress();
        
        RuleFor(a => a.Nome)
            .Length(3, 120)
            .WithMessage("Nome deve ter entre 3 e 120 caracteres");
        
        RuleFor(a => a.Senha)
            .Length(8, 20)
            .WithMessage("Nome deve ter entre 8 e 20 caracteres");

        RuleFor(a => a.Cpf)
            .Length(11, 14)
            .WithMessage("Cpf deve ter entre 11 e 14 caracteres");
        
        RuleFor(a => a.Telefone)
            .Length(9, 14)
            .WithMessage("Telefone deve ter entre 9 e 14 caracteres");
    }
}