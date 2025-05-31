using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackFlix.Application.DTOs
{
    public class CreateUserDto
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = "User";
    }
}