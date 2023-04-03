using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1.Legacy
{
    internal class Author1 : R0.Author0
    {
        static int n_authors = 0;
        public static List<Author1> authors = new List<Author1>();
        int authorID { get; set; }
        public Author1(string name, string surname, int birthYear, int awards) : base(name, surname, birthYear, awards)
        {
            authorID = ++n_authors;
            authors.Add(this);
        }
    }
}
