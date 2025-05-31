using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackFlix.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}