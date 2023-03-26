using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Author4
    {
        static int n_authors = 0;
        public static List<Author4> authors = new List<Author4>();
        public static Dictionary<int, string> map = new Dictionary<int, string>();
        public static Dictionary<int, int> mapi = new Dictionary<int, int>();

        public int authorID { get; set; }

        public int nameKey { get; set; }
        public int surnameKey { get; set; }
        public int birthYearKey { get; set; }
        public int awardsKey { get; set; }


        public Author4(string name, string surname, int birthYear, int awards)
        {
            this.nameKey = name.GetHashCode();
            map[nameKey] = name;

            this.surnameKey = surname.GetHashCode();
            map[surnameKey] = surname;

            this.birthYearKey = birthYear.GetHashCode();
            mapi[birthYearKey] = birthYear;

            this.awardsKey = awards.GetHashCode();
            mapi[awardsKey] = awards;

            authors.Add(this);
            this.authorID = ++n_authors;
        }
    }

    internal class Episode4 //: Episode0
    {
        public static List<Episode4> episodes = new List<Episode4>();
        public static Dictionary<int, string> map = new Dictionary<int, string>();
        public static Dictionary<int, int> mapi = new Dictionary<int, int>();

        public int titleKey { get; set; }
        public int durationKey { get; set; }
        public int releaseYearKey { get; set; }
        public int directorID { get; set; }

        public Episode4(string title, int duration, int releaseYear, int directorID)
        {
            this.titleKey = title.GetHashCode();
            map[titleKey] = title;

            this.durationKey = duration.GetHashCode();
            mapi[durationKey] = duration;

            this.releaseYearKey = releaseYear.GetHashCode();
            mapi[releaseYearKey] = releaseYear;

            this.directorID = directorID;

            episodes.Add(this);
        }
    }
    internal class Series4 //: SeriesBase, Series
    {
        public static Dictionary<int, string> map = new Dictionary<int, string>();

        public int titleKey { get; set; }
        public int genreKey { get; set; }
        public int showrunnerID { get; set; }
        public List<int> episodeIDs { get; set; }

        public Series4(string title, string genre, int showrunnerID, List<int> episodeIDs) //: base(title, genre)
        {
            this.titleKey = title.GetHashCode();
            map[titleKey] = title;

            this.genreKey = genre.GetHashCode();
            map[genreKey] = genre;

            this.showrunnerID = showrunnerID;

            this.episodeIDs = new List<int>(episodeIDs);
        }
    }

    internal class Movie4 // : MovieBase
    {
        public static Dictionary<int, string> map = new Dictionary<int, string>();
        public static Dictionary<int, int> mapi = new Dictionary<int, int>();

        public int titleKey { get; set; }
        public int genreKey { get; set; }
        public int releaseYearKey { get; set; }
        public int durationKey { get; set; }
        public int directorID { get; set; }

        public Movie4(string title, string genre, int directorID, int duration, int releaseYear) //: base(title, genre, duration, releaseYear)
        {
            this.titleKey = title.GetHashCode();
            map[titleKey] = title;

            this.genreKey = genre.GetHashCode();
            map[genreKey] = genre;

            this.releaseYearKey = releaseYear.GetHashCode();
            mapi[releaseYearKey] = releaseYear;

            this.durationKey = duration.GetHashCode();
            mapi[durationKey] = duration;

            this.directorID = directorID;
        }
    }

    internal class Author4Adapter : Author0
    {
        Author4 aut;
        public Author4Adapter(Author4 aut) : base(Author4.map[aut.nameKey], Author4.map[aut.surnameKey],
            Author4.mapi[aut.birthYearKey], Author4.mapi[aut.awardsKey])
        {
            this.aut = aut;
        }
    }

    internal class Episode4Adapter : Episode0
    {
        Episode4 ep;
        public Episode4Adapter(Episode4 ep) : base(Episode4.map[ep.titleKey], Episode4.mapi[ep.durationKey], Episode4.mapi[ep.releaseYearKey], new Author4Adapter(Author4.authors[ep.directorID]))
        {
            this.ep = ep;
        }
    }

    internal class Series4Adapter : Series0
    {
        Series1 s;

        private List<Episode0> EpisodeIDsToEpisode0(List<int> EpisodeIDs)
        {
            List<Episode0> episodes = new List<Episode0>();
            foreach (var episodeID in EpisodeIDs)
                episodes.Add(new Episode4Adapter(Episode4.episodes[episodeID]));
            return episodes;
        }
        public Series4Adapter(Series1 s) : base(s.title, s.genre, new Author4Adapter(Author4.authors[s.showrunnerID]), new List<Episode0>())
        {
            this.episodes = EpisodeIDsToEpisode0(s.episodeIDs);
            this.s = s;
        }
    }

    internal class Movie4Adapter : Movie0
    {
        Movie4 m;

        public Movie4Adapter(Movie4 m) : base(Movie4.map[m.titleKey], Movie4.map[m.genreKey], 
            new Author4Adapter(Author4.authors[m.directorID]), Movie4.mapi[m.durationKey], Movie4.mapi[m.releaseYearKey])
        {
            this.m = m;
        }
    }
}