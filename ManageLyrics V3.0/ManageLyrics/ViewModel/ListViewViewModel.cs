using System.Collections.Generic;
using System.Windows;
namespace ManageLyrics
{
    public class ListViewViewModel : BaseViewModel
    {
        public List<ListModel> SongList { get; set; }
        //ItemImage AlbumImg = new ItemImage();
        

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
                    FileName = GetFileFolderName(fileName), 
                    Artist = SongFile.Tag.FirstPerformer ?? "NoArtist", 
                    Title = SongFile.Tag.Title ?? "NoTitle", 
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
        public static string GetFileFolderName(string path)
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
}
