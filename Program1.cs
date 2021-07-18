using System;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleTest
{
    class Player
    {
        public string Name;
        public string Race;
        public string Class;
        public int Level;

        public Player() { }
        public Player(string n, string r, string c, int lvl)
        {
            Name = n;
            Race = r;
            Class = c;
            Level = lvl;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("Valeros", "Human", "Warrior", 1);
            string JsonString = JsonConvert.SerializeObject(p1);
            Console.WriteLine(JsonString);

            Player p2 = JsonConvert.DeserializeObject<Player>(JsonString);
            Console.WriteLine(p2.Name + " " + p2.Race + " " + p2.Class + " " + p2.Level);


            JsonSerializer serializer = new JsonSerializer();

            StreamWriter StreamWriterExample = new StreamWriter(@"d:\json.txt");
            JsonWriter JsonWriterExample = new JsonTextWriter(StreamWriterExample);
            serializer.Serialize(JsonWriterExample, p1);
            StreamWriterExample.Close();


            StreamReader StreamReaderExample = new StreamReader(@"d:\json.txt");
            JsonReader JsonReaderExample = new JsonTextReader(StreamReaderExample);
            Player p3 = serializer.Deserialize<Player>(JsonReaderExample);
            Console.WriteLine(p3.Name + " " + p3.Race + " " + p3.Class + " " + p3.Level);
            StreamReaderExample.Close();

        }
    }
}
