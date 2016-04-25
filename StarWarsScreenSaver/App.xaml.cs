using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace StarWarsScreenSaver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow window;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Preview mode--display in little window in Screen Saver dialog
            // (Not invoked with Preview button, which runs Screen Saver in
            // normal /s mode).
            if (e.Args[0].ToLower().StartsWith("/p"))
            {
                // do nothing
            }

            // Normal screensaver mode.  Either screen saver kicked in normally,
            // or was launched from Preview button
            else if (e.Args[0].ToLower().StartsWith("/s"))
            {
                MainWindow window = new MainWindow();
                window.Show();
            }

            // Config mode, launched from Settings button in screen saver dialog
            else if (e.Args[0].ToLower().StartsWith("/c"))
            {
                SettingsWindow win = new SettingsWindow();
                win.Show();
            }

            // If not running in one of the sanctioned modes, shut down the app
            // immediately (because we don't have a GUI).
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
