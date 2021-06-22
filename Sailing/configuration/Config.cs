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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "config.json");
            User = new User
            {
                Email = null,
                Password = null
            };
            Language = "Nederlands";
            ConfigFile baseConfig = new ConfigFile
            {
                User = User,
                Language = Language
            };
            FirstStartup = false;
            
            if (!File.Exists(filename))
            {
                string json = JsonConvert.SerializeObject(baseConfig, Formatting.Indented);
                using (StreamWriter outFile = new StreamWriter(filename))
                {
                    outFile.Write(json);
                }
                FirstStartup = true;
            }

            //properly handle Streamreader
            using (StreamReader file = File.OpenText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                ConfigFile configFile = (ConfigFile)serializer.Deserialize(file, typeof(ConfigFile));
                User = configFile.User;
                Language = configFile.Language;
            }
        }
        public static void Write()
        {
            ConfigFile config = new ConfigFile
            {
                User = User,
                Language = Language
            };
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "config.json");
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            using (StreamWriter outFile = new StreamWriter(path: filename, append: false))
            {
                outFile.Write(json);
            }

        }
    }
}
