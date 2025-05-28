using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackFlix.Domain;
using TrackFlix.Infrastructure.Data;
using TrackFlix.Infrastructure.Interfaces;

namespace TrackFlix.Infrastructure.Repositories
{
    public class EfShowRepository : IShowRepository
    {
        private readonly TrackFlixDbContext _repo;
        public EfShowRepository(TrackFlixDbContext repo)
        {
            _repo = repo;
        }
        public async Task AddAsync(Show show)
        {
            await _repo.Shows.AddAsync(show);
        }

        public Task DeleteAsync(Show show)
        {
            _repo.Shows.Remove(show);
            return Task.CompletedTask;
        }

        public async Task<List<Show>> GetAllAsync()
        {
            return await _repo.Shows.ToListAsync();
        }

        public async Task<Show?> GetByIdAsync(int id)
        {
            return await _repo.Shows.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _repo.SaveChangesAsync() > 0;
        }

        public Task UpdateAsync(Show show)
        {
            _repo.Shows.Update(show);
            return Task.CompletedTask;
        }
    }
}