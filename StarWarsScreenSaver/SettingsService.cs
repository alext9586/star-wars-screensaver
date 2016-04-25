using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StarWarsScreenSaver
{
    public class SettingsService
    {
        private const string SettingsFile = "swss.xml";
        private string _settingsFilePath = string.Empty;

        public SettingsService()
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _settingsFilePath = Path.Combine(userPath, SettingsFile);
        }

        public void Save(string message)
        {
            try
            {
                FileStream fs = new FileStream(_settingsFilePath, FileMode.OpenOrCreate);
                TextWriter writer = new StreamWriter(fs, new UTF8Encoding());
                writer.Write(message);
                writer.Close();
            }
            catch { }
        }

        public string Load()
        {
            string settings = String.Empty;

            try
            {
                FileStream fs = new FileStream(_settingsFilePath, FileMode.OpenOrCreate);
                TextReader reader = new StreamReader(fs);
                settings = reader.ReadToEnd();
            }
            catch { }

            return string.IsNullOrWhiteSpace(settings) ? "No text has been saved via settings dialog. This message will repeat in 90 seconds. Press ESC to exit." : settings;
        }
    }
}
