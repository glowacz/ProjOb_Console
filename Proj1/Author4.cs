using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1
{
    internal class Author4
    {
        int nameKey { get; set; }
        int surnameKey { get; set; }
        int birthYearKey { get; set; }
        int awardsKey { get; set; }

        public Author4(int nameKey, int surnameKey, int birthYearKey, int awardsKey)
        {
            this.nameKey = nameKey;
            this.nameKey = surnameKey;
            this.birthYearKey = birthYearKey;
            this.awardsKey = awardsKey;
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
