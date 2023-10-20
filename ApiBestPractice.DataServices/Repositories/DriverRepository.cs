using ApiBestPractice.DataServices.Data;
using ApiBestPractice.DataServices.Repositories.Interfaces;
using ApiBestPractice.Entities.Entities;
using Microsoft.Extensions.Logging;

namespace ApiBestPractice.DataServices.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ILogger logger, AppDbContext context) : base(logger, context)
    { }

    public new async Task<IEnumerable<Driver>> All()
    {
        try
        {
            return await _dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _Logger.LogError(e, "{Repo} all function error", typeof(DriverRepository));
            throw;
        }
    }

    public new async Task<bool> Delete(Guid id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) return false;

            result.Status = 0;
            result.UpdatedDate = DateTime.UtcNow;

            return true;
        }
        catch (Exception e)
        {
            _Logger.LogError(e, "{Repo} delete function error", typeof(DriverRepository));
            throw;
        }
    }

    public new async Task<bool> Update(Driver entity)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result == null) return false;
            
            result.DateBirth = entity.DateBirth;
            result.DriverNumber = entity.DriverNumber;
            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.UpdatedDate = DateTime.UtcNow;
            
            return true;
        }
        catch (Exception e)
        {
            _Logger.LogError(e, "{Repo} update function error", typeof(DriverRepository));
            throw;
        }
    }
}