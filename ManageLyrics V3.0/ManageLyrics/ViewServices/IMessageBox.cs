﻿using System.Windows;

namespace ManageLyrics;

public interface IMessageBox
{
    //// <summary>Displays a message box that has a message, title bar caption, and button; and that returns a result.</summary>          
    MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button);
}