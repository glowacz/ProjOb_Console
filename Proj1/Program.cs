// See https://aka.ms/new-console-template for more information

using Proj1;

Author fc = new Author("Francis", "Coppola", 1939, 32);
Author ss = new Author("Steven", "Spielberg", 1956, 73);
Author cc = new Author("Charlie", "Chaplin", 1889, 6);
Author vg = new Author("Vince", "Gilligan", 1967, 17);
Author rj = new Author("Rian", "Johnson", 1973, 29);
Author gd = new Author("Greg", "Daniels", 1963, 5);
Author tm = new Author("Troy", "Miller", 1960, 0);
Author vnj = new Author("Victor", "Nelli, Jr.", 1960, 0);
Author cmd = new Author("Charles", "McDougall", 1960, 0);

Movie an = new Movie("Apocalypse now", "war film", fc, 147, 1979);
Movie tgf = new Movie("The Godfather", "criminal", fc, 175, 1972);
Movie rotla = new Movie("Raiders of the lost ark", "adventure", ss, 115, 1981);
Movie tgd = new Movie("The Great Dictator", "comedy", cc, 125, 1940);

Episode bb1 = new Episode("Fly", 45, 2010, rj);
Episode bb2 = new Episode("Ozymandias", 50, 2013, rj);
Episode bb3 = new Episode("Pilot", 43, 2008, vg);
List<Episode> bb_episodes = new List<Episode> { bb1, bb2, bb3 };

Series bb = new Series("Breaking Bad", "drama", vg, bb_episodes);


Episode tous1 = new Episode("Dwight K. Schrute, (Acting) Manager", 22, 2011, tm);
Episode tous2 = new Episode("The Carpet", 23, 2006, vnj);
Episode tous3 = new Episode("Dwight's Speech", 22, 2006, cmd);
List<Episode> tous_episodes = new List<Episode> { bb1, bb2, bb3 };

Series tous = new Series("The Office US", "horror", gd, tous_episodes);


Console.WriteLine(cmd);
