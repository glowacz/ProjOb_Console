using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Episode1 : EpisodeBase
    {
        int directorID { get; set; }

        public Episode1(string title, int duration, int releaseYear, int directorID) : base(title, duration, releaseYear)
        {
            this.directorID = directorID;
        }
    }
}
