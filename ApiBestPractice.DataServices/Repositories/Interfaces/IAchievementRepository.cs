using ApiBestPractice.Entities.Entities;

namespace ApiBestPractice.DataServices.Repositories.Interfaces;

public interface IAchievementRepository : IGenericRepository<Achievement>
{
    Task<IEnumerable<Achievement>> GetDriverAchievements(Guid driverId);
}