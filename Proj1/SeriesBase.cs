using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class SeriesBase
    {
        string title { get; set; }
        string genre { get; set; }

        //public SeriesB(string title, string genre, Author showrunner, List<Episode> episodes)
        public SeriesBase(string title, string genre)
        {
            this.title = title;
            this.genre = genre;
            //this.showrunner = new Author(showrunner);
            ////this.episodes = episodes;
            //this.episodes = new List<Episode>(episodes);
        }
    }
}
