using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackFlix.Domain;
using TrackFlix.Domain.Interfaces;
using TrackFlix.Infrastructure.Data;

namespace TrackFlix.Infrastructure.Repositories
{
    public class EfUserRepository : IUserRepository
    {
        private readonly TrackFlixDbContext _repo;
        public EfUserRepository(TrackFlixDbContext repo)
        {
            _repo = repo;
        }
        public async Task AddAsync(User user)
        {
            await _repo.Users.AddAsync(user);
        }

        public Task DeleteAsync(User user)
        {
            _repo.Users.Remove(user);
            return Task.CompletedTask;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _repo.Users.ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _repo.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _repo.Users.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _repo.SaveChangesAsync() > 0;
        }

        public Task UpdateAsync(User user)
        {
            _repo.Users.Update(user);
            return Task.CompletedTask;
        }
    }
}