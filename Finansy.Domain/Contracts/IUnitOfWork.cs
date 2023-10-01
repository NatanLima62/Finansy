namespace Finansy.Domain.Contracts;

public interface IUnitOfWork
{
    Task<bool> Commit();
}