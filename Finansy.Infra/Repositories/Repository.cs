using System.Linq.Expressions;
using Finansy.Domain.Contracts;
using Finansy.Domain.Contracts.Repositories;
using Finansy.Domain.Entities;
using Finansy.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finansy.Infra.Repositories;

public abstract class Repository<T> : IRepository<T> where T : BaseEntity, IAggregateRoot, new()
{
    private bool _isDisposed;
    private readonly DbSet<T> _dbSet;
    protected readonly BaseApplicationDbContext Context;
    
    public IUnitOfWork UnitOfWork => Context;
    
    protected Repository(BaseApplicationDbContext context)
    {
        Context = context;
        _dbSet = Context.Set<T>();
    }
    public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AsNoTrackingWithIdentityResolution().Where(expression).FirstOrDefaultAsync();
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
            // free managed resources
            Context.Dispose();
        }

        _isDisposed = true;
    }
    
    ~Repository()
    {
        Dispose(false);
    }
}