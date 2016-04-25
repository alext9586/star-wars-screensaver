using System;
using System.IO;
using Microsoft.Win32;

// Reference: https://stuff.seans.com/2008/09/01/writing-a-screen-saver-in-wpf/

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
                // Create or get existing Registry subkey
                RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\StarWarsScreenSaver");

                key.SetValue("message", message);
            }
            catch { }
        }

        public string Load()
        {
            string settings = String.Empty;

            try
            {
                // Get the value stored in the Registry
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\StarWarsScreenSaver");
                if (key != null)
                    settings = (string)key.GetValue("message");
            }
            catch { }

            return string.IsNullOrWhiteSpace(settings) ? "No text has been saved via settings dialog. This message will repeat in 90 seconds. Press ESC to exit." : settings;
        }
    }
}
