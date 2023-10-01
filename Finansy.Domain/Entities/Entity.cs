using Finansy.Domain.Contracts;
using FluentValidation.Results;

namespace Finansy.Domain.Entities;

public class Entity : BaseEntity, ITracking
{
    public int CreatedBy { get; set; }
    public DateTime CreatedIn { get; set; }
    public bool CreatedByAdmin { get; set; }
    public int UpdatedBy { get; set; }
    public int UpdatedIn { get; set; }
    public bool UpdatedByAdmin { get; set; }

    public virtual bool Validate(out ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        return validationResult.IsValid;
    }
}