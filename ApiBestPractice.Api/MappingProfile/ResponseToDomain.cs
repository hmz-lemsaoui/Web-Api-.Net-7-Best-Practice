using ApiBestPractice.Entities.Dtos.Requests;
using ApiBestPractice.Entities.Entities;
using AutoMapper;

namespace ApiBestPractice.Api.MappingProfile;

public class ResponseToDomain : Profile
{
    public ResponseToDomain()
    {
        // achievement
        CreateMap<CreateDriverAchievementRequest, Achievement>();
        CreateMap<UpdateDriverAchievementRequest, Achievement>();
        // driver
        CreateMap<UpdateDriverRequest, Driver>();
        CreateMap<CreateDriverRequest, Driver>();
    }
}