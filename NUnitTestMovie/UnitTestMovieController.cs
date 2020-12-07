using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using MovieRestApi.Services;
using MovieRestApi.Controllers;
using MovieRestApi.Models;
using Moq;

// article: https://exceptionnotfound.net/using-moq-to-create-fluent-test-classes-in-asp-net-core/

namespace UnitTestMovie
{
    public class UnitTestMovieController
    {
        [Fact]
        public async Task GetMovieFoundTest() {
            var id = 1L;
            // create mock
            var mockMovieService = new Mock<IMovieService>();
            // branchement
            var moviesController = new MoviesController(mockMovieService.Object); 
            // arrange : future réponse interne
            mockMovieService.Setup(s => s.GetMovie(id))
                    .Returns(Task<Movie>.FromResult(new Movie { Id = id, Title = "Joker", Year = 2019 }));
            // when 
            var actionResultMovie = await moviesController.GetMovie(id);
            // check
            var movie = actionResultMovie.Value;
            Assert.NotNull(movie);
            Assert.Equal(id, movie.Id);
            // verify : appel vers le mock
            // mockMovieService.Verify(s => s.GetMovie(id), Times.Once());
            mockMovieService.Verify(s => s.GetMovie(It.IsAny<long>()), Times.Once());
        }

        [Fact]
        public async Task GetMovieNotFoundTest() {
            // exercice: id => no movie stored
            // create mock
            var mockMovieService = new Mock<IMovieService>();
            // branchement
            var moviesController = new MoviesController(mockMovieService.Object);
            // arrange : future réponse interne
            mockMovieService.Setup(s => s.GetMovie(It.IsAny<long>()))
                    .Returns(Task<Movie>.FromResult<Movie>(null));
            // when 
            var actionResultMovie = await moviesController.GetMovie(1);
            // check
            var movie = actionResultMovie.Value;
            var result = actionResultMovie.Result;
            Assert.Null(movie);
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);

            // mockMovieService.Verify(s => s.GetMovie(id), Times.Once());
            mockMovieService.Verify(s => s.GetMovie(It.IsAny<long>()), Times.Once());
        }

    }
}
