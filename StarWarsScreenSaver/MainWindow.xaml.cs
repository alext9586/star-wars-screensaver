using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

// Star Wars text effect source: http://stackoverflow.com/questions/3157341/starwars-text-effect-in-wpf
// Reference: https://stuff.seans.com/2008/09/01/writing-a-screen-saver-in-wpf/
//            http://www.harding.edu/fmccown/screensaver/screensaver.html

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
        private Point _mouseLocation;
        private bool _isActive;

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
            Point position = e.MouseDevice.GetPosition(this);

            if (!_isActive)
            {
                _mouseLocation = position;
                _isActive = true;
            }
            else
            {
                if (Math.Abs(_mouseLocation.X - position.X) > 20 || Math.Abs(_mouseLocation.Y - position.Y) > 20)
                {
                    this.Close();
                }
            }
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
