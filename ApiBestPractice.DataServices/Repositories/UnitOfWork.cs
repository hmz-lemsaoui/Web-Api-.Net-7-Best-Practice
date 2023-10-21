using ApiBestPractice.DataServices.Data;
using ApiBestPractice.DataServices.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ApiBestPractice.DataServices.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;
    public IDriverRepository Drivers { get; }
    public IAchievementRepository Achievements { get; }
    public ITicketRepository Tickets { get; }
    public IEventRepository Events { get; }

    public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");
        Drivers = new DriverRepository(logger, context);
        Achievements = new AchievementRepository(logger, context);
        Tickets = new TicketRepository(logger, context);
        Events = new EventRepository(logger, context);
    }
    
    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}