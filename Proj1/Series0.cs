using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Series0 : SeriesBase, Series
    {
        Author showrunner { get; set; }
        List<Episode0> episodes { get; set; }

        public Series0(string title, string genre, Author showrunner, List<Episode0> episodes) : base(title, genre)
        {
            this.showrunner = new Author(showrunner);
            this.episodes = new List<Episode0>(episodes);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append(new string[] { title, "\n", genre, "\n", showrunner.ToString(), "\n" });

            sb.Append(title);
            sb.Append("\n");
            sb.Append(genre);
            sb.Append("\n");
            sb.Append(showrunner);
            sb.Append("\nEpisodes:\n\n");

            int i = 0;
            foreach (var episode in episodes)
            {
                //sb.Append(new string[] { "1: ", episode.ToString() });
                sb.Append($"{++i}: ");
                sb.Append(episode);
            }

            return sb.ToString();
        }
    }
}
