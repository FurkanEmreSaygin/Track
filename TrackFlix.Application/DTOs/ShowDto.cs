using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackFlix.Application.DTOs
{
    public class ShowDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Episodes { get; set; }
        public string? PosterUrl { get; set; }
        public double? IMDB { get; set; }

        public bool IsPublished { get; set; } = false;
        public bool IsFeatured { get; set; } = false;
    }
}