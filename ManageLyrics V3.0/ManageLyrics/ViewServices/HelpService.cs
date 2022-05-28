using System.Windows;

namespace ManageLyrics;

/// <summary>
/// Service of open window
/// </summary>
public class HelpService : IWindowService
{
    // Base open window
    public void ShowWindow()
    {
        VideoHeler win = new VideoHeler();
        win.Show();
    }

    // Open window with datacontent(viewmodel)
    public void ShowWindow(object viewModel)
    {
        var win = new VideoHeler();
        win.Content = viewModel;
        win.Show();
    }
}