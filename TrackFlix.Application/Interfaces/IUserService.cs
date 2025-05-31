using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackFlix.Application.DTOs;

namespace TrackFlix.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserDto?> GetUserByEmailAsync(string email);
        Task<UserDto> CreateUserAsync(CreateUserDto userDto);
        Task<bool> UpdateUserAsync(int id, UpdateUserDto userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}