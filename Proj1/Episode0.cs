using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Episode0 : Episode
    {
        //public string title { get; private set; }
        //public int duration { get; private set; }
        //public int releaseYear { get; private set; }
        //public Author director { get; private set; } //{ get; set; }

        string title { get; set; }
        int duration { get; set; }
        int releaseYear { get; set; }
        Author director { get; set; }

        //public Episode0(string title, int duration, int releaseYear, Author director) : base(title, duration, releaseYear)
        //{
        //    this.director = new Author(director);
        //}

        public Episode0(string title, int duration, int releaseYear, Author director)
        {
            this.title = title;
            this.duration = duration;
            this.releaseYear = releaseYear;
            this.director = director;
        }

        public override string ToString()
        {
            return title + "\n" + duration + "\n" + releaseYear + "\n" + director + "\n";
        }
    }
}
