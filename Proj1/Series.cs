using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Series : SeriesBase
    {
        Author showrunner { get; set; }
        List<Episode> episodes { get; set; }

        public Series(string title, string genre, Author showrunner, List<Episode> episodes) : base(title, genre)
        {
            this.showrunner = new Author(showrunner);
            this.episodes = new List<Episode>(episodes);
        }
    }
}
