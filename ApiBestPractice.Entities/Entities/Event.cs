﻿namespace ApiBestPractice.Entities.Entities;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public List<Ticket> Tickets { get; set; }
}