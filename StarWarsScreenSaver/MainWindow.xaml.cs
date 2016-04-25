using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// Star Wars text effect source: http://stackoverflow.com/questions/3157341/starwars-text-effect-in-wpf
// Reference: https://stuff.seans.com/2008/09/01/writing-a-screen-saver-in-wpf/

namespace StarWarsScreenSaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SettingsService settingsService = new SettingsService();
        private string _message;

        public string ScrollText
        {
            set
            {
                _message = value;
                OnPropertyChanged("ScrollText");
            }
            get { return _message; }
        }

        protected void OnPropertyChanged(string message)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(message));
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ScrollText = settingsService.Load();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            //Application.Current.Shutdown();
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
