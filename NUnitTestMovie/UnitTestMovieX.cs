using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MovieRestApi.Models;

namespace UnitTestMovieX
{
    public class TestMovieX
    {

        [Fact]
        public void TestCreate()
        {
            // given
            var title = "Joker";
            var year = 2019;
            // when
            var movie = new Movie { Title = title, Year = year };
            // then
            Assert.Equal(title, movie.Title);
            Assert.Equal(year, movie.Year);
            Assert.Equal(0, movie.Id);
            Assert.Equal(0, movie.Duration);
            Assert.Null(movie.Synopsis);
        }

        [Theory]
        [InlineData(2020)]
        [InlineData(2021)]
        [InlineData(2022)]
        public void TestSetYear(int year)
        {
            // given
            int year0 = 2019;
            var movie = new Movie { Title = "Joker", Year = year0 };
            // when
            movie.Year = year;
            // then
            Assert.True(year == movie.Year, $"{year} incorrectly modified");
        }

    }
}
