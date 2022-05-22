using System.Windows;

namespace ManageLyrics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ALSongLyric Bus = new ALSongLyric();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ListViewViewModel();
        }
    }
}
