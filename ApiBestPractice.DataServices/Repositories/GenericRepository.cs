using ApiBestPractice.DataServices.Data;
using ApiBestPractice.DataServices.Repositories.Interfaces;
using ApiBestPractice.Entities.Entities;
using Microsoft.Extensions.Logging;

namespace ApiBestPractice.DataServices.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly ILogger _Logger;
    protected readonly AppDbContext _context;
    internal readonly DbSet<T> _dbSet;

    protected GenericRepository(ILogger logger, AppDbContext context)
    {
        _Logger = logger;
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> All()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<bool> Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}