using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackFlix.Domain;

namespace TrackFlix.Infrastructure.Data
{
    public class TrackFlixDbContext : DbContext
    {
        public TrackFlixDbContext(DbContextOptions<TrackFlixDbContext> options)
            : base(options)
        {
        }

        public DbSet<Show> Shows { get; set; }
        public DbSet<User> Users { get; set; }

    }
}