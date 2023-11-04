﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Domain.Enums;

namespace WeatherFinder.Shared.DTOs.Request
{
    public record ActivityRequest
    {
        public ActivityType Activity { get; set; }
        public string? Description { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
