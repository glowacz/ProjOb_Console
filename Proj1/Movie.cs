using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Movie : MovieBase
    {
        Author director { get; set; }

        public Movie(string title, string genre, Author director, int duration, int releaseYear) : base(title, genre, duration, releaseYear)
        {
            this.director = new Author(director);
        }
    }
}
