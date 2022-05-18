using System.Collections.Generic;

namespace TestListTemplate
{
    public class MainViewModel
    {
        public List<FileData> Files { get; set; }
        public string Name { get; set; } = "james";


        public MainViewModel()
        {
            List<FileData> fileDatas = new();
            fileDatas.Add(new FileData { FileName = "RefCount.txt", FullPath = @"C:\Program Files (x86)\Common Files" ,ff = getIcon() });
            fileDatas.Add(new FileData { FileName = "Adobe Desktop Service.exe", FullPath = @"C:\Program Files (x86)\Common Files\Adobe\Adobe Desktop Common\ADS" });
            Files = fileDatas;
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