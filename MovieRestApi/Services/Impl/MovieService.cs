using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRestApi.Models;
using MovieRestApi.Dto;

namespace MovieRestApi.Services.Impl
{
    public class MovieService: IMovieService
    {
        private readonly MovieContext _context;

        public MovieService(MovieContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieSimpleDto>> GetMovies()
        {
            return await _context.Movies
                .Select(x => MovieToMovieSimpleDto(x))
                .ToListAsync();
        }

        public async Task<Movie> GetMovie(long id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<bool> PutMovie(long id, Movie movie)
        {

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<Movie> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> DeleteMovie(long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return movie;
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(long id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        private static MovieSimpleDto MovieToMovieSimpleDto(Movie movie) =>
            new MovieSimpleDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Year = movie.Year
            };
    }
}
