using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using MovieRestApi.Models;
using MovieRestApi.Services;
using MovieRestApi.Services.Impl;
using System.Threading.Tasks;

namespace UnitTestMovie
{
    public class UnitTestMovieService
    {
        [Fact]
        public void GetMovieSuccesTest()
        {
            // Arrange
            var mockMovieRepo = new Mock<MovieContext>();
            var movieService = new MovieService(mockMovieRepo.Object);
            //mockMovieRepo.Setup(c =>
            //        c.Movies.FindAsync(1)) //It.IsAny<long>)
            //        .Returns(Task.FromResult(new Movie())));
            // when
            //var movie = await movieService.GetMovie(1);
            // then 
            //Assert.NotNull(movie);
            // verify
            mockMovieRepo.Verify(c => c.Movies.FindAsync(1), Times.Once());
        }
            
    }
}
