using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace ManageLyrics
{
    public class ListViewViewModel : BaseViewModel
    {
        public List<ListModel> SongList { get; set; }
        //ItemImage AlbumImg = new ItemImage();

        public ICommand SearchCommand { get; set; }

        public List<LyricBasicInfo> LyricSearchList { get; set; }

        ALSongLyric Bus = new ALSongLyric();

        public ListViewViewModel()
        {
            SearchCommand = new RelayParameterizedCommand(async (parameter) => await Search(parameter));
            List<LyricBasicInfo> lyricBasicInfos = new ();
            lyricBasicInfos.Add(new LyricBasicInfo() { Title = "df ", Album= "d " , Artist = "dd ", LyricID = 4,});
            LyricSearchList = lyricBasicInfos;
        }

        private async Task Search(object parameter)
        {
            var values = (object[])parameter;
            var SearchArtist = (string)values[0];
            var SearchTitle = (string)values[1];

            SearchLyrics(SearchArtist, SearchTitle);
            /* var A = parameter.ToString();
             int FirstIndex = A.IndexOf(' ');

             MessageBox.Show(A.Substring(FirstIndex + 1));*/
        }
        
        
        public void ListDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

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
                var SongFile = TagLib.File.Create(fileName);
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
            SongList = filesData;
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

        public void SearchLyrics(string Artist, string Title)
        {
            List<LyricBasicInfo> lyricBasicInfos = new List<LyricBasicInfo>();
            try
            {
                if (!(String.IsNullOrWhiteSpace(Artist) && String.IsNullOrWhiteSpace(Title)))
                {
                    /*LyLIstCombo.Items.Clear();
                    LyLIstCombo.Text = "";*/

                    // TitleLa.Text = "Title : ";
                    // ArtistLa.Text = "Artist : ";
                    // LyricsText.Clear();  //가사보는 곳
                    //fLyricSearchInfoList 클래스 리스트
                    lyricBasicInfos = Bus.GetLyricsSearch(Artist, Title);
                    if (LyricSearchList != null)
                    {
                       // label4.Text = "Result :" + Convert.ToString(LyricSearchList.Count);
                        for (int i = 0; i < LyricSearchList.Count; i++)
                        {
                           // LyLIstCombo.Items.Add(LyricSearchList[i].Title + "-" + LyricSearchList[i].Artist + "[" + LyricSearchList[i].Album + "]");
                        }
                        LyricSearchList = lyricBasicInfos;
                    }
                    else
                    {
                        MessageBox.Show("no results.");
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
