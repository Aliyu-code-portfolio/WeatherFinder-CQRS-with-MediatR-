using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherFinder.Domain.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public char Gender { get; set; }
        public DateTime JoinedDate { get; set; }= DateTime.Now;
    }
}
