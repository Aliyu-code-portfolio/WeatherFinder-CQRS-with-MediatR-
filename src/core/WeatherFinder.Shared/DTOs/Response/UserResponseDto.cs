using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherFinder.Shared.DTOs.Response
{
    public record UserResponseDto
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
