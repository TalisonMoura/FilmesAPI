using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Session>()
                .HasKey(session => new { session.MovieId, session.CinemaId });

            builder.Entity<Session>()
                .HasOne(session => session.Cinema)
                .WithMany(cinema => cinema.Sessions)
                .HasForeignKey(session => session.CinemaId);

            builder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(session => session.MovieId);

            builder.Entity<Address>()
                .HasOne(address => address.Cinema)
                .WithOne(cine => cine.Address)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
