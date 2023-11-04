using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherFinder.Application.Commands.UserCommand
{
    public sealed record DeleteUserCommand(string id):IRequest<Unit>;
}
