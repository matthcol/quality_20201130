using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRestApi.Dto
{
    public class MovieSimpleDto
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public int Year { get; set; }
    }
}
