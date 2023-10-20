using ApiBestPractice.Entities.Dtos.Requests;
using ApiBestPractice.Entities.Entities;
using AutoMapper;

namespace ApiBestPractice.Api.MappingProfile;

public class ResponseToDomain : Profile
{
    public ResponseToDomain()
    {
        CreateMap<CreateDriverAchievementRequest, Achievement>();
    }
}