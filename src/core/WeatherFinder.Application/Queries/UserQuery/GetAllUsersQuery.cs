using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Shared.DTOs.Response;

namespace WeatherFinder.Application.Queries.UserQuery
{
    public sealed record GetAllUsersQuery(bool TrackChanges):IRequest<IEnumerable<UserResponseDto>>;
}
