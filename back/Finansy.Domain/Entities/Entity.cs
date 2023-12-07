using Finansy.Domain.Contracts;
using FluentValidation.Results;

namespace Finansy.Domain.Entities;

public class Entity : BaseEntity, ITracking
{
    public int? CriadoPor { get; set; }
    public DateTime CriadoEm { get; set; }
    public bool CriadoPorAdmin { get; set; }
    public int? AtualizadoPor { get; set; }
    public DateTime AtualizadoEm { get; set; }
    public bool AtualizadoPorAdmin { get; set; }

    public virtual bool Validate(out ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        return validationResult.IsValid;
    }
}