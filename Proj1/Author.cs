using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Proj1
{
    internal class Author
    {
        string name { get; set; }
        string surname { get; set; }
        int birthYear  { get; set; }
        int awards { get; set; }

        public Author(string name, string surname, int birthYear, int awards)
        {
            this.name = name;
            this.surname = surname;
            this.birthYear = birthYear;
            this.awards = awards;
        }

        public Author(Author aut)
        {
            this.name = aut.name;
            this.surname = aut.surname;
            this.birthYear = aut.birthYear;
            this.awards = aut.awards;
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
}
