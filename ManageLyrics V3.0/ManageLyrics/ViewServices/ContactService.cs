using System.Windows;

namespace ManageLyrics;

/// <summary>
/// Service of open window
/// </summary>
public class ContactService : IWindowService
{
    // base open window
    public void ShowWindow()
    {
        var win = new Contact();
        win.Show();
    }

    // open window with datacontent(viewmodel)
    public void ShowWindow(object viewModel)
    {
        var win = new Contact();
        win.Content = viewModel;
        win.Show();
    }
}