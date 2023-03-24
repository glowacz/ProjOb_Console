using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class SeriesAdapter : Series0
    {
        Series1 s;

        private List<Episode0> EpisodeIDsToEpisode0(List<int> EpisodeIDs)
        {
            List < Episode0 > episodes = new List < Episode0 >();
            foreach (var episodeID in EpisodeIDs)
                episodes.Add(Episode1.episodes[episodeID]);
            return episodes;
        }
        //public SeriesAdapter(Series1 s) //: base(s.title, s.genre, Author1.authors[s.showrunnerID], EpisodeIDsToEpisode0(s.episodeIDs))
        public SeriesAdapter(Series1 s) : base(s.title, s.genre, Author1.authors[s.showrunnerID], new List<Episode0>())
        {
            this.episodes = EpisodeIDsToEpisode0(s.episodeIDs);
            this.s = s;
        }
    }
}
