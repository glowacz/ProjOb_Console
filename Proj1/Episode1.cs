using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Episode1 //: Episode0
    {
        public string title { set; }
        public int duration { get; set; }
        public int releaseYear { get; set; }
        public int directorID { get; set; }

        public static List<Episode0> episodes = new List<Episode0>();

        //public Episode1(string title, int duration, int releaseYear, Author director) : base(title, duration, releaseYear, director)
        //{
        //    //this.title = title;
        //    //this.duration = duration;
        //    //this.releaseYear = releaseYear;
        //    //this.director = director;
        //}

        public Episode1(string title, int duration, int releaseYear, int directorID) //: base(title, duration, releaseYear)
        {
            this.title = title;
            this.duration = duration;
            this.releaseYear = releaseYear;
            this.directorID = directorID;
            episodes.Add(new Episode0(title, duration, releaseYear, Author1.authors[directorID]));
        }

        //public override string ToString()
        //{
        //    return title + "\n" + duration + "\n" + releaseYear + "\n" + Author1.authors[directorID] + "\n";
        //}
    }
}
