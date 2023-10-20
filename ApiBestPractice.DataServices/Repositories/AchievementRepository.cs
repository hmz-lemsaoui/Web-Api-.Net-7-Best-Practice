using ApiBestPractice.DataServices.Data;
using ApiBestPractice.DataServices.Repositories.Interfaces;
using ApiBestPractice.Entities.Entities;
using Microsoft.Extensions.Logging;

namespace ApiBestPractice.DataServices.Repositories;

public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
{
    public AchievementRepository(ILogger logger, AppDbContext context) : base(logger, context)
    {
    }

    public Task<IEnumerable<Achievement>> GetDriverAchievements(Guid driverId)
    {
        throw new NotImplementedException();
    }
}