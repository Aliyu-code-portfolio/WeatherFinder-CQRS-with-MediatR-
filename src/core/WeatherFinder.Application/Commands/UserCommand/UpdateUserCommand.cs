using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Shared.DTOs.Request;

namespace WeatherFinder.Application.Commands.UserCommand
{
    public sealed record UpdateUserCommand(UserRequest userRequest):IRequest<Unit>;
}
