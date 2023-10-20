namespace ApiBestPractice.DataServices.Repositories.Interfaces;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }
    IAchievementRepository Achievements { get; }

    Task CompleteAsync();
}