global using Microsoft.EntityFrameworkCore;
using ApiBestPractice.Entities.Entities;

namespace ApiBestPractice.DataServices.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public virtual Driver Drivers  { get; set; }
    public virtual Achievement Achievements { get; set; }
    public virtual Ticket Tickets { get; set; }
    public virtual Event Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasOne(x => x.Driver)
                .WithMany(x => x.Achievements)
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FX_Achievement_Driver");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasMany(x => x.Tickets)
                .WithOne()
                .HasForeignKey(x => x.EventId)
                .IsRequired();

            var demoEvent = new Event()
            {
                Id = 1,
                Location = "Casablanca",
                Name = "mara tonne"
            };
            entity.HasData(demoEvent);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            var tickets = Enumerable.Range(1, 5000)
                .Select(id => new Ticket()
                {
                    Id = Guid.NewGuid(),
                    EventId = 1,
                    EventDate = DateTime.Today.AddDays(10),
                    TicketLevel = "First Class",
                    Price = 100,
                    AddedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Status = 1
                });

            entity.HasData(tickets);
        });
    }
}