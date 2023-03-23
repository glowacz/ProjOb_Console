using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    interface Episode
    {
        string ToString(); //return title + "\n" + duration + "\n" + releaseYear + "\n" + director + "\n";
    }
    //class Episode
    //{
    //    protected string? title { get; set; } //{ get; set; }
    //    protected int duration { get; set; } //= 0;
    //    protected int releaseYear { get; set; } // = 0;
    //    protected Author? director { get; set; }

    //    //public EpisodeBase(string title, int duration, int releaseYear, Author director)
    //    //{
    //    //    this.title = title;
    //    //    this.duration = duration;
    //    //    this.releaseYear = releaseYear;
    //    //    this.director = director;
    //    //}
    //    public override string ToString()
    //    {
    //        return title + "\n" + duration + "\n" + releaseYear + "\n" + director + "\n";
    //    }
    //}
    //internal class EpisodeBase
    //{

    //}
}
