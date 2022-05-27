using System;
using System.Windows;
using System.Windows.Input;

namespace ManageLyrics;

public class ThemesViewModel : BaseViewModel
{

    public ResourceDictionary Light = new ResourceDictionary { Source = new Uri(@"/ManageLyrics;component/Themes/LightTheme.xaml", UriKind.Relative) };
   
    public ResourceDictionary ToolBox = new ResourceDictionary { Source = new Uri(@"/ManageLyrics;component/Style/ToolBox.xaml", UriKind.Relative) };

    public ICommand ModeCommand { get; set; }

    public string ChangeMode { get; set; } = "Light";

    public ThemesMode CurrentTheme { get; set; } = ThemesMode.Light;

    public ThemesViewModel()
    {
        ModeCommand = new RelayCommand(ThemeModeChange);
    }

    private void ThemeModeChange()
    {
        ModeChange();

        if (CurrentTheme == ThemesMode.Dark)
        {
            CurrentTheme = ThemesMode.Light;
            ChangeMode = "Light";
        }
        else if (CurrentTheme == ThemesMode.Light)
        {
            CurrentTheme = ThemesMode.Dark;
            ChangeMode = "Dark";
        }
    }

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