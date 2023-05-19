using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proj1.Legacy;

namespace Proj1
{
    static class R0
    {
        public interface Type
        {
            Dictionary<string, object> get_field_values();

            string ToString();
        }
        public static Author0? fc, ss, cc, vg, rj, gd, tm, vnj, cmd;
        public static Movie0? an, tgf, rotla, tgd;
        public static Episode0? bb1, bb2, bb3, tous1, tous2, tous3;
        public static Series0? bb, tous;
        internal class Author0 : Type
        {
            public string name { get; set; }
            public string surname { get; set; }
            public int birthYear { get; set; }
            public int awards { get; set; }

            public Dictionary<string, object> field_values = new Dictionary<string, object>();

            public Dictionary<string, object> get_field_values()
            {
                return field_values;
            }

            public Author0(string name, string surname, int birthYear, int awards)
            {
                //field_values.Add("type", "author");
                //field_values.Add("representation", "base");

                this.name = name; field_values.Add("name", name);
                this.surname = surname; field_values.Add("surname", surname);
                this.birthYear = birthYear; field_values.Add("birthYear", birthYear);
                this.awards = awards; field_values.Add("awards", awards);
            }

            public Author0(Author0 aut)
            {
                this.name = aut.name;
                this.surname = aut.surname;
                this.birthYear = aut.birthYear;
                this.awards = aut.awards;
                this.field_values = aut.field_values;
            }

            public override string ToString()
            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append( name, "  ");
                //sb.Append(surname);
                //sb.Append(birthYear);
                //sb.Append(awards);
                return "Author: " + name + " " + surname + "\nBirth year: " + birthYear + "\nNumber of awards: " + awards + "\n";
                //return JsonConvert.SerializeObject(Author, Newtonsoft.Json.Formatting.Indented);
                //return base.ToString() + ": " + value.ToString();
            }
        }

        internal class Episode0 : Type//: Episode
        {
            //public string title { get; private set; }
            //public int duration { get; private set; }
            //public int releaseYear { get; private set; }
            //public Author director { get; private set; } //{ get; set; }

            public string title { get; set; }
            public int duration { get; set; }
            public int releaseYear { get; set; }
            public Author0 director { get; set; }

            public Dictionary<string, object> field_values = new Dictionary<string, object>();
            public Dictionary<string, object> get_field_values()
            {
                return field_values;
            }

            //public Episode0(string title, int duration, int releaseYear, Author director) : base(title, duration, releaseYear)
            //{
            //    this.director = new Author(director);
            //}

            public Episode0(string title, int duration, int releaseYear, Author0 director)
            {
                this.title = title; field_values.Add("title", title);
                this.duration = duration; field_values.Add("duration", duration);
                this.releaseYear = releaseYear; field_values.Add("releaseYear", releaseYear);
                this.director = director;
            }

            public override string ToString()
            {
                //return title + "\n" + duration + "\n" + releaseYear + "\n" + director + "\n";
                return "Episode:\nTitle: " + title + "\nDuration: " + duration + " min\nRelease year: " + releaseYear + "\n";
            }
        }

        internal class Series0 : Type //: Series //: SeriesBase, Series
        {
            public string title { get; set; }
            public string genre { get; set; }
            public Author0 showrunner { get; set; }
            public List<Episode0> episodes { get; set; }

            public Dictionary<string, object> field_values = new Dictionary<string, object>();
            public Dictionary<string, object> get_field_values()
            {
                return field_values;
            }

            public Series0(string title, string genre, Author0 showrunner, List<Episode0> episodes) // : base(title, genre)
            {
                this.title = title; field_values.Add("title", title);
                this.genre = genre; field_values.Add("genre", genre);
                this.showrunner = new Author0(showrunner);
                this.episodes = new List<Episode0>(episodes);
            }

            public override string ToString()
            {
                //StringBuilder sb = new StringBuilder();
                ////sb.Append(new string[] { title, "\n", genre, "\n", showrunner.ToString(), "\n" });

                //sb.Append(title);
                //sb.Append("\n");
                //sb.Append(genre);
                ////sb.Append("\n");
                ////sb.Append(showrunner);
                ////sb.Append("\nEpisodes:\n\n");

                ////int i = 0;
                ////foreach (var episode in episodes)
                ////{
                ////    //sb.Append(new string[] { "1: ", episode.ToString() });
                ////    sb.Append($"{++i}: ");
                ////    sb.Append(episode);
                ////}

                //return sb.ToString();
                return $"Series:\nTitle: {title}\nGenre: {genre}\n";
            }
        }

        internal class Movie0 : Movie, Type //: MovieBase
        {
            public string title { get; set; }
            public string genre { get; set; }
            public int releaseYear { get; set; }
            public int duration { get; set; }
            public Author0 director { get; set; }

            public Dictionary<string, object> field_values = new Dictionary<string, object>();
            public Dictionary<string, object> get_field_values()
            {
                return field_values;
            }

            public Movie0(string title, string genre, Author0 director, int duration, int releaseYear) //: base(title, genre, duration, releaseYear)
            {
                this.title = title; field_values.Add("title", title);
                this.genre = genre; field_values.Add("genre", genre);
                this.releaseYear = releaseYear; field_values.Add("releaseYear", releaseYear);
                this.duration = duration; field_values.Add("duration", duration);
                this.director = new Author0(director);
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                //sb.Append(new string[] { title, "\n", genre, "\n", showrunner.ToString(), "\n" });

                sb.Append(title);
                sb.Append("\n");
                sb.Append(genre);
                sb.Append("\n");
                sb.Append(releaseYear);
                sb.Append("\n");
                sb.Append(duration);
                sb.Append("\n");
                //sb.Append("\nDirector:\n");
                //sb.Append(director);

                return sb.ToString();
            }
        }

        public static void Create()
        {
            fc = new Author0("Francis", "Coppola", 1939, 32);
            ss = new Author0("Steven", "Spielberg", 1956, 73);
            cc = new Author0("Charlie", "Chaplin", 1889, 6);
            vg = new Author0("Vince", "Gilligan", 1967, 17);
            rj = new Author0("Rian", "Johnson", 1973, 29);
            gd = new Author0("Greg", "Daniels", 1963, 5);
            tm = new Author0("Troy", "Miller", 1960, 0);
            vnj = new Author0("Victor", "Nelli, Jr.", 1960, 0);
            cmd = new Author0("Charles", "McDougall", 1960, 0);

            an = new Movie0("Apocalypse now", "war film", fc, 147, 1979);
            tgf = new Movie0("The Godfather", "criminal", fc, 175, 1972);
            rotla = new Movie0("Raiders of the lost ark", "adventure", ss, 115, 1981);
            tgd = new Movie0("The Great Dictator", "comedy", cc, 125, 1940);


            bb1 = new Episode0("Fly", 45, 2010, rj);
            bb2 = new Episode0("Ozymandias", 50, 2013, rj);
            bb3 = new Episode0("Pilot", 43, 2008, vg);
            List<Episode0> bb_episodes = new List<Episode0> { bb1, bb2, bb3 };
            bb = new Series0("Breaking Bad", "drama", vg, bb_episodes);

            tous1 = new Episode0("Dwight K. Schrute, (Acting)Manager", 22, 2011, tm);
            tous2 = new Episode0("The Carpet", 23, 2006, vnj);
            tous3 = new Episode0("Dwight's Speech", 22, 2006, cmd);
            List<Episode0> tous_episodes = new List<Episode0> { tous1, tous2, tous3 };
            tous = new Series0("The Office US", "horror", gd, tous_episodes);
        }

        public static void Find(List<Episode0> episodes, List<Movie0> movies)
        {
            foreach (var episode in episodes)
            {
                if (episode.director.birthYear > 1970)
                    Console.WriteLine(episode);
            }

            foreach (var movie in movies)
            {
                if (movie.director.birthYear > 1970)
                    Console.WriteLine(movie);
            }
        }
    }
}
