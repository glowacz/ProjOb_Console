using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class EpisodeBase
    {
        string title { get; set; }
        int duration { get; set; }
        int releaseYear { get; set; }
        //Author director { get; set; }

        //public Episode(string title, int duration, int releaseYear, Author director)
        public EpisodeBase(string title, int duration, int releaseYear)
        {
            this.title = title;
            this.duration = duration;
            this.releaseYear = releaseYear;
        }
    }
}
