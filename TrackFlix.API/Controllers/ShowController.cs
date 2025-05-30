using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackFlix.Application.DTOs;
using TrackFlix.Application.Interfaces;
using TrackFlix.Domain.Interfaces;

namespace TrackFlix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _repo;
        public ShowController(IShowService repo)
        {
            _repo = repo;
        }

        [HttpGet("published")]
        public async Task<IActionResult> GetPublishedShows()
        {
            var shows = await _repo.GetAllPublishedAsync();
            return Ok(shows);
        }

        [HttpGet("All")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllShows()
        {
            var shows = await _repo.GetAllShowsAsync();
            return Ok(shows);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var show = await _repo.GetShowByIdAsync(id);
            if (show == null) return NotFound();
            return Ok(show);
        }

        // ADMIN
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShowDto dto)
        {
            var createdShow = await _repo.CreateShowAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdShow.Id }, createdShow);
        }

        // ADMIN
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateShowDto dto)
        {
            var result = await _repo.UpdateShowAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        // ADMIN
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteShowAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}