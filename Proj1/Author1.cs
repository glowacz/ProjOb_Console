using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Author1 : Author
    {
        static int n_authors = 0;
        int authorID { get; set; }
        public Author1(string name, string surname, int birthYear, int awards) : base(name, surname, birthYear, awards) 
        {
            this.authorID = ++n_authors;
        }
    }
}
