using System.Windows;
using System.Windows.Input;

namespace ManageLyrics;

/// <summary>
/// Contact.xaml에 대한 상호 작용 논리
/// </summary>
public partial class Contact : Window
{
    public Contact()
    {
        InitializeComponent();
    }

    /// <summary>
    /// TODO : Open window browser then go to link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
    {
        System.Diagnostics.Process.Start("cmd", "/c start https://github.com/SSstupid");
        e.Handled = true;
    }

    /// <summary>
    /// Funtion of set the window location
    /// </summary>
    private void MoveBottomRightEdgeOfWindowToMousePosition()
    {
        var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
        var mouse = transform.Transform(GetMousePosition());
        Left = mouse.X + 5;
        Top = mouse.Y + 5;
    }

    /// <summary>
    /// Get mouse position
    /// </summary>
    /// <returns></returns>
    public Point GetMousePosition()
    {
        var point = Mouse.GetPosition(Application.Current.MainWindow);
        Point ScreenPosition = Application.Current.MainWindow.PointToScreen(point);
        return new Point(ScreenPosition.X, ScreenPosition.Y);
    }

    /// <summary>
    /// Set the window location when loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        MoveBottomRightEdgeOfWindowToMousePosition();
    }
}