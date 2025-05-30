using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackFlix.Domain;

namespace TrackFlix.Domain.Interfaces
{
    public interface IShowRepository
    {
        Task<List<Show>> GetAllAsync();
        Task<Show?> GetByIdAsync(int id);
        Task<List<Show>> GetAllPublishedAsync();
        Task AddAsync(Show show);
        Task UpdateAsync(Show show);
        Task DeleteAsync(Show show);
        Task<bool> SaveChangesAsync();

    }
}