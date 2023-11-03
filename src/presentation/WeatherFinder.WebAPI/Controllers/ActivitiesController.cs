using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherFinder.Application.Queries.ActivityLogQuery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ISender _sender;

        public ActivitiesController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sender.Send(new GetAllActivityQuery(false));
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var result = await _sender.Send(new GetAllUserActivityQuery(id, false));
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _sender.Send(new GetActivityByIdQuery(id, false));
            return Ok(result);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
