using System.Windows;
namespace ManageLyrics;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Setup IoC
        IoC.Setup();

        Current.MainWindow = new MainWindow();
        Current.MainWindow.Show();
    }
}