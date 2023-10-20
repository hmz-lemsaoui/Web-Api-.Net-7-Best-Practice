namespace ApiBestPractice.Entities.Dtos.Responses;

public class DriverResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int DriverNumber { get; set; }
    public DateTime DateBirth { get; set; }
}