// See https://aka.ms/new-console-template for more information

using Proj1;

Author0 fc = new Author0("Francis", "Coppola", 1939, 32);
Author0 ss = new Author0("Steven", "Spielberg", 1956, 73);
Author0 cc = new Author0("Charlie", "Chaplin", 1889, 6);
Author0 vg = new Author0("Vince", "Gilligan", 1967, 17);
Author0 rj = new Author0("Rian", "Johnson", 1973, 29);
Author0 gd = new Author0("Greg", "Daniels", 1963, 5);
Author0 tm = new Author0("Troy", "Miller", 1960, 0);
Author0 vnj = new Author0("Victor", "Nelli, Jr.", 1960, 0);
Author0 cmd = new Author0("Charles", "McDougall", 1960, 0);

//Author1 fc1 = new Author1("Francis", "Coppola", 1939, 32);
//Author1 ss1 = new Author1("Steven", "Spielberg", 1956, 73);
//Author1 cc1 = new Author1("Charlie", "Chaplin", 1889, 6);
//Author1 vg1 = new Author1("Vince", "Gilligan", 1967, 17);
//Author1 rj1 = new Author1("Rian", "Johnson", 1973, 29);
//Author1 gd1 = new Author1("Greg", "Daniels", 1963, 5);
//Author1 tm1 = new Author1("Troy", "Miller", 1960, 0);
//Author1 vnj1 = new Author1("Victor", "Nelli, Jr.", 1960, 0);
//Author1 cmd1 = new Author1("Charles", "McDougall", 1960, 0);

Author4 fc4 = new Author4("Francis", "Coppola", 1939, 32);
Author4 ss4 = new Author4("Steven", "Spielberg", 1956, 73);
Author4 cc4 = new Author4("Charlie", "Chaplin", 1889, 6);
Author4 vg4 = new Author4("Vince", "Gilligan", 1967, 17);
Author4 rj4 = new Author4("Rian", "Johnson", 1973, 29);
Author4 gd4 = new Author4("Greg", "Daniels", 1963, 5);
Author4 tm4 = new Author4("Troy", "Miller", 1960, 0);
Author4 vnj4 = new Author4("Victor", "Nelli, Jr.", 1960, 0);
Author4 cmd4 = new Author4("Charles", "McDougall", 1960, 0);

Movie0 an = new Movie0("Apocalypse now", "war film", fc, 147, 1979);
Movie0 tgf = new Movie0("The Godfather", "criminal", fc, 175, 1972);
Movie0 rotla = new Movie0("Raiders of the lost ark", "adventure", ss, 115, 1981);
Movie0 tgd = new Movie0("The Great Dictator", "comedy", cc, 125, 1940);

//Movie0 an4 = new MovieAdapter(new Movie1("Apocalypse now", "war film", 0, 147, 1979));
//Movie0 tgf4 = new MovieAdapter(new Movie1("The Godfather", "criminal", 0, 175, 1972));
//Movie0 rotla4 = new MovieAdapter(new Movie1("Raiders of the lost ark", "adventure", 1, 115, 1981));
//Movie0 tgd4 = new MovieAdapter(new Movie1("The Great Dictator", "comedy", 2, 125, 1940));

Movie4 an4 = new Movie4("Apocalypse now", "war film", 0, 147, 1979);
Movie4 tgf4 = new Movie4("The Godfather", "criminal", 0, 175, 1972);
Movie4 rotla4 = new Movie4("Raiders of the lost ark", "adventure", 1, 115, 1981);
Movie4 tgd4 = new Movie4("The Great Dictator", "comedy", 2, 125, 1940);

Console.WriteLine(an);
Console.WriteLine(an4);

Episode0 bb1 = new Episode0("Fly", 45, 2010, rj);
Episode0 bb2 = new Episode0("Ozymandias", 50, 2013, rj);
Episode0 bb3 = new Episode0("Pilot", 43, 2008, vg);
List<Episode0> bb_episodes = new List<Episode0> { bb1, bb2, bb3 };

Series bb = new Series0("Breaking Bad", "drama", vg, bb_episodes);

Episode4 bb14 = new Episode4("Fly", 45, 2010, rj4.authorID);
Episode4 bb24 = new Episode4("Ozymandias", 50, 2013, rj4.authorID);
Episode4 bb34 = new Episode4("Pilot", 43, 2008, vg4.authorID);
List<Episode4> bb_episodes4 = new List<Episode4> { bb14, bb24, bb34 };

Series4 bb4 = new Series4("Breaking Bad", "drama", vg4.authorID, new List<int> { 0, 1, 2 });


Episode4 tous1 = new Episode4("Dwight K. Schrute, (Acting) Manager", 22, 2011, tm4.authorID);
Episode4 tous2 = new Episode4("The Carpet", 23, 2006, vnj4.authorID);
Episode4 tous3 = new Episode4("Dwight's Speech", 22, 2006, cmd4.authorID);
List<Episode4> tous_episodes4 = new List<Episode4> { tous1, tous2, tous3 };

Series4 tous4 = new Series4("The Office US", "horror", gd4.authorID, new List<int> { 3, 4, 5 });


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
