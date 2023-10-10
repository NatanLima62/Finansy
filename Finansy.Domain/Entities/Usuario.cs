// using Finansy.Domain.Contracts;
// using Finansy.Domain.Validators;
// using FluentValidation.Results;
//
// namespace Finansy.Domain.Entities;
//
// public class Usuario : Entity, ISoftDelete, IAggregateRoot, ITenant
// {
//     public string Email { get; set; } = null!;
//     public string Nome { get; set; } = null!;
//     public string Senha { get; set; } = null!;
//     public int UnidadeId { get; set; }
//     public bool Ativo { get; set; }
//
//     public override bool Validate(out ValidationResult validationResult)
//     {
//         validationResult = new UsuarioValidator().Validate(this);
//         return validationResult.IsValid;
//     }
//
// }