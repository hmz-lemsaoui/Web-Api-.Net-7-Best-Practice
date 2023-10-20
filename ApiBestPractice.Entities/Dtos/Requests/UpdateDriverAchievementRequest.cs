namespace ApiBestPractice.Entities.Dtos.Requests;

public class UpdateDriverAchievementRequest
{
    public Guid Id { get; set; }
    public Guid DriverId { get; set; }
    public int RaceWins { get; set; }
    public int RolePosition { get; set; }
    public int FastestLap { get; set; }
    public int WorldChampionship { get; set; }
}