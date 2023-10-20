using ApiBestPractice.Entities.Dtos.Responses;
using ApiBestPractice.Entities.Entities;
using AutoMapper;

namespace ApiBestPractice.Api.MappingProfile;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Achievement, DriverAchievementResponse>();
        CreateMap<Driver, DriverResponse>();
    }
}