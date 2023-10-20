namespace ApiBestPractice.Entities.Entities;

public class Achievement : BaseEntity
{
    public int RaceWins { get; set; }
    public int RolePosition { get; set; }
    public int FastestLap { get; set; }
    public int WorldChampionship { get; set; }
    public Guid DriverId { get; set; }

    public virtual Driver? Driver { get; set; }
}