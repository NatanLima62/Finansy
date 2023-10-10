// using Finansy.Domain.Entities;
// using FluentValidation;
//
// namespace Finansy.Domain.Validators;
//
// public class UsuarioValidator : AbstractValidator<Usuario>
// {
//     public UsuarioValidator()
//     {
//         RuleFor(a => a.Email)
//             .EmailAddress();
//         
//         RuleFor(a => a.Nome)
//             .Length(3, 120)
//             .WithMessage("Nome deve ter entre 3 e 120 caracteres");
//         
//         RuleFor(a => a.Senha)
//             .Length(8, 20)
//             .WithMessage("Nome deve ter entre 8 e 20 caracteres");
//     }
// }