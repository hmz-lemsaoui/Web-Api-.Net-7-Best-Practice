namespace ApiBestPractice.Entities.Dtos.Responses;

public class DriverAchievementResponse
{
    public Guid DriverId { get; set; }
    public int RaceWins { get; set; }
    public int RolePosition { get; set; }
    public int FastestLap { get; set; }
    public int WorldChampionship { get; set; }
}