using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Application.Commands.UserCommand;
using WeatherFinder.Persistence.Repository.Abstractions;

namespace WeatherFinder.Application.Handlers.UserHandler
{
    internal sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public DeleteUserCommandHandler(IUserRepository UserRepository, IMapper Mapper)
        {
            userRepository = UserRepository;
            mapper = Mapper;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetById(request.id, false)
                ?? throw new Exception("Not found");
            userRepository.DeleteUser(user);
            await userRepository.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
