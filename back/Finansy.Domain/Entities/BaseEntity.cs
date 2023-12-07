using Finansy.Domain.Contracts;

namespace Finansy.Domain.Entities;

public abstract class BaseEntity : IEntity
{
    public int Id { get; set; }
}

