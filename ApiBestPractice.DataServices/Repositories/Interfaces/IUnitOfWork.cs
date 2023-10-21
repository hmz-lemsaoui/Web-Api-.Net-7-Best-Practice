namespace ApiBestPractice.DataServices.Repositories.Interfaces;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }
    IAchievementRepository Achievements { get; }
    ITicketRepository Tickets { get; }
    IEventRepository Events { get; }

    Task<bool> CompleteAsync();
}