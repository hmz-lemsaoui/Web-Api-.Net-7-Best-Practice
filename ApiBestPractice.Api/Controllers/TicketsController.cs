using ApiBestPractice.DataServices.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiBestPractice.Api.Controllers;

public class TicketsController : BaseController
{
    public TicketsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        try
        {
            var tickets = await _unitOfWork.Tickets.All();
            return Ok(tickets);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut("{eventId:int}")]
    public async Task<IActionResult> UpdateTicketPrices(int eventId)
    {
        var mainEvent = await _unitOfWork.Events.GetEvent(eventId);
        if (mainEvent == null) return NotFound();

        foreach (var ticket in mainEvent.Tickets)
        {
            ticket.Price *= 1.2;
            ticket.UpdatedDate = DateTime.UtcNow;
        }

        mainEvent.Location += " - at " + DateTime.UtcNow.Millisecond;
        
        await _unitOfWork.CompleteAsync();
        
        return NoContent();
    }
}