using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Application.Commands.UserCommand;
using WeatherFinder.Domain.Models;
using WeatherFinder.Persistence.Repository.Abstractions;

namespace WeatherFinder.Application.Handlers.UserHandler
{
    internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUserRepository UserRepository, IMapper Mapper)
        {
            userRepository = UserRepository;
            mapper = Mapper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = userRepository.GetById(request.userId, true)??
                throw new Exception("Not found");
            var userUpdate = mapper.Map<User>(request.userRequest);
            mapper.Map(userUpdate, user);
            await userRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
