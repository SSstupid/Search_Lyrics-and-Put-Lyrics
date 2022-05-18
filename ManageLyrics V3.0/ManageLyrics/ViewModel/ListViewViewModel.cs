using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ManageLyrics
{
    public class ListViewViewModel : BaseViewModel
    {
        public List<ListModel> SongList { get; set; }

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
                filesData.Add(new ListModel() { files = fileName, Artist = SongFile.Tag.FirstPerformer, WindowImages = TestImageMetaData(fileName) });
            }
            SongList = filesData;
        }

        public ImageSource TestImageMetaData(string filename)
        {
            TagLib.File tagFile = TagLib.File.Create(filename);
            ImageSource imageSource;

            if (tagFile.Tag.Pictures.Length == 0) // 여러 아이템 동시 추가시 Length 확인할 것
            {
                imageSource = getIcon(filename);
            }
            else
            {
                var imageBit= new BitmapImage();

                MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                imageBit.BeginInit();
                imageBit.StreamSource = ms;
                imageBit.EndInit();

                imageSource = imageBit;
            }
            return imageSource;
        }

        public ImageSource getIcon(string filename)
        {
            System.Windows.Media.ImageSource icon;
            using (System.Drawing.Icon sysicon = System.Drawing.Icon.ExtractAssociatedIcon(filename))
            {
                icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                            sysicon.Handle,
                            System.Windows.Int32Rect.Empty,
                            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            }
            return icon;
        }
    }
}
