using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static Proj1.R0;

namespace Proj1
{
    static class R4
    {
        public static Author4? fc, ss, cc, vg, rj, gd, tm, vnj, cmd;
        public static Movie4? an, tgf, rotla, tgd;
        public static Episode4? bb1, bb2, bb3, tous1, tous2, tous3;
        public static Series4? bb, tous;
        internal class Author4
        {
            //static int n_authors = 0;
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

                this.authorID = authors.Count;
                authors.Add(this);
                //this.authorID = n_authors++;

            }
        }

        internal class Episode4 //: Episode0
        {
            public static List<Episode4> episodes = new List<Episode4>();
            public static Dictionary<int, string> map = new Dictionary<int, string>();
            public static Dictionary<int, int> mapi = new Dictionary<int, int>();
            //static int n_episodes = 0;

            public int episodeID { get; set; }

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

                this.episodeID = episodes.Count;

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

        internal class Author4Adapter : R0.Author0
        {
            Author4 aut;
            public Author4Adapter(Author4 aut) : base(Author4.map[aut.nameKey], Author4.map[aut.surnameKey],
                Author4.mapi[aut.birthYearKey], Author4.mapi[aut.awardsKey])
            {
                this.aut = aut;
            }
        }

        internal class Episode4Adapter : R0.Episode0
        {
            Episode4 ep;
            public Episode4Adapter(Episode4 ep) : base(Episode4.map[ep.titleKey], Episode4.mapi[ep.durationKey], Episode4.mapi[ep.releaseYearKey], new Author4Adapter(Author4.authors[ep.directorID]))
            {
                this.ep = ep;
            }
        }

        internal class Series4Adapter : R0.Series0
        {
            Series1 s;

            public Series4Adapter(Series1 s) : base(s.title, s.genre, new Author4Adapter(Author4.authors[s.showrunnerID]), new List<R0.Episode0>())
            {
                this.episodes = EpisodeIDsToEpisode0(s.episodeIDs);
                this.s = s;
            }
        }

        internal class Movie4Adapter : R0.Movie0
        {
            Movie4 m;

            public Movie4Adapter(Movie4 m) : base(Movie4.map[m.titleKey], Movie4.map[m.genreKey],
                new Author4Adapter(Author4.authors[m.directorID]), Movie4.mapi[m.durationKey], Movie4.mapi[m.releaseYearKey])
            {
                this.m = m;
            }
        }

        public static List<int> Episode4ToEpisodeIDs(List<Episode4> Episode4s)
        {
            List<int> episodeIDs = new List<int>();
            foreach (var episode4 in Episode4s)
                episodeIDs.Add(episode4.episodeID);
            return episodeIDs;
        }
        public static List<R0.Episode0> EpisodeIDsToEpisode0(List<int> EpisodeIDs)
        {
            List<R0.Episode0> episodes = new List<R0.Episode0>();
            foreach (var episodeID in EpisodeIDs)
                episodes.Add(new Episode4Adapter(Episode4.episodes[episodeID]));
            return episodes;
        }

        public static List<Movie0> Movies4ToMovies0(List<Movie4> movies4)
        {
            List<Movie0> movies0 = new List<Movie0>();
            foreach (var movie4 in movies4)
                movies0.Add(new Movie4Adapter(movie4));
            return movies0;
        }

        public static void Create()
        {
            fc = new Author4("Francis", "Coppola", 1939, 32);
            ss = new Author4("Steven", "Spielberg", 1956, 73);
            cc = new Author4("Charlie", "Chaplin", 1889, 6);
            vg = new Author4("Vince", "Gilligan", 1967, 17);
            rj = new Author4("Rian", "Johnson", 1973, 29);
            gd = new Author4("Greg", "Daniels", 1963, 5);
            tm = new Author4("Troy", "Miller", 1960, 0);
            vnj = new Author4("Victor", "Nelli, Jr.", 1960, 0);
            cmd = new Author4("Charles", "McDougall", 1960, 0);


            an = new Movie4("Apocalypse now", "war film", fc.authorID, 17, 1979);
            tgf = new Movie4("The Godfather", "criminal", fc.authorID, 175, 1972);
            rotla = new Movie4("Raiders of the lost ark", "adventure", ss.authorID, 115, 1981);
            tgd = new Movie4("The Great Dictator", "comedy", cc.authorID, 125, 1940);

            bb1 = new Episode4("Fly", 45, 2010, rj.authorID);
            bb2 = new Episode4("Ozymandias", 50, 2013, rj.authorID);
            bb3 = new Episode4("Pilot", 43, 2008, vg.authorID);
            List<int> bb_episodes = new List<int> { bb1.episodeID, bb2.episodeID, bb3.episodeID };
            bb = new Series4("Breaking Bad", "drama", vg.authorID, bb_episodes);

            tous1 = new Episode4("Dwight K. Schrute, (Acting)Manager", 22, 2011, tm.authorID);
            tous2 = new Episode4("The Carpet", 23, 2006, vnj.authorID);
            tous3 = new Episode4("Dwight's Speech", 22, 2006, cmd.authorID);
            List<int> tous_episodes = new List<int> { tous1.episodeID, tous2.episodeID, tous3.episodeID };
            tous = new Series4("The Office US", "horror", gd.authorID, tous_episodes);
        }

        public static void Find(List<Episode4> episodes, List<Movie4> movies)
        {
            List<R0.Episode0> episodes0 = EpisodeIDsToEpisode0(Episode4ToEpisodeIDs(episodes));
            List<R0.Movie0> movies0 = Movies4ToMovies0(movies);

            R0.Find(episodes0, movies0);
        }
    }
}