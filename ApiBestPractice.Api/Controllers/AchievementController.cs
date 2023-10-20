using ApiBestPractice.DataServices.Repositories.Interfaces;
using ApiBestPractice.Entities.Dtos.Responses;
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
}