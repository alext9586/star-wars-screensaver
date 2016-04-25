using System.Windows;

// Reference: https://stuff.seans.com/2008/09/01/writing-a-screen-saver-in-wpf/
//            https://social.msdn.microsoft.com/Forums/vstudio/en-US/62650892-44b7-4b85-9518-5a664572d48b/screensaver-does-not-work-properly-on-windows-8?forum=wpf
namespace StarWarsScreenSaver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Preview mode--display in little window in Screen Saver dialog
            // (Not invoked with Preview button, which runs Screen Saver in
            // normal /s mode).
            if (e.Args[0].ToLower().StartsWith("/p"))
            {
                // do nothing. it's hard.
                Application.Current.Shutdown();
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
