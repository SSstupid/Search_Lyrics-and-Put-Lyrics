using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace TestListTemplate
{
    public class MainViewModel
    {
        public List<FileData> Files { get; set; }

        public MainViewModel()
        {
            List<FileData> fileDatas = new();
            fileDatas.Add(new FileData { FileName = "RefCount.txt", FullPath = @"C:\Program Files (x86)\Common Files" ,image1 = TestImageMetaData() });
            fileDatas.Add(new FileData { FileName = "Adobe Desktop Service.exe", FullPath = @"C:\Program Files (x86)\Common Files\Adobe\Adobe Desktop Common\ADS" });
            Files = fileDatas;
        }

        public BitmapImage TestImageMetaData()
        {
            //string filename = @"C:\Users\rlawo\Desktop\AllofMe.mp3";
            string filename = @"C:\Users\rlawo\Desktop\perfect-edsheran.mp3";

            TagLib.File tagFile = TagLib.File.Create(filename);

            if (tagFile.Tag.Pictures.Length < 1) // 여러 아이템 동시 추가시 Length 확인할 것
            {
                return null;
            }

            var imageSource = new BitmapImage();
            MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
            imageSource.BeginInit();
            imageSource.StreamSource = ms;
            imageSource.EndInit();

            return imageSource;
        }

        public System.Windows.Media.ImageSource getIcon()
        {
            string filename = @"C:\Users\rlawo\Desktop\TestImg.jpg";
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