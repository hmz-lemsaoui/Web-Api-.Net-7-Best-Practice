using ApiBestPractice.DataServices.Data;
using ApiBestPractice.DataServices.Repositories.Interfaces;
using ApiBestPractice.Entities.Entities;
using Microsoft.Extensions.Logging;

namespace ApiBestPractice.DataServices.Repositories;

public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
{
    public AchievementRepository(ILogger logger, AppDbContext context) : base(logger, context)
    { }

    public async Task<Achievement?> GetDriverAchievements(Guid driverId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
        }
        catch (Exception e)
        {
            _Logger.LogError(e, "{Repo} update function error", typeof(AchievementRepository));
            throw;
        }
    }
    
    public new async Task<IEnumerable<Achievement>> All()
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
            _Logger.LogError(e, "{Repo} all function error", typeof(AchievementRepository));
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
            _Logger.LogError(e, "{Repo} delete function error", typeof(AchievementRepository));
            throw;
        }
    }

    public new async Task<bool> Update(Achievement entity)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result == null) return false;

            result.DriverId = entity.DriverId;
            result.FastestLap = entity.FastestLap;
            result.RaceWins = entity.RaceWins;
            result.RolePosition = entity.RolePosition;
            result.WorldChampionship = entity.WorldChampionship;
            result.UpdatedDate = DateTime.UtcNow;
            
            return true;
        }
        catch (Exception e)
        {
            _Logger.LogError(e, "{Repo} update function error", typeof(AchievementRepository));
            throw;
        }
    }
}