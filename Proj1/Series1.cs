using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Series1 //: SeriesBase, Series
    {
        public string title { get; set; }
        public string genre { get; set; }
        public int showrunnerID { get; set; }
        public List<int> episodeIDs { get; set; }

        public Series1(string title, string genre, int showrunnerID, List<int> episodeIDs) //: base(title, genre)
        {
            this.title = title;
            this.genre = genre;
            this.showrunnerID = showrunnerID;
            this.episodeIDs = new List<int>(episodeIDs);
        }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append(title);
        //    sb.Append("\n");
        //    sb.Append(genre);
        //    sb.Append("\n");
        //    sb.Append(Author1.authors[showrunnerID]);
        //    sb.Append("\nEpisodes:\n\n");

        //    int i = 0;
        //    foreach (int episodeID in episodeIDs)
        //    {
        //        //sb.Append(new string[] { "1: ", episode.ToString() });
        //        sb.Append($"{++i}: ");
        //        sb.Append(Episode1.episodes[episodeID]);
        //    }

        //    return sb.ToString();
        //}

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(new string[] { title, "\n", genre, "\n", Author1.authors[showrunnerID].ToString(), "\n" });

        //    foreach (var episodeID in episodeIDs)
        //    {
        //        sb.Append(new string[] { "1: ", Episode1.episodes[episodeID].ToString() });
        //    }

        //    return sb.ToString();
        //}
    }
}
