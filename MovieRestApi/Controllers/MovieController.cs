using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using MovieRestApi.Models;
using System.Threading.Tasks;

namespace MovieRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Movie
            {
                Title = "Rambo " + index,
                Year = 1980 + index,
                Duration = 120 + index
            })
            .ToArray();
        }
    }
}
