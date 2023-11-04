using AutoMapper;
using MediatR;
using WeatherFinder.Application.Commands.UserCommand;
using WeatherFinder.Domain.Models;
using WeatherFinder.Persistence.Repository.Abstractions;
using WeatherFinder.Shared.DTOs.Response;

namespace WeatherFinder.Application.Handlers.UserHandler
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponseDto>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(IUserRepository UserRepository, IMapper Mapper)
        {
            userRepository = UserRepository;
            mapper = Mapper;
        }
        public async Task<UserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request.userRequest);
            userRepository.CreateUser(user);
            userRepository.SaveChangeAsync();
            var userCreated = mapper.Map<UserResponseDto>(user);
            return userCreated;
        }
    }
}
