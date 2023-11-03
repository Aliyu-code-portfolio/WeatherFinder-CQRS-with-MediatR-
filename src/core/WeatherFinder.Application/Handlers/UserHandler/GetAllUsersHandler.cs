using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Application.Queries.UserQuery;
using WeatherFinder.Domain.Models;
using WeatherFinder.Persistence.Data;
using WeatherFinder.Persistence.Repository.Abstractions;
using WeatherFinder.Shared.DTOs.Response;

namespace WeatherFinder.Application.Handlers.UserHandler
{
    internal sealed class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponseDto>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetAllUsersHandler(IUserRepository UserRepository, IMapper Mapper)
        {
            userRepository = UserRepository;
            mapper = Mapper;
        }

        public async Task<IEnumerable<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users =await userRepository.GetAllUsers(request.TrackChanges);
            var userDto = mapper.Map<IEnumerable<UserResponseDto>>(users);
            return userDto;
        }
    }
    
    
}
