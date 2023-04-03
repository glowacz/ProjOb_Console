//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Proj1
//{
//    internal class Episode4 //: Episode0
//    {
//        public int titleKey { get;  set; }
//        public int durationKey { get; set; }
//        public int releaseYearKey { get; set; }
//        public int directorID { get; set; }

//        public static List<Episode4> episodes = new List<Episode4>();

//        public Episode4(string title, int duration, int releaseYear, int directorID)
//        {
//            this.titleKey = title.GetHashCode();
//            this.durationKey = duration.GetHashCode();
//            this.releaseYearKey = releaseYear.GetHashCode();
//            this.directorID = directorID;
//            episodes.Add(this);
//        }
//    }
//}
