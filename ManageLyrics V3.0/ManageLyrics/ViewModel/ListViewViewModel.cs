using System;
using System.Collections.Generic;
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

        public string? TestTextLyrics { get; set; }

        public int SelectedCount { get; set; }

        public List<ListModel> SongList { get; set; }
        //ItemImage AlbumImg = new ItemImage();

        public string ResultCount { get; set; } = "Result :";

        public ICommand SearchCommand { get; set; }

        public ICommand PutTextCommand { get; set; }

        public ListViewViewModel()
        {
            SearchCommand = new RelayParameterizedCommand(Search);
            PutTextCommand = new RelayParameterizedCommand(async (parameter) => await PutText(parameter));
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

        private async Task PutText(object parameter)
        {
            var file = TagLib.File.Create(SongList[SelectedCount].Path);
            var ComboBoxLyric = (string)parameter;
           

            file.Tag.Lyrics = (string)parameter;
            SongList[SelectedCount].Lyrics = (string)parameter;
            file.Save();
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
            List<ListModel> filesData = new();

            if(SongList != null)
            {
                filesData.AddRange(SongList);
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
            SelectedCount = (sender as ListView).SelectedIndex;
            TestTextLyrics = SongList[SelectedCount].Lyrics;
        }
            
        public void ComboSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var LYListCombo = sender as ComboBox;
            if (LyricSearchList.Count > 0)
            {
                LyricInfo LyricInfoSelected = Bus.GetLyricsFromID(LyricSearchList[LYListCombo.SelectedIndex].LyricID);
                
                TestTextLyrics = LyricInfoSelected.Lyric;
                if (LyricInfoSelected != null)
                {
                    
                    if (true)
                    {
                        string[] TimeRemove = LyricInfoSelected.Lyric.Split('\n');
                        TestTextLyrics = null;
                        foreach (string NewText in TimeRemove)
                        {
                            if (NewText.Length > 9)
                                TestTextLyrics += NewText.Substring(10) + "\n";
                        }
                    }
                    else TestTextLyrics = LyricInfoSelected.Lyric;
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
