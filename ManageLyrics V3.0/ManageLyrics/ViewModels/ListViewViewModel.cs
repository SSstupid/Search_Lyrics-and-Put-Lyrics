using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManageLyrics;

public class ListViewViewModel : BaseViewModel
{
    #region Public Properties

    public List<LyricBasicInfo> LyricSearchList { get; set; }

    public string? TextBoxLyrics { get; set; }

    public string? TextBoxArtist { get; set; }

    public string? TextBoxTitle { get; set; } 

    public string ResultCount { get; set; } = "Result :";

    public string ChangeMode { get; set; } = "Light";
   
    public ObservableCollection<ListModel> SongList { get; set; }
    //ItemImage AlbumImg = new ItemImage();

    public ListModel ListViewSelectedItem { get; set; }

    public LyricBasicInfo ComboSelectedItem { get; set; }

    #endregion

    #region ICommand

    /// <summary>
    /// The command to SearchLyrics
    /// </summary>
    public ICommand SearchCommand { get; set; }

    /// <summary>
    /// The command to Put (Lyric,Artist,Title)text into file
    /// </summary>
    public ICommand PutTextCommand { get; set; }

    /// <summary>
    /// The command to remove item of lsitview
    /// </summary>
    public ICommand DeleteCommand { get; set; }

    /// <summary>
    /// The command to change the themes
    /// </summary>
    public ICommand ModeCommand { get; set; }

    /// <summary>
    /// The command to open the contact window
    /// </summary>
    public ICommand ContactCommand { get; set; }

    /// <summary>
    /// The command to show the help video
    /// </summary>
    public ICommand HelpCommand { get; set; }

    #endregion

    #region Constructor

    public ListViewViewModel()
    {
        // Create commands
        SearchCommand = new RelayParameterizedCommand(Search);
        DeleteCommand = new RelayParameterizedCommand(DeleteItem);
        PutTextCommand = new RelayCommand(PutText);
        ModeCommand = new RelayCommand(ThemeModeChange);
        ContactCommand = new RelayCommand(ContactShow);
        HelpCommand = new RelayCommand(HelpShow);
    }

    #endregion

    #region Command Action

    private void Search(object parameter)
    {
        try
        {
            var values = (object[])parameter;
            var SearchArtist = (string)values[0];
            var SearchTitle = (string)values[1];
            SearchLyrics(SearchArtist, SearchTitle);
        }
        catch
        {
            return;
        }
    }

    private void DeleteItem(object parameter)
    {
        if(ListViewSelectedItem != null)
        {
            var IListItems = (IList)parameter;
            var ListItems = IListItems.Cast<ListModel>().ToList();

            foreach (var i in ListItems)
            {
                SongList.Remove(i);
            }
        }
    }

    private void PutText()
    {
        if(!string.IsNullOrWhiteSpace(TextBoxLyrics) && ListViewSelectedItem != null)
        {
            if (IoC.Get<MessageBoxService>().Show("do you want to put the lyrics", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var file = TagLib.File.Create(ListViewSelectedItem.Path);
                file.Tag.Lyrics = TextBoxLyrics;
                file.Tag.Performers = new string[1] { TextBoxArtist };
                file.Tag.Title = TextBoxTitle;
                file.Save();

                ListViewSelectedItem.TextBoxArtist = TextBoxArtist;
                ListViewSelectedItem.TextBoxTitle = TextBoxTitle;
                ListViewSelectedItem.Lyrics = TextBoxLyrics;
            }
            else
            {
                return ;
            }
        }
    }

    private void ThemeModeChange()
    {
        IoC.Get<ThemesViewModel>().ModeChange();

        if (IoC.Get<ThemesViewModel>().CurrentTheme == ThemesMode.Dark)
        {
            IoC.Get<ThemesViewModel>().CurrentTheme = ThemesMode.Light;
            ChangeMode = "Light";
        }
        else if (IoC.Get<ThemesViewModel>().CurrentTheme == ThemesMode.Light)
        {
            IoC.Get<ThemesViewModel>().CurrentTheme = ThemesMode.Dark;
            ChangeMode = "Dark";
        }
    }

    private void ContactShow()
    {
        //IoC.Get<MessageBoxService>().Show("GitHub : https://github.com/SSstupid\nEmail : rlawoghks3@gmail.com", "Contact", MessageBoxButton.OK);
        IoC.Get<ContactService>().ShowWindow();
    }

    private void HelpShow()
    {
        IoC.Get<HelpService>().ShowWindow();
    }

    #endregion

    #region Events of listview, combobox

    /// <summary>
    /// Listview drag enter event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ListDragEnter(object sender, DragEventArgs e)
    {
        e.Effects = DragDropEffects.Copy;
    }


    /// <summary>
    /// dragdrop event for add listview item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ListDrag(object sender, DragEventArgs e)
    {
        ObservableCollection<ListModel> filesData = new();

        if(SongList != null)
        {
            filesData = SongList;
        }

        string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);

        foreach (string fileName in path)
        {
            using (var SongFile = TagLib.File.Create(fileName))
            {
                filesData.Add(new ListModel()
                {
                    Path = fileName,
                    FileName = GetFileName(fileName),
                    Artist = SongFile.Tag.FirstPerformer ?? "NoArtist",
                    Title = SongFile.Tag.Title ?? "NoTitle",
                    Lyrics = SongFile.Tag.Lyrics,
                    TextBoxArtist = SongFile.Tag.FirstPerformer,
                    TextBoxTitle = SongFile.Tag.Title,
                });
            }
        }
        SongList = filesData;
    }

    /// <summary>
    /// Gets text of listviewitem information when item selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ListSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(ListSelectionChanged != null && ListViewSelectedItem != null)
        {
            try 
            { 
                TextBoxLyrics = ListViewSelectedItem.Lyrics; 
                TextBoxArtist = ListViewSelectedItem.TextBoxArtist; 
                TextBoxTitle = ListViewSelectedItem.TextBoxTitle; 
            }
            catch { }
        }
    }

    /// <summary>
    /// Gets text of comboboxitem information when item selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ComboSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ComboSelectedItem !=  null)
        {
            LyricInfo LyricInfoSelected = IoC.Get<ALSongLyric>().GetLyricFromID(ComboSelectedItem.LyricID);
            TextBoxArtist = ComboSelectedItem.Artist;
            TextBoxTitle = ComboSelectedItem.Title;
            TextBoxLyrics = LyricInfoSelected.Lyric;
            if (LyricInfoSelected != null)
            {
                    
                if (true)
                {
                    string[] TimeRemove = LyricInfoSelected.Lyric.Split('\n');
                    TextBoxLyrics = null;
                    foreach (string NewText in TimeRemove)
                    {
                        if (NewText.Length > 9)
                            TextBoxLyrics += NewText.Substring(10) + "\n";
                    }
                }
                else TextBoxLyrics = LyricInfoSelected.Lyric;
            }
        }
    }

    #endregion

    /// <summary>
    /// Search the Lyrics
    /// </summary>
    /// <param name="Artist"></param>
    /// <param name="Title"></param>
    public void SearchLyrics(string Artist, string Title)
    {
        List<LyricBasicInfo> lyricBasicInfos = new List<LyricBasicInfo>();
        try
        {
            if (!(String.IsNullOrWhiteSpace(Artist) && String.IsNullOrWhiteSpace(Title)))
            {
                lyricBasicInfos = IoC.Get<ALSongLyric>().GetLyricsSearch(Artist, Title);
                if (lyricBasicInfos != null)
                {
                    LyricSearchList = lyricBasicInfos;
                    ResultCount = "Result : " + lyricBasicInfos.Count;
                }
                else
                {
                    LyricSearchList = null;
                    IoC.Get<MessageBoxService>().Show("No results.", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                IoC.Get<MessageBoxService>().Show("Please enter the artist and the title.", "Error", MessageBoxButton.OK);
            }
        }
        catch
        {
            IoC.Get<MessageBoxService>().Show("failed: Check it again and try it.", "Error", MessageBoxButton.OK);
        }
    }

    #region Helpers

    /// <summary>
    /// Find the file or folder name from a full path
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetFileName(string path)
    {
        // If we have no path, return empty
        if (string.IsNullOrEmpty(path))
            return string.Empty;

        // Make all slashes back slashes
        var normalizedPath = path.Replace('/', '\\');

        //Find the last backlash in the path
        var lastIndex = normalizedPath.LastIndexOf('\\');

        // If we don`t find a backslash, return the path itself
        if (lastIndex <= 0)
            return path;

        // Return the name after the last back slash
        return path.Substring(lastIndex + 1);
    }

    #endregion
}