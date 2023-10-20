﻿namespace ApiBestPractice.Entities.Entities;

public class Driver : BaseEntity
{
    public Driver()
    {
        Achievements = new HashSet<Achievement>();
    }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int DriverNumber { get; set; }
    public DateTime DateBirth { get; set; }

    public ICollection<Achievement> Achievements { get; set; }
}