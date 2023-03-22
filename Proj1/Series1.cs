using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Series1 : SeriesBase
    {
        int showrunnerID { get; set; }
        List<int> episodeIDs { get; set; }

        public Series1(string title, string genre, int showrunnerID, List<int> episodeIDs) : base(title, genre)
        {
            this.showrunnerID = showrunnerID;
            this.episodeIDs = new List<int>(episodeIDs);
        }
    }
}
