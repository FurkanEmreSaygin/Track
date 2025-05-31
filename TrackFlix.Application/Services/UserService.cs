using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TrackFlix.Application.DTOs;
using TrackFlix.Application.Interfaces;
using TrackFlix.Domain;
using TrackFlix.Domain.Interfaces;

namespace TrackFlix.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var existing = await _repo.GetByEmailAsync(userDto.Email);
            if (existing != null)
                throw new Exception("Bu e-posta zaten kayıtlı.");

            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = userDto.Password; // geçici olarak düz parola

            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;

            await _repo.DeleteAsync(user);
            return await _repo.SaveChangesAsync();
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _repo.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {
            var user = await _repo.GetByEmailAsync(email);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;

            _mapper.Map(userDto, user);

            if (!string.IsNullOrEmpty(userDto.Password))
            {
                user.PasswordHash = userDto.Password; // geçici
            }

            await _repo.UpdateAsync(user);
            return await _repo.SaveChangesAsync();
        }
    }
}