using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class EpisodeAdapter : Episode0
    {
        //public string title { get; private set; }
        //public int duration { get; private set; }
        //public int releaseYear { get; private set; }
        //public Author director { get; private set; } //{ get; set; }

        Episode1 ep;

        //public EpisodeAdapter(string title, int duration, int releaseYear, Author director) : base(title, duration, releaseYear, director)
        //{
        //    ep = new Episode1(title, duration, releaseYear, -1);
        //}
        public EpisodeAdapter(Episode1 ep) : base(ep.title, ep.duration, ep.releaseYear, Author1.authors[ep.directorID])
        {
            //this.title = ep.title;
            //this.duration = ep.duration;
            //this.releaseYear = ep.releaseYear;
            //this.director = Author1.authors[ep.directorID];
            
            this.ep = ep;
        }

        //public override string ToString()
        //{
        //    return ep.ToString();
        //    //return ep.title + "\n" + ep.duration + "\n" + releaseYear + "\n" + director + "\n";
        //}
    }
}
