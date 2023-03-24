using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Movie1 // : MovieBase
    {
        public string title { get; set; }
        public string genre { get; set; }
        public int releaseYear { get; set; }
        public int duration { get; set; }
        public int directorID { get; set; } 

        public Movie1(string title, string genre, int directorID, int duration, int releaseYear) //: base(title, genre, duration, releaseYear)
        {
            this.title = title;
            this.genre = genre;
            this.releaseYear = releaseYear;
            this.duration = duration;
            this.directorID = directorID;
        }
    }
}
