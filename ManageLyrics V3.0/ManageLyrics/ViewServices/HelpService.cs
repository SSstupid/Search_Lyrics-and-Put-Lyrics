namespace ManageLyrics;

/// <summary>
/// Service of open window
/// </summary>
public class HelpService : IWindowService
{
    // Base open window
    public void ShowWindow()
    {
        VideoHelper win = new VideoHelper();
        win.Show();
    }

    // Open window with datacontent(viewmodel)
    public void ShowWindow(object viewModel)
    {
        var win = new VideoHelper();
        win.Content = viewModel;
        win.Show();
    }
}