using System;
using System.Windows;
namespace ManageLyrics;

public class ThemesViewModel : BaseViewModel
{

    public ResourceDictionary Light = new ResourceDictionary { Source = new Uri(@"/ManageLyrics;component/Themes/LightTheme.xaml", UriKind.Relative) };
   
    public ResourceDictionary ToolBox = new ResourceDictionary { Source = new Uri(@"/ManageLyrics;component/Style/ToolBox.xaml", UriKind.Relative) };
    
    public ThemesMode CurrentTheme { get; set; } = ThemesMode.Light;

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