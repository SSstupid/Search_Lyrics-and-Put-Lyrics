using System.Windows;

namespace ManageLyrics;

public class MessageBoxService : IMessageBox
{
    public MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
    {
        return MessageBox.Show(messageBoxText, caption, button, MessageBoxImage.None, MessageBoxResult.None, MessageBoxOptions.None);
    }
}