using ApiBestPractice.Entities.Entities;

namespace ApiBestPractice.DataServices.Repositories.Interfaces;

public interface IAchievementRepository : IGenericRepository<Achievement>
{
    Task<Achievement?> GetDriverAchievements(Guid driverId);
}