using Proj1;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using static Proj1.R0;
using System.Reflection;

namespace Proj1
{
    public class CommandQueueWrapper
    {
        public Queue<Command> Commands;

        // Parameterless constructor required for XML serialization
        public CommandQueueWrapper()
        {
            Commands = new Queue<Command>();
        }

        public CommandQueueWrapper(Queue<Command> commands)
        {
            Commands = commands;
        }
    }
    static class CommandMain
    {
        public static Collection<(object, string, string)> col = new MyVector<(object, string, string)>();
        public static Dictionary<string, Command> commands = new Dictionary<string, Command>();
        public static Dictionary<string, string[]> fields = new Dictionary<string, string[]>();
        public static Dictionary<(string, string), object> default_values = new Dictionary<(string, string), object>();
        //public static string? full_command, command_name;
        //public static Queue<Command> q = new Queue<Command>();
        //public static CommandQueueWrapper q = new CommandQueueWrapper();
        public static List<Command> q = new List<Command>();
        //public static List<object> q = new List<object>();

        public static void create_collection()
        {
            col.Add((R0.fc, "author", "base"));
            col.Add((R0.ss, "author", "base"));
            col.Add((R0.cc, "author", "base"));
            col.Add((R0.vg, "author", "base"));
            col.Add((R0.rj, "author", "base"));
            col.Add((R0.gd, "author", "base"));
            col.Add((R0.tm, "author", "base"));
            col.Add((R0.vnj, "author", "base"));
            col.Add((R0.cmd, "author", "base"));

            col.Add((R0.bb1, "episode", "base"));
            col.Add((R0.bb2, "episode", "base"));
            col.Add((R0.bb3, "episode", "base"));
            col.Add((R0.tous1, "episode", "base"));
            col.Add((R0.tous2, "episode", "base"));
            col.Add((R0.tous3, "episode", "base"));

            col.Add((R0.bb, "series", "base"));
            col.Add((R0.tous, "series", "base"));

            //col.Add((R0.bb, "series", "base"));
            //col.Add((R0.tous, "series", "base"));

            //col.Add((R4.cmd, "author"));
            //col.Add((R4.fc, "author"));

            col.Add((R4.fc, "author", "secondary"));
            
            col.Add((R4.bb, "series", "secondary"));
            col.Add((R4.tous, "series", "secondary"));

            col.Add((R4.an, "movie", "secondary"));
            col.Add((R4.tgf, "movie", "secondary"));
            col.Add((R4.rotla, "movie", "secondary"));
            col.Add((R4.tgd, "movie", "secondary"));
        }

        //public static void add_commands()
        //{
        //    commands.Add("exit", new Exit());
        //    commands.Add("list", new List());
        //    commands.Add("find", new Find());
        //    commands.Add("add", new Add());
        //}

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
            //CommandMain.add_commands();
            CommandMain.add_fields();
            //CommandMain.set_defaults();
        }

        public static void Main()
        {
            while (true)
            {
                string full_command = Console.ReadLine();
                string?[] command_args; command_args = full_command.Split(' ');
                StringBuilder sb = new StringBuilder();
                sb.Append("Proj1.");
                sb.Append(Char.ToUpper(command_args[0][0]));
                sb.Append(command_args[0].Substring(1));
                string command_class = sb.ToString();

                //command_name = Char.ToUpper(command_args[0][0]) + command_args[0].Substring(1);
                //command_name[0] = ;

                //if (!commands.ContainsKey(command_name))
                //{
                //    Console.WriteLine("No such command exists!!!");
                //    continue;
                //}

                if (command_class == "Proj1.Exit" || command_class == "Proj1.Queue")
                {
                    System.Type? type = System.Type.GetType(command_class);
                    //Command com = (Command)Activator.CreateInstance(type, new object[] { command_class, command_args });
                    Command com = (Command)Activator.CreateInstance(type, command_class, command_args);
                    //Exit com = (Exit)Activator.CreateInstance(typeof(Exit), command_name, command_args);
                    //Test com = (Test) Activator.CreateInstance(typeof(Test), 69);

                    com.Execute();
                }
                else
                {
                    System.Type? type = System.Type.GetType(command_class);

                    if(type == null)
                    {
                        Console.WriteLine("Invalid command!!!");
                        continue;
                    }
                    Command com = (Command)Activator.CreateInstance(type, command_class, command_args);

                    //q.Commands.Enqueue(com);
                    q.Add(com);
                    //commands[command_name].Execute(command_args);
                }
            }
        }
    }
    public abstract class Command
    {
        public string name;
        public string[] parameters;
        public abstract void Execute();
    }

    //class Test
    //{
    //    public Test(string name, string[] parameters) { Console.WriteLine($"SUCCESS {name}, {parameters.Length}!!!"); }
    //}

    public class Delete : Command
    {
        public string name;
        public string[] parameters;

        public Delete() { }
        public Delete(string name, string[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(" ", parameters);
            return sb.ToString();
        }
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

            if (requirement.Contains('='))
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

        public List<(object ob, string type, string representation)> find()
        {
            List<(object ob, string type, string representation)> list = new List<(object ob, string type, string representation)>();

            string requested_type = parameters[1];

            //Console.WriteLine($"-------------------------------------------------");
            //Console.WriteLine($"Executing {String.Join(' ', parameters)}");

            bool br = false;
            Algorithms.ForEach(CommandMain.col.GetForwardIterator(),
                ((object ob, string type, string representation) a) =>
                {
                    if (br)
                        return;
                    if (a.type == requested_type)
                    {
                        for (int i = 2; i < parameters.Length; i++)
                        {
                            (bool success, string field, char cmp, string value) = parse_requirement(parameters[i]);
                            if (!success)
                            {
                                br = true;
                                return;
                            }

                            //if(!a.ob.get_field_values().ContainsKey(field))
                            //{
                            //    Console.WriteLine("Invalid field name!!!");
                            //    return;
                            //}

                            if (!CommandMain.fields[a.type].Contains(field))
                            {
                                Console.WriteLine("Invalid field name!!!");
                                br = true;
                                return;
                            }

                            //a.ob = (R0.Type) a.ob;
                            //R0.Type type = a.representation == "base" ? (R0.Type)a.ob : new R4.Author4Adapter((R4.Author4)a.ob);
                            R0.Type type = a.representation == "base" ? (R0.Type)a.ob : new R4.Adapter(a.type, a.ob);

                            //Dictionary<string, object> field_values = a.ob.get_field_values();
                            Dictionary<string, object> field_values = type.get_field_values();

                            if (field == "duration" || field == "releaseYear" || field == "birthYear" || field == "awards")
                            {
                                if (int.TryParse(value, out int n))
                                {
                                    if (cmp == '=' && !((int)field_values[field] == n))
                                    {
                                        //Console.WriteLine($"Requirement {i} not met!!!");
                                        list.Add(a);
                                        return;
                                    }
                                    if (cmp == '<' && !((int)field_values[field] < n))
                                    {
                                        //Console.WriteLine($"Requirement {i} not met!!!");
                                        list.Add(a);
                                        return;
                                    }
                                    if (cmp == '>' && !((int)field_values[field] > n))
                                    {
                                        //Console.WriteLine($"Requirement {i} not met!!!");
                                        list.Add(a);
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
                                    list.Add(a);
                                    return;
                                }
                                if (cmp == '<' && !(string.Compare((string)field_values[field], value) == -1))
                                {
                                    //Console.WriteLine($"Requirement {i} not met!!!");
                                    list.Add(a);
                                    return;
                                }
                                if (cmp == '>' && !(string.Compare((string)field_values[field], value) == 1))
                                {
                                    //Console.WriteLine($"Requirement {i} not met!!!");
                                    list.Add(a);
                                    return;
                                }
                            }
                        }
                        R0.Type ob = a.representation == "base" ? (R0.Type)a.ob : new R4.Adapter(a.type, a.ob);
                        //Console.WriteLine(ob);
                        //list.Add(ob);
                    }
                });
            return list;
        }

        public override void Execute()
        {
            string requested_type = parameters[1];

            Console.WriteLine($"-------------------------------------------------");
            Console.WriteLine($"Executing {String.Join(' ', parameters)}");

            List<(object ob, string type, string representation)> list = find();

            CommandMain.col = new MyVector<(object, string, string)>();

            foreach(var el in list)
               CommandMain.col.Add(el);
        }
    }

    class Queue : Command
    {
        string name;
        string[] parameters;

        public Queue(string name, string[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }
        void list()
        {
            foreach (Command com in CommandMain.q)
                Console.WriteLine(com);
        }

        void export()
        {
            string file_name = parameters[2], 
                file_path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\{file_name}", 
                format = "XML";

            if (parameters.Length >= 4) format = parameters[3];

            if (format == "XML")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Command>), new[] { typeof(Proj1.List), typeof(Find), typeof(Add) });
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "  ",
                };

                using (var fileStream = new FileStream(file_path, FileMode.Create))
                using (var xmlWriter = XmlWriter.Create(fileStream, settings))
                {
                    serializer.Serialize(xmlWriter, CommandMain.q);
                }
            }
            else if(format == "plaintext")
            {
                using (StreamWriter writer = new StreamWriter(file_path))
                {
                    foreach (Command com in CommandMain.q)
                        writer.WriteLine(com);
                }
            }
        }

        void commit()
        {
            foreach(var command in CommandMain.q)
            {
                command.Execute();
            }
        }

        void dismiss()
        {
            CommandMain.q = new List<Command>();
        }

        void load()
        {
            string file_name = parameters[2],
                file_path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\{file_name}",
                format = Path.GetExtension(file_path);

            if (format == ".xml")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Command>), new[] { typeof(Proj1.List), typeof(Find), typeof(Add) });

                List<Command> new_q;

                using (var fileStream = new FileStream(file_path, FileMode.Open))
                {
                    new_q = (List<Command>)serializer.Deserialize(fileStream);
                }

                CommandMain.q.AddRange(new_q);
            }
            else if (format == ".txt")
            {
                List<Command> new_q = new List<Command>();

                string[] lines = File.ReadAllLines(file_path);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');

                    if (parts.Length == 0)
                        continue;

                    string commandType = "Proj1." + Char.ToUpper(parts[0][0]) + parts[0].Substring(1);

                    //System.Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandType);
                    System.Type type = Assembly.GetExecutingAssembly().GetType(commandType);

                    //if (type == null || !typeof(Command).IsAssignableFrom(type))
                    if (type == null)
                    {
                        Console.WriteLine($"Unknown command: {line} !!!");
                        Console.WriteLine($"Exiting load.");
                        return;
                    }

                    //object[] constructorArgs = parts.Skip(1).Select(p => (object)p).ToArray();
                    Command command = (Command)Activator.CreateInstance(type, commandType, parts);
                    new_q.Add(command);
                }

                CommandMain.q.AddRange(new_q);
            }
            else
            {
                Console.WriteLine("Wrong file extension!!!");
            }

        }
        public override void Execute()
        {
            if(parameters == null || parameters.Length < 2)
            {
                Console.WriteLine("No argument provided for queue!!!");
                return;
            }
            
            System.Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(parameters[1], BindingFlags.NonPublic | BindingFlags.Instance);
            //MethodInfo theMethod = thisType.GetMethod(parameters[1]);

            if (theMethod == null)
            {
                Console.WriteLine("Wrong parameter for queue!!!");
                return;
            }
            theMethod.Invoke(this, null);

            //if (parameters[1] == "print")
            //    List();
            //else if (parameters[1] == "export")
            //    Export();
            //else
            //    Console.WriteLine("Invalid argument provided for queue!!!");
        }
    }

    class Exit : Command
    {
        public Exit(string name, string[] parameters) { }
        public override void Execute()
        {
            Environment.Exit(0);
        }
    }

    //[Serializable]
    public class List : Command
    {
        public string name;
        public string[] parameters;

        public List() { }
        public List(string name, string[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append(name);
            //foreach (string param in parameters) 
            //    sb.AppendJoin(' ', param);
            sb.AppendJoin(" ", parameters);
            return sb.ToString();
        }
        public override void Execute()
        {
            string requested_type = parameters[1];
            if(!CommandMain.fields.ContainsKey(requested_type))
            {
                Console.WriteLine("Invalid type name!!!");
                return;
            }

            Console.WriteLine($"-------------------------------------------------");
            Console.WriteLine($"Executing {String.Join(' ', parameters)}");

            Algorithms.ForEach(CommandMain.col.GetForwardIterator(), 
                ((object ob, string type, string representation) a) => 
                {
                    if (a.type == requested_type)
                    {
                        R0.Type type = a.representation == "base" ? (R0.Type)a.ob : new R4.Adapter(a.type, a.ob);
                        //Console.WriteLine(a.ob);
                        Console.WriteLine(type);
                        //Console.WriteLine((new R4.Adapter(a.type, a.ob)).ToString());
                        //Console.WriteLine(type.ToString());
                    }
                });
        }
    }

    public class Find : Command
    {
        public string name;
        public string[] parameters;

        public Find() { }
        public Find(string name, string[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(" ", parameters);
            return sb.ToString();
        }
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
        public override void Execute()
        {
            string requested_type = parameters[1];

            Console.WriteLine($"-------------------------------------------------");
            Console.WriteLine($"Executing {String.Join(' ', parameters)}");

            bool br = false;
            Algorithms.ForEach(CommandMain.col.GetForwardIterator(),
                ((object ob, string type, string representation) a) =>
                {
                    if (br)
                        return;
                    if (a.type == requested_type)
                    {
                        for(int i = 2; i < parameters.Length; i++)
                        {
                            (bool success, string field, char cmp, string value) = parse_requirement(parameters[i]);
                            if (!success)
                            {
                                br = true;
                                return;
                            }
                            
                            //if(!a.ob.get_field_values().ContainsKey(field))
                            //{
                            //    Console.WriteLine("Invalid field name!!!");
                            //    return;
                            //}

                            if (!CommandMain.fields[a.type].Contains(field))
                            {
                                Console.WriteLine("Invalid field name!!!");
                                br = true;
                                return;
                            }

                            //a.ob = (R0.Type) a.ob;
                            //R0.Type type = a.representation == "base" ? (R0.Type)a.ob : new R4.Author4Adapter((R4.Author4)a.ob);
                            R0.Type type = a.representation == "base" ? (R0.Type)a.ob : new R4.Adapter(a.type, a.ob);

                            //Dictionary<string, object> field_values = a.ob.get_field_values();
                            Dictionary<string, object> field_values = type.get_field_values();

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
                        R0.Type ob = a.representation == "base" ? (R0.Type)a.ob : new R4.Adapter(a.type, a.ob);
                        Console.WriteLine(ob);
                    }
                });
        }
    }

    public class Edit : Command
    {
        public string name;
        public string[] parameters;

        public Edit() { }
        public Edit(string name, string[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(" ", parameters);
            return sb.ToString();
        }
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
        private static void AddToCollection(string type, string repr, Dictionary<string, object> field_values)
        {
            if (type == "author")
            {
                if (repr == "base")
                    CommandMain.col.Add((new R0.Author0((string)field_values["name"], (string)field_values["surname"],
                    (int)field_values["birthYear"], (int)field_values["awards"]), "author", "base"));
                else
                    CommandMain.col.Add((new R4.Author4((string)field_values["name"], (string)field_values["surname"],
                        (int)field_values["birthYear"], (int)field_values["awards"]), "author", "secondary"));
            }
            else if (type == "episode")
            {
                if (repr == "base")
                    CommandMain.col.Add((new R0.Episode0((string)field_values["title"], (int)field_values["duration"],
                    (int)field_values["releaseYear"], R0.fc), "episode", "base"));
                else
                    CommandMain.col.Add((new R4.Episode4((string)field_values["title"], (int)field_values["duration"],
                    (int)field_values["releaseYear"], -1), "episode", "secondary"));
            }
            else if (type == "series")
            {
                if (repr == "base")
                    CommandMain.col.Add((new R0.Series0((string)field_values["title"], (string)field_values["genre"],
                    R0.fc, new List<Episode0>()), "series", "base"));
                else
                    CommandMain.col.Add((new R4.Series4((string)field_values["title"], (string)field_values["genre"],
                    -1, new List<int>()), "series", "secondary"));
            }
            else if (type == "movie")
            {
                if (repr == "base")
                    CommandMain.col.Add((new R0.Movie0((string)field_values["title"], (string)field_values["genre"], R0.fc,
                    (int)field_values["duration"], (int)field_values["releaseYear"]), "movie", "base"));
                else
                    CommandMain.col.Add((new R4.Movie4((string)field_values["title"], (string)field_values["genre"], -1,
                    (int)field_values["duration"], (int)field_values["releaseYear"]), "movie", "secondary"));
            }
        }
        public override void Execute()
        {
            Console.WriteLine($"-------------------------------------------------");
            Console.WriteLine($"Executing {String.Join(' ', parameters)}");

            if (parameters.Length < 3)
            {
                Console.WriteLine("Provide more parameters!!!");
                return;
            }
            string type = parameters[1], repr = parameters[2];

            if (!CommandMain.fields.ContainsKey(type))
            {
                Console.WriteLine("This is not a valid type!!!");
                return;
            }

            if (repr != "base" && repr != "secondary")
            {
                Console.WriteLine("Correct value of the 3rd parameter is base OR secondary");
                return;
            }

            Console.Write("Available fields: [ ");
            foreach (string field1 in CommandMain.fields[type])
            {
                Console.Write(field1);
                Console.Write(" ");
            }
            Console.Write("]\n");

            Dictionary<string, object> field_values = BaseBuilder(type);

            string line, field, value;

            while (true)
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
                else if (!CommandMain.fields[type].Contains(field))
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

    public class Add : Command
    {
        public string name;
        public string[] parameters;

        public Add() { }
        public Add(string name, string[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(" ", parameters);
            return sb.ToString();
        }
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
        private static void AddToCollection(string type, string repr, Dictionary<string, object> field_values)
        {
            if(type == "author")
            {
                if(repr == "base")
                    CommandMain.col.Add((new R0.Author0((string) field_values["name"], (string) field_values["surname"], 
                    (int) field_values["birthYear"], (int) field_values["awards"]), "author", "base"));
                else
                    CommandMain.col.Add((new R4.Author4((string)field_values["name"], (string)field_values["surname"],
                        (int)field_values["birthYear"], (int)field_values["awards"]), "author", "secondary"));
            }
            else if (type == "episode")
            {
                if (repr == "base")
                    CommandMain.col.Add((new R0.Episode0((string)field_values["title"], (int)field_values["duration"], 
                    (int)field_values["releaseYear"], R0.fc), "episode", "base"));
                else
                    CommandMain.col.Add((new R4.Episode4((string)field_values["title"], (int)field_values["duration"],
                    (int)field_values["releaseYear"], -1), "episode", "secondary"));
            }
            else if (type == "series")
            {
                if (repr == "base")
                    CommandMain.col.Add((new R0.Series0((string)field_values["title"], (string)field_values["genre"], 
                    R0.fc, new List<Episode0>()), "series", "base"));
                else
                    CommandMain.col.Add((new R4.Series4((string)field_values["title"], (string)field_values["genre"],
                    -1, new List<int>()), "series", "secondary"));
            }
            else if (type == "movie")
            {
                if (repr == "base")
                    CommandMain.col.Add((new R0.Movie0((string)field_values["title"], (string)field_values["genre"], R0.fc, 
                    (int)field_values["duration"], (int)field_values["releaseYear"]), "movie", "base"));
                else
                    CommandMain.col.Add((new R4.Movie4((string)field_values["title"], (string)field_values["genre"], -1,
                    (int)field_values["duration"], (int)field_values["releaseYear"]), "movie", "secondary"));
            }
        }
        public override void Execute()
        {
            Console.WriteLine($"-------------------------------------------------");
            Console.WriteLine($"Executing {String.Join(' ', parameters)}");

            if (parameters.Length < 3)
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
                Console.WriteLine("Correct value of the 3rd parameter is base OR secondary");
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
