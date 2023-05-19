using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Proj1.R0;

namespace Proj1
{
    //class Command
    //{
    //    string[] parameters { get; set; }

    //    public Command(string[] parameters)
    //    {
    //        this.parameters = parameters;
    //    }


    //    //void Execute(string[] parameters);
    //}

    static class CommandMain
    {
        public static Collection<(R0.Type?, string)> col = new MyVector<(R0.Type?, string)>();
        public static Dictionary<string, Command> commands = new Dictionary<string, Command>();
        public static Dictionary<string, string[]> fields = new Dictionary<string, string[]>();
        public static Dictionary<(string, string), object> default_values = new Dictionary<(string, string), object>();
        public static string? full_command, command_name;
        public static string?[] command_args;

        public static void create_collection()
        {
            col.Add((R0.cmd, "author"));
            col.Add((R0.fc, "author"));
            col.Add((R0.ss, "author"));
            col.Add((R0.bb, "series"));
            //col.Add((R4.cmd, "author"));
            //col.Add((R4.fc, "author"));
            
            //col.Add((R4.bb, "series"));
        }

        public static void add_commands()
        {
            commands.Add("exit", new Exit());
            commands.Add("list", new List());
            commands.Add("find", new Find());
            commands.Add("add", new Add());
        }

        public static void add_fields()
        {
            string[] author_fields = { "name", "surname", "birthYear", "awards" };
            fields.Add("author", author_fields);
            
            string[] episode_fields = { "title", "duration", "releaseYear"};
            fields.Add("episode", episode_fields);
            
            string[] series_fields = { "title", "genre" };
            fields.Add("series", series_fields);

            string[] movie_fields = { "title", "genre", "duration", "releaseYear" };
            fields.Add("movie", movie_fields);
        }

        //public static void set_defaults()
        //{
        //    default_values.Add(("author", "name"), "");
        //}

        public static void Init()
        {
            CommandMain.create_collection();
            CommandMain.add_commands();
            CommandMain.add_fields();
            //CommandMain.set_defaults();
        }

        public static void Main()
        {
            while (true)
            {
                full_command = Console.ReadLine();
                command_args = full_command.Split(' ');
                command_name = command_args[0];

                if (!commands.ContainsKey(command_name))
                {
                    Console.WriteLine("No such command exists!!!");
                    continue;
                }

                commands[command_name].Execute(command_args);
            }
        }
    }
    interface Command
    {
        void Execute(string[] parameters);
    }

    class Exit : Command
    {
        public void Execute(string[] parameters)
        {
            Environment.Exit(0);
        }
    }

    class List : Command
    {
        public void Execute(string[] parameters)
        {
            string requested_type = parameters[1];
            Algorithms.ForEach(CommandMain.col.GetForwardIterator(), 
                ((R0.Type ob, string type) a) => 
                { 
                    if(a.type == requested_type)
                        Console.WriteLine(a.ob); 
                });
        }
    }

    class Find : Command
    {
        (bool, string field, char cmp, string value) parse_requirement(string requirement)
        {
            int cnt = requirement.Count((char c) => (c == '=' || c == '<' || c == '>'));
            if (cnt == 0)
            {
                Console.WriteLine("A requirment should feature a comparison operator!!!");
                return (false, "", '!', "");
            }
            else if (cnt > 1)
            {
                Console.WriteLine("A requirment shouldn't feature more than one comparison operators!!!");
                return (false, "", '!', "");
            }

            if(requirement.Contains('='))
            {
                string[] strings = requirement.Split('=');
                return (true, strings[0], '=', strings[1]);
            }
            if (requirement.Contains('<'))
            {
                string[] strings = requirement.Split('<');
                return (true, strings[0], '<', strings[1]);
            }
            else
            {
                string[] strings = requirement.Split('>');
                return (true, strings[0], '>', strings[1]);
            }
        }
        public void Execute(string[] parameters)
        {
            string requested_type = parameters[1];
            Algorithms.ForEach(CommandMain.col.GetForwardIterator(),
                ((R0.Type ob, string type) a) =>
                {
                    if (a.type == requested_type)
                    {
                        for(int i = 2; i < parameters.Length; i++)
                        {
                            (bool success, string field, char cmp, string value) = parse_requirement(parameters[i]);
                            if (!success) return;
                            
                            //if(!a.ob.get_field_values().ContainsKey(field))
                            //{
                            //    Console.WriteLine("Invalid field name!!!");
                            //    return;
                            //}

                            if (!CommandMain.fields[a.type].Contains(field))
                            {
                                Console.WriteLine("Invalid field name!!!");
                                return;
                            }

                            Dictionary<string, object> field_values = a.ob.get_field_values();

                            if (field == "duration" || field == "releaseYear" || field == "birthYear" || field == "awards")
                            {
                                if (int.TryParse(value, out int n))
                                {
                                    if (cmp == '=' && !((int)field_values[field] == n))
                                    {
                                        //Console.WriteLine($"Requirement {i} not met!!!");
                                        return;
                                    }
                                    if (cmp == '<' && !((int)field_values[field] < n))
                                    {
                                        //Console.WriteLine($"Requirement {i} not met!!!");
                                        return;
                                    }
                                    if (cmp == '>' && !((int)field_values[field] > n))
                                    {
                                        //Console.WriteLine($"Requirement {i} not met!!!");
                                        return;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("The value should be a valid integer");
                                }
                            }
                            else
                            {
                                if (cmp == '=' && !((string)field_values[field] == value))
                                {
                                    //Console.WriteLine($"Requirement {i} not met!!!");
                                    return;
                                }
                                if (cmp == '<' && !(string.Compare((string)field_values[field], value) == -1 ))
                                {
                                    //Console.WriteLine($"Requirement {i} not met!!!");
                                    return;
                                }
                                if (cmp == '>' && !(string.Compare((string)field_values[field], value) == 1))
                                {
                                    //Console.WriteLine($"Requirement {i} not met!!!");
                                    return;
                                }
                            }
                        }
                        Console.WriteLine(a.ob);
                    }
                });
        }
    }

    class Add : Command
    {
        private Dictionary<string, object> BaseBuilder(string type)
        {
            Dictionary<string, object> field_values = new Dictionary<string, object>();
            foreach (var field in CommandMain.fields[type])
            {
                if (field == "duration" || field == "releaseYear" || field == "birthYear" || field == "awards")
                    field_values.Add(field, 0);
                else
                    field_values.Add(field, "");
            }
            return field_values;
        }

        //private Dictionary<string, object> AuthorBaseBuilder()
        //{
        //    Dictionary<string, object> field_values = new Dictionary<string, object>();
        //    foreach (var field in CommandMain.fields["episode"])
        //    {
        //        if (field == "birthYear")
        //            field_values.Add(field, 0);
        //        else
        //            field_values.Add(field, "");
        //    }
        //    return field_values;
        //}
        //private Dictionary<string, object> EpisodeBaseBuilder()
        //{
        //    Dictionary<string, object> field_values = new Dictionary<string, object>();
        //    foreach (var field in CommandMain.fields["episode"])
        //    {
        //        if (field == "duration" || field == "releaseYear")
        //            field_values.Add(field, 0);
        //        else
        //            field_values.Add(field, "");
        //    }
        //    return field_values;
        //}
        //private Dictionary<string, object> SeriesBaseBuilder()
        //{
        //    Dictionary<string, object> field_values = new Dictionary<string, object>();
        //    foreach (var field in CommandMain.fields["series"])
        //    {
        //        field_values.Add(field, "");
        //    }
        //    return field_values;
        //}
        //private Dictionary<string, object> MovierBaseBuilder()
        //{
        //    Dictionary<string, object> field_values = new Dictionary<string, object>();
        //    //field_values.Add("title", "No Title");
        //    //field_values.Add("genre", "no genre");
        //    //field_values.Add("duration", 0);
        //    //field_values.Add("releaseYear", 0);
        //    foreach(var field in CommandMain.fields["movie"])
        //    {
        //        if (field == "duration" || field == "releaseYear")
        //            field_values.Add(field, 0);
        //        else
        //            field_values.Add(field, "");
        //    }
        //    return field_values;
        //}

        private static void AddToCollection(string type, string repr, Dictionary<string, object> field_values)
        {
            if(type == "author")
            {
                CommandMain.col.Add((new R0.Author0((string) field_values["name"], (string) field_values["surname"], 
                    (int) field_values["birthYear"], (int) field_values["awards"]), "author"));
            }
            else if (type == "episode")
            {
                CommandMain.col.Add((new R0.Episode0((string)field_values["title"], (int)field_values["duration"], 
                    (int)field_values["releaseYear"], R0.fc), "episode"));
            }
            else if (type == "series")
            {
                CommandMain.col.Add((new R0.Series0((string)field_values["title"], (string)field_values["genre"], 
                    R0.fc, new List<Episode0>()), "series"));
            }
            else if (type == "movie")
            {
                CommandMain.col.Add((new R0.Movie0((string)field_values["title"], (string)field_values["genre"], R0.fc, 
                    (int)field_values["duration"], (int)field_values["releaseYear"]), "movie"));
            }
        }
        public void Execute(string[] parameters)
        {
            if(parameters.Length < 3)
            {
                Console.WriteLine("Provide more parameters!!!");
                return;
            }
            string type = parameters[1], repr = parameters[2];

            if(!CommandMain.fields.ContainsKey(type))
            {
                Console.WriteLine("This is not a valid type!!!");
                return;
            }

            if (repr != "base" && repr != "secondary")
            {
                Console.WriteLine("Correct value third is base OR secondary");
                return;
            }

            Console.Write("Available fields: [ ");
            foreach(string field1 in CommandMain.fields[type])
            {
                Console.Write(field1);
                Console.Write(" ");
            }
            Console.Write("]\n");

            Dictionary<string, object> field_values = BaseBuilder(type);

            string line, field, value;

            while(true)
            {
                line = Console.ReadLine();
                string[] pom = line.Split('=');
                field = pom[0];
                if (field == "DONE")
                {
                    AddToCollection(type, repr, field_values);
                    Console.WriteLine();
                    return;
                }
                else if (field == "EXIT")
                {
                    Console.WriteLine();
                    return;
                }
                else if (pom.Length != 2)
                {
                    Console.WriteLine("No = sign or too many = signs");
                    continue;
                }
                else if(!CommandMain.fields[type].Contains(field))
                {
                    Console.WriteLine("Invalid field name!!!");
                    continue;
                }
                else
                {
                    value = pom[1];

                    if (field == "duration" || field == "releaseYear" || field == "birthYear" || field == "awards")
                    {
                        if (int.TryParse(value, out int n))
                        {
                            field_values[field] = n;
                        }
                        else
                        {
                            Console.WriteLine("The value should be a valid integer");
                        }
                    }
                    else
                    {
                        field_values[field] = value;
                    }
                }
            }

            //field_values.ToArray();
        }
    }
}
