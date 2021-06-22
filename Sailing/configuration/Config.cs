using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sailing
{
    public static class Config
    {
        public static User User { get; set; }
        public static bool FirstStartup { get; set; }
        public static string Language { get; set; }
        static Config()
        {
            ConfigFile baseConfig = new ConfigFile
            {
                User = new User
                {
                    Email = null,
                    Password = null
                },
                Language = "Nederlands"
            };

            User = baseConfig.User;
            Language = baseConfig.Language;
            FirstStartup = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "config.json");
            if (!File.Exists(filename))
            {
                string json = JsonConvert.SerializeObject(User, Formatting.Indented);
                using (StreamWriter outFile = new StreamWriter(filename))
                {
                    outFile.Write(json);
                }
                FirstStartup = true;
            }

            //properly handle Streamreader
            using (StreamReader file = File.OpenText(@"config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                ConfigFile configFile = (ConfigFile)serializer.Deserialize(file, typeof(ConfigFile));
                User = configFile.User;
                Language = configFile.Language;
            }
        }
    }
}
