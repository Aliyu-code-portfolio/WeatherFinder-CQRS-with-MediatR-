using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherFinder.Application.Commands.UserCommand;
using WeatherFinder.Application.Queries.UserQuery;
using WeatherFinder.Shared.DTOs.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;

        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _sender.Send(new GetAllUsersQuery(false));
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _sender.Send(new GetUserByIdQuery(id, false));
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] UserRequest userRequest)
        {
            var result = await _sender.Send(new CreateUserCommand(userRequest));
            return Ok(result);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UserRequest userRequest)
        {
            await _sender.Send(new UpdateUserCommand(id, userRequest));
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _sender.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}
