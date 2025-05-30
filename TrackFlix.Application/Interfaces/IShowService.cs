using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackFlix.Application.DTOs;
using TrackFlix.Domain;

namespace TrackFlix.Application.Interfaces
{
    public interface IShowService
    {
        Task<List<ShowDto>> GetAllShowsAsync();
        Task<ShowDto?> GetShowByIdAsync(int id);
        Task<List<ShowDto>> GetAllPublishedAsync();
        Task<ShowDto> CreateShowAsync(CreateShowDto showDto);
        Task<bool> UpdateShowAsync(int id, UpdateShowDto showDto);
        Task<bool> DeleteShowAsync(int id);
    }
}