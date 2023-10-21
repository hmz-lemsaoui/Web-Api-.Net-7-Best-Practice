using ApiBestPractice.DataServices.Data;
using ApiBestPractice.DataServices.Repositories.Interfaces;
using ApiBestPractice.Entities.Entities;
using Microsoft.Extensions.Logging;

namespace ApiBestPractice.DataServices.Repositories;

public class EventRepository : GenericRepository<Event>, IEventRepository
{
    public EventRepository(ILogger logger, AppDbContext context) : base(logger, context)
    {
    }
    
    public async Task<Event?> GetEvent(int id)
    {
        try
        {
            return await _dbSet.Include(x => x.Tickets)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception e)
        {
            _Logger.LogError(e, "{Repo} get function error", typeof(AchievementRepository));
            throw;
        }
    }
}