using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using TrackFlix.Application.DTOs;
using TrackFlix.Application.Interfaces;
using TrackFlix.Domain;
using TrackFlix.Domain.Interfaces;


namespace TrackFlix.Application.Services
{
    public class ShowService : IShowService
    {

        private readonly IShowRepository _repo;
        private readonly IMapper _mapper;
        public ShowService(IShowRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<ShowDto> CreateShowAsync(CreateShowDto showDto)
        {
            var show = _mapper.Map<Show>(showDto);
            if (show.ReleaseDate > DateTime.UtcNow.AddYears(10))
                throw new Exception("Çok uzak bir tarihte yayınlanamaz.");
            await _repo.AddAsync(show);
            await _repo.SaveChangesAsync();
            return _mapper.Map<ShowDto>(show);
        }

        public async Task<bool> DeleteShowAsync(int id)
        {
            var show = await _repo.GetByIdAsync(id);
            if (show == null) return false;
            await _repo.DeleteAsync(show);
            return await _repo.SaveChangesAsync();
        }

        public async Task<List<ShowDto>> GetAllPublishedAsync()
        {
            var shows = await _repo.GetAllPublishedAsync();
            return _mapper.Map<List<ShowDto>>(shows);
        }

        public async Task<List<ShowDto>> GetAllShowsAsync()
        {
            var shows = await _repo.GetAllAsync();
            return _mapper.Map<List<ShowDto>>(shows);
        }

        public async Task<ShowDto?> GetShowByIdAsync(int id)
        {
            var show = await _repo.GetByIdAsync(id);
            if (show == null)
            {
                return null;
            }
            return _mapper.Map<ShowDto>(show);
        }

        public async Task<bool> UpdateShowAsync(int id, UpdateShowDto showDto)
        {
            var show = await _repo.GetByIdAsync(id);
            if (show == null) return false;
            _mapper.Map(showDto, show);
            await _repo.UpdateAsync(show);
            return await _repo.SaveChangesAsync();
        }
    }
}