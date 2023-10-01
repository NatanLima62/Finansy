using Finansy.Domain.Entities;
using FluentValidation;

namespace Finansy.Domain.Validators;

public class AdminValidator : AbstractValidator<Admin>
{
    public AdminValidator()
    {
        RuleFor(a => a.Email)
            .EmailAddress();
        
        RuleFor(a => a.Name)
            .Length(3, 120)
            .WithMessage("Nome deve ter entre 3 e 120 caracteres");
        
        RuleFor(a => a.Password)
            .Length(8, 20)
            .WithMessage("Nome deve ter entre 8 e 20 caracteres");
    }
}