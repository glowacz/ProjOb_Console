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

Author1 fc1 = new Author1("Francis", "Coppola", 1939, 32);
Author1 ss1 = new Author1("Steven", "Spielberg", 1956, 73);
Author1 cc1 = new Author1("Charlie", "Chaplin", 1889, 6);
Author1 vg1 = new Author1("Vince", "Gilligan", 1967, 17);
Author1 rj1 = new Author1("Rian", "Johnson", 1973, 29);
Author1 gd1 = new Author1("Greg", "Daniels", 1963, 5);
Author1 tm1 = new Author1("Troy", "Miller", 1960, 0);
Author1 vnj1 = new Author1("Victor", "Nelli, Jr.", 1960, 0);
Author1 cmd1 = new Author1("Charles", "McDougall", 1960, 0);

Movie0 an = new Movie0("Apocalypse now", "war film", fc, 147, 1979);
Movie0 tgf = new Movie0("The Godfather", "criminal", fc, 175, 1972);
Movie0 rotla = new Movie0("Raiders of the lost ark", "adventure", ss, 115, 1981);
Movie0 tgd = new Movie0("The Great Dictator", "comedy", cc, 125, 1940);

Movie0 an1 = new MovieAdapter(new Movie1("Apocalypse now", "war film", 0, 147, 1979));
Movie0 tgf1 = new MovieAdapter(new Movie1("The Godfather", "criminal", 0, 175, 1972));
Movie0 rotla1 = new MovieAdapter(new Movie1("Raiders of the lost ark", "adventure", 1, 115, 1981));
Movie0 tgd1 = new MovieAdapter(new Movie1("The Great Dictator", "comedy", 2, 125, 1940));

Console.WriteLine(an);
Console.WriteLine(an1);

Episode0 bb1 = new Episode0("Fly", 45, 2010, rj);
Episode0 bb2 = new Episode0("Ozymandias", 50, 2013, rj);
Episode0 bb3 = new Episode0("Pilot", 43, 2008, vg);
List<Episode0> bb_episodes = new List<Episode0> { bb1, bb2, bb3 };

Series bb = new Series0("Breaking Bad", "drama", vg, bb_episodes);


Episode0 tous1 = new Episode0("Dwight K. Schrute, (Acting) Manager", 22, 2011, tm);
Episode0 tous2 = new Episode0("The Carpet", 23, 2006, vnj);
Episode0 tous3 = new Episode0("Dwight's Speech", 22, 2006, cmd);
List<Episode0> tous_episodes = new List<Episode0> { bb1, bb2, bb3 };

Series tous = new Series0("The Office US", "horror", gd, tous_episodes);


//List<Episode1> bb_1_episodes = new List<Episode1>();
//bb_1_episodes.Add(new Episode1("Fly", 45, 2010, 4));
//bb_1_episodes.Add(new Episode1("Ozymandias", 50, 2013, 4));
//bb_1_episodes.Add(new Episode1("Pilot", 43, 2008, 3));

//Series bb_1 = new Series1("Breaking Bad", "drama", 4, new List<int> { 0, 1, 2 });


////Console.WriteLine(cmd);
//Console.WriteLine(bb);
//Console.WriteLine(bb_1);
////Console.WriteLine(bb1);



//Episode ep = new Episode0("Fly", 45, 2010, rj);

//Console.WriteLine(ep);

//Episode ep1 = new EpisodeAdapter(new Episode1("Fly", 45, 2010, 4));

//Console.WriteLine(ep1);
