using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ManageLyrics
{
    public class ListViewViewModel : BaseViewModel
    {
        public List<LyricBasicInfo> LyricSearchList { get; set; }
        ALSongLyric Bus = new ALSongLyric();

        public string? TextBoxLyrics { get; set; }

        public string? TextBoxArtist { get; set; }

        public string? TextBoxTitle { get; set; } 

        public string ResultCount { get; set; } = "Result :";
   
        public ObservableCollection<ListModel> SongList { get; set; }
        //ItemImage AlbumImg = new ItemImage();

        public ListModel ListViewSelectedItem { get; set; }

        public LyricBasicInfo ComboSelectedItem { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand PutTextCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ListViewViewModel()
        {
            SearchCommand = new RelayParameterizedCommand(Search);
            PutTextCommand = new RelayCommand(PutText);
            DeleteCommand = new RelayParameterizedCommand(DeleteItem);
        }

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

        private void PutText()
        {
            if(!string.IsNullOrWhiteSpace(TextBoxLyrics) && ListViewSelectedItem != null)
            {
                if (MessageBox.Show("do you want to put the lyrics", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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

        public void ListDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

        /// <summary>
        /// dragdrop event for add item in listview
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
            
        public void ComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboSelectedItem !=  null)
            {
                LyricInfo LyricInfoSelected = Bus.GetLyricsFromID(ComboSelectedItem.LyricID);
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

        /// <summary>
        /// Find the Lyrics
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
                    lyricBasicInfos = Bus.GetLyricsSearch(Artist, Title);
                    if (lyricBasicInfos != null)
                    {
                        LyricSearchList = lyricBasicInfos;
                        ResultCount = "Result : " + lyricBasicInfos.Count;
                    }
                    else
                    {
                        LyricSearchList = null;
                        MessageBox.Show("No results.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the artist and the title.");
                }
            }
            catch
            {
                MessageBox.Show("failed: Check it again and try it.");
            }
        }

        #endregion
    }
}
