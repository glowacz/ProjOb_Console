using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Movie1 : MovieBase
    {
        int directorID { get; set; } 

        public Movie1(string title, string genre, int directorID, int duration, int releaseYear) : base(title, genre, duration, releaseYear)
        {
            this.directorID = directorID;
        }
    }
}
