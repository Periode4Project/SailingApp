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
        static Config()
        {
            User = new User
            {
                Email = null,
                Password = null
            };
            FirstStartup = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "config.json");
            //define the string, so it can be used inside the streamreader loop
            string content;

            //Check if the file exists. If not, create it. it'll return "" due to there being no API key, which is handled in the key verification process
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
                User = (User)serializer.Deserialize(file, typeof(User));
            }

        }
    }
}
