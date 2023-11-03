using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Shared.DTOs.Request;
using WeatherFinder.Shared.DTOs.Response;

namespace WeatherFinder.Application.Commands.UserCommand
{
    public sealed record CreateUserCommand(UserRequest userRequest): IRequest<UserResponseDto>;

}
