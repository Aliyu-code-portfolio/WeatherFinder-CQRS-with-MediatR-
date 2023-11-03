using AutoMapper;
using MediatR;
using WeatherFinder.Application.Queries.UserQuery;
using WeatherFinder.Persistence.Repository.Abstractions;
using WeatherFinder.Shared.DTOs.Response;

namespace WeatherFinder.Application.Handlers.UserHandler
{
    internal sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
    {
        private IUserRepository userRepository;
        private IMapper mapper;
        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetById(request.id, request.trackChanges);
            var userDto = mapper.Map<UserResponseDto>(user);
            return userDto;
        }
    }
}
