using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public TimeSpan Length { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public List<ShowTime> ShowTime { get; set; }

        public Movie()
        {

        }
    }
}
