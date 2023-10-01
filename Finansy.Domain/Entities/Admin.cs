using Finansy.Domain.Contracts;
using Finansy.Domain.Validators;
using FluentValidation.Results;

namespace Finansy.Domain.Entities;

public class Admin : Entity, ISoftDelete, IAggregateRoot
{
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool Active { get; set; }

    public override bool Validate(out ValidationResult validationResult)
    {
        validationResult = new AdminValidator().Validate(this);
        return validationResult.IsValid;
    }
}