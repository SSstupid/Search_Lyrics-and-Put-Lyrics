using System;
using System.Windows;
using System.Windows.Input;

namespace ManageLyrics;

/// <summary>
/// VideoHeler.xaml에 대한 상호 작용 논리
/// </summary>
public partial class VideoHelper : Window
{
    public VideoHelper()
    {
        InitializeComponent();
    }

    /// <summary>
    /// The window loaded and set open window location on mouse point
    /// then play video
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        MoveBottomRightEdgeOfWindowToMousePosition();

        Uri uri = new Uri("Images/HelperVideo.Mp4", UriKind.RelativeOrAbsolute);
        this.mediaElement.Source = uri;
        this.mediaElement.Play();
    }

    #region Get current mouse point then set window location

    /// <summary>
    /// Funtion of set the window location
    /// </summary>
    private void MoveBottomRightEdgeOfWindowToMousePosition()
    {
        var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
        var mouse = transform.Transform(GetMousePosition());
        Left = mouse.X - 80;
        Top = mouse.Y - 65;
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

    #endregion
}