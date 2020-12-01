using NUnit.Framework;
using MovieRestApi.Models;

namespace UnitTestMovieN
{
    public class TestMovieN
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreate()
        {
            // given
            var title = "Joker";
            var year = 2019;
            // when
            var movie = new Movie { Title = title, Year = year };
            // then
            Assert.AreEqual(title, movie.Title, "title not stored properly");
            Assert.AreEqual(year, movie.Year, "year not stored properly");
            Assert.AreEqual(0, movie.Id, "id not set to 0");
            Assert.IsNull(movie.Duration, "duration not set to 0");
            Assert.IsNull(movie.Synopsis, "synopsis not set to null");
        }

    }
}