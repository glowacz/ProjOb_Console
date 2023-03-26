using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Movie0 : Movie //: MovieBase
    {
        string title { get; set; }
        string genre { get; set; }
        int releaseYear { get; set; }
        int duration { get; set; }
        Author0 director { get; set; }

        public Movie0(string title, string genre, Author0 director, int duration, int releaseYear) //: base(title, genre, duration, releaseYear)
        {
            this.title = title;
            this.genre = genre;
            this.releaseYear = releaseYear;
            this.duration = duration;
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
            sb.Append("\nDirector:\n");
            sb.Append(director);

            return sb.ToString();
        }
    }
}
