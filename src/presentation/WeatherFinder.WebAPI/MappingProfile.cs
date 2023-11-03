using AutoMapper;
using WeatherFinder.Domain.Models;
using WeatherFinder.Shared.DTOs.Request;
using WeatherFinder.Shared.DTOs.Response;

namespace WeatherFinder.WebAPI
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<UserRequest, User>();
            CreateMap<ActivityLog, ActivityLogResponse>();
        }
    }
}
