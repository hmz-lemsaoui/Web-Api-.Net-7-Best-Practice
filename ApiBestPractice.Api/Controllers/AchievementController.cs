using ApiBestPractice.DataServices.Repositories.Interfaces;
using ApiBestPractice.Entities.Dtos.Requests;
using ApiBestPractice.Entities.Dtos.Responses;
using ApiBestPractice.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiBestPractice.Api.Controllers;

public class AchievementController : BaseController
{
    public AchievementController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievements(driverId);
        if (driverAchievements == null) return NotFound("Achievement not found");

        var result = _mapper.Map<DriverAchievementResponse>(driverAchievements);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAchievement(CreateDriverAchievementRequest achievementRequest)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<Achievement>(achievementRequest);

        await _unitOfWork.Achievements.Create(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAchievement(UpdateDriverAchievementRequest achievementRequest)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<Achievement>(achievementRequest);

        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}