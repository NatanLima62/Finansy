using Finansy.Domain.Contracts;
using Finansy.Domain.Validators;
using FluentValidation.Results;

namespace Finansy.Domain.Entities;

public class Unidade : Entity, ISoftDelete, IAggregateRoot
{
    public int AdministradorId { get; set; }
    public int GerenteId { get; set; }
    public string Nome { get; set; } = null!;
    public string? Nire { get; set; }
    public string Telefone { get; set; } = null!;
    public string Cep { get; set; } = null!;
    public string Logradouro { get; set; } = null!;
    public long Numero { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Estado { get; set; } = null!;
    public bool Desativado { get; set; }
    public Gerente Gerente { get; set; } = null!;
    public Administrador Administrador { get; set; } = null!;

    public override bool Validate(out ValidationResult validationResult)
    {
        validationResult = new UnidadeValidator().Validate(this); 
        return validationResult.IsValid;
    }
}