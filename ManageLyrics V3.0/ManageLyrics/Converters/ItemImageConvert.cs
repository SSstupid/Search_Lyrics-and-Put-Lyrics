using System.IO;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Data;
using System;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace ManageLyrics;

/// <summary>
/// A converter it get images from album and window icon
/// </summary>
public class ItemImageConvert : IValueConverter
{
    /// <summary>
    /// Singleton instance of the Converter
    /// </summary>
    public static ItemImageConvert Instance = new ItemImageConvert();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return GetItemImages($"{value}");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #region Function of Get Image

    /// <summary>
    /// Get listviewitem image
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public ImageSource GetItemImages(string filename)
    {
        ImageSource imageSource;

        try 
        { 
            TagLib.File tagFile = TagLib.File.Create(filename); 
            if (tagFile.Tag.Pictures.Length == 0) { imageSource = GetIcon(filename); }
            else { imageSource = GetAlbumImage(filename, tagFile); }
        }
        catch { imageSource = null; }   

        return imageSource;
    }

    /// <summary>
    /// Get window icon
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public ImageSource GetIcon(string filename)
    {
        ImageSource icon;

        // Returns an icon representation of an image that is contained in the specified file.
        // Icon need this "System.Drawing.Common" nuget-package
        using (Icon sysicon = Icon.ExtractAssociatedIcon(filename))
        {
            // Returns a managed BitmapSource, based on the provided pointer to an unmanaged icon image.
            // "CreateBitmapSourceFromHIcon" Method is from Windows Desktop
            icon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                        sysicon.Handle,
                        System.Windows.Int32Rect.Empty,
              BitmapSizeOptions.FromEmptyOptions());
        }
        return icon;
    }
    /// <summary>
    /// Get Image from album
    /// Get memory data from file than convert to bitmapimage
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="TagFile"></param>
    /// <returns></returns>
    public ImageSource GetAlbumImage(string filename, TagLib.File TagFile)
    {
        var BitImage = new BitmapImage();

        // Creates a stream whose backing store is memory.
        MemoryStream ms = new MemoryStream(TagFile.Tag.Pictures[0].Data.Data);
        BitImage.BeginInit();
        BitImage.StreamSource = ms;
        BitImage.EndInit();

        return BitImage;
    }

    #endregion
}