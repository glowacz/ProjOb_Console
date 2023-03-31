// See https://aka.ms/new-console-template for more information

using Proj1;

R0.Create();
R4.Create();

R0.Find(
    new List<R0.Episode0> { R0.bb1, R0.bb2, R0.bb3, R0.tous1, R0.tous2, R0.tous3 }, 
    new List<R0.Movie0> { R0.an, R0.tgf, R0.rotla, R0.tgd });

Console.WriteLine("------------------------------");

//List <R0.Episode0> episodes = R4.EpisodeIDsToEpisode0(new List<int> { R4.bb1.episodeID, R4.bb2.episodeID,
//   R4.bb3.episodeID, R4.tous1.episodeID, R4.tous2.episodeID, R4.tous3.episodeID });
//List <R0.Movie0> movies = new List<R0.Movie0> { new R4.Movie4Adapter(R4.an), new R4.Movie4Adapter(R4.tgf),
//     new R4.Movie4Adapter(R4.rotla),  new R4.Movie4Adapter(R4.tgd) };

R4.Find(new List<R4.Episode4> { R4.bb1, R4.bb2, R4.bb3, R4.tous1, R4.tous2, R4.tous3 },
    new List<R4.Movie4> { R4.an, R4.tgf, R4.rotla, R4.tgd });

//Console.WriteLine(R0.fc);
//Console.WriteLine(new R4.Author4Adapter(R4.fc));
#region old
//Author1 fc1 = new Author1("Francis", "Coppola", 1939, 32);
//Author1 ss1 = new Author1("Steven", "Spielberg", 1956, 73);
//Author1 cc1 = new Author1("Charlie", "Chaplin", 1889, 6);
//Author1 vg1 = new Author1("Vince", "Gilligan", 1967, 17);
//Author1 rj1 = new Author1("Rian", "Johnson", 1973, 29);
//Author1 gd1 = new Author1("Greg", "Daniels", 1963, 5);
//Author1 tm1 = new Author1("Troy", "Miller", 1960, 0);
//Author1 vnj1 = new Author1("Victor", "Nelli, Jr.", 1960, 0);
//Author1 cmd1 = new Author1("Charles", "McDougall", 1960, 0);





//Movie0 an4 = new MovieAdapter(new Movie1("Apocalypse now", "war film", 0, 147, 1979));
//Movie0 tgf4 = new MovieAdapter(new Movie1("The Godfather", "criminal", 0, 175, 1972));
//Movie0 rotla4 = new MovieAdapter(new Movie1("Raiders of the lost ark", "adventure", 1, 115, 1981));
//Movie0 tgd4 = new MovieAdapter(new Movie1("The Great Dictator", "comedy", 2, 125, 1940));

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
#endregion old
