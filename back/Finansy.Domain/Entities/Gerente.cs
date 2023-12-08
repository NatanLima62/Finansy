using Finansy.Domain.Contracts;
using Finansy.Domain.Validators;
using FluentValidation.Results;

namespace Finansy.Domain.Entities;

public class Gerente : Entity, ISoftDelete, IAggregateRoot
{
    public int UnidadeId { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public string? Telefone { get; set; }
    public string Cpf { get; set; } = null!;
    public string? Cnpj { get; set; }
    public bool Desativado { get; set; }
    public Unidade Unidade { get; set; } = null!;

    public override bool Validate(out ValidationResult validationResult)
    {
        validationResult = new GerenteValidator().Validate(this);
        return validationResult.IsValid;
    }
}