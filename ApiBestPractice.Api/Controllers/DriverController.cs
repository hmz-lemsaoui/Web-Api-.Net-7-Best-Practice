using ApiBestPractice.DataServices.Repositories.Interfaces;
using ApiBestPractice.Entities.Dtos.Requests;
using ApiBestPractice.Entities.Dtos.Responses;
using ApiBestPractice.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiBestPractice.Api.Controllers;

public class DriverController : BaseController
{
    public DriverController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetDriver(Guid id)
    {
        var driver = await _unitOfWork.Drivers.GetById(id);
        if (driver == null) return NotFound("Driver not found");

        var result = _mapper.Map<DriverResponse>(driver);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriver(CreateDriverRequest driverRequest)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<Driver>(driverRequest);

        await _unitOfWork.Drivers.Create(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriver), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriver(UpdateDriverRequest driverRequest)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<Driver>(driverRequest);

        await _unitOfWork.Drivers.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var drivers = await _unitOfWork.Drivers.All();

        var result = _mapper.Map<IEnumerable<DriverResponse>>(drivers);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid id)
    {
        var driver = await _unitOfWork.Drivers.GetById(id);
        if (driver == null) return NotFound();
        
        await _unitOfWork.Drivers.Delete(id);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}