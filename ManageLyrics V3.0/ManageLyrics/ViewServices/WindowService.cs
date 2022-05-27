namespace ManageLyrics;

public class WindowService : IWindowService
{
    public void ShowWindow(object viewModel)
    {
        var win = new Contact();
        win.Content = viewModel;
        win.Show();
    }
      
}