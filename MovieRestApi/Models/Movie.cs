using System;

namespace MovieRestApi.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public int Year { get; set; }

        public int Duration { get; set; } 

        public string Synopsis { get; set; }
    }
}
