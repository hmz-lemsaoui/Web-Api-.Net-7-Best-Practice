using ApiBestPractice.DataServices.Data;
using ApiBestPractice.DataServices.Repositories.Interfaces;
using ApiBestPractice.Entities.Entities;
using Microsoft.Extensions.Logging;

namespace ApiBestPractice.DataServices.Repositories;

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    public TicketRepository(ILogger logger, AppDbContext context) : base(logger, context)
    {
    }
    
    public new async Task<IEnumerable<Ticket>> All()
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
}