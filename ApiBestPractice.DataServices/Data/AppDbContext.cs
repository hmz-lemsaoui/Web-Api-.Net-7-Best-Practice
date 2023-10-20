global using Microsoft.EntityFrameworkCore;
using ApiBestPractice.Entities.Entities;

namespace ApiBestPractice.DataServices.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public virtual Driver Drivers  { get; set; }
    public virtual Achievement Achievements { get; set; }

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
    }
}