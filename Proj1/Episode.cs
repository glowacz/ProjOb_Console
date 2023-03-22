using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Episode : EpisodeBase
    {
        Author director { get; set; }

        public Episode(string title, int duration, int releaseYear, Author director) : base(title, duration, releaseYear)
        {
            this.director = new Author(director);
        }
    }
}
