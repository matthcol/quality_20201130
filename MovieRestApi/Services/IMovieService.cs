using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieRestApi.Dto;
using MovieRestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieRestApi.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieSimpleDto>> GetMovies();
        Task<Movie> GetMovie(long id);
        Task<bool> PutMovie(long id, Movie movie);

        Task<Movie> PostMovie(Movie movie);

        Task<Movie> DeleteMovie(long id);   
    }
}
