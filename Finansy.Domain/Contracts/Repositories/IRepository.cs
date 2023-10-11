using System.Linq.Expressions;
using Finansy.Domain.Entities;

namespace Finansy.Domain.Contracts.Repositories;

public interface IRepository<T> : IDisposable where T : BaseEntity, IAggregateRoot
{
    public IUnitOfWork UnitOfWork { get; }
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);
    Task<bool> Any(Expression<Func<T, bool>> expression);
}