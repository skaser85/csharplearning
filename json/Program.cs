using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace json
{
    class Program
    {
        static void Main(string[] args)
        {
            // string jsonString = File.ReadAllText("test.json");
            // Console.WriteLine(jsonString);
            Settings settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("test.json"));
            foreach (DB db in settings.Databases) {
                Console.WriteLine(db.Name);
                Console.WriteLine(db.Version);
                if (db.Scanning.Count > 0) {
                    foreach (string s in db.Scanning) {
                        Console.WriteLine(s);
                    }
                }
                if (db.Printing.Count > 0) {
                    foreach (string p in db.Printing) {
                        Console.WriteLine(p);
                    }
                }
            }
        }
    }

    class Settings
    {
        public string SQLServer { get; set; }
        public string BaseDir { get; set; }
        public List<string> EmailAddrs { get; set; }
        public List<DB> Databases { get; set; }
    }

    class DB
    {
        public string Name { get; set; }
        public int Version { get; set; }
        public List<string> Scanning { get; set; }
        public List<string> Printing { get; set; }
    }
}
