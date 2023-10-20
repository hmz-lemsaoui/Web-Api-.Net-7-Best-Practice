using ApiBestPractice.DataServices.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiBestPractice.Api.Controllers;
[ApiController]
[Route("api/{controller}")]
public class DriverController : BaseController
{
    public DriverController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
}