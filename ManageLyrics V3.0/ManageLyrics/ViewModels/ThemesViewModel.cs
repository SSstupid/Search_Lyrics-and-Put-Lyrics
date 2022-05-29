using System;
using System.Windows;

namespace ManageLyrics;

/// <summary>
/// The themes viewmodel for themes controll
/// </summary>
public class ThemesViewModel : BaseViewModel
{
    #region properties

    /// <summary>
    /// Set light theme
    /// </summary>
    public ResourceDictionary Light = new ResourceDictionary { Source = new Uri(@"/ManageLyrics;component/Themes/LightTheme.xaml", UriKind.Relative) };
   
    /// <summary>
    /// Set controll style from theme
    /// </summary>
    public ResourceDictionary ToolBox = new ResourceDictionary { Source = new Uri(@"/ManageLyrics;component/Style/ToolBox.xaml", UriKind.Relative) };
    
    /// <summary>
    /// The current theme enum
    /// </summary>
    public ThemesMode CurrentTheme { get; set; } = ThemesMode.Light;

    #endregion

    /// <summary>
    /// The themes change
    /// </summary>
    public void ModeChange()
    {
        if (CurrentTheme == ThemesMode.Light)
        {
            App.Current.Resources.MergedDictionaries.Add(Light);
            App.Current.Resources.MergedDictionaries.Add(ToolBox);
        }
        else if (CurrentTheme == ThemesMode.Dark)
        {
            App.Current.Resources.MergedDictionaries.Remove(ToolBox);
            App.Current.Resources.MergedDictionaries.Remove(Light);
        }
    }
}