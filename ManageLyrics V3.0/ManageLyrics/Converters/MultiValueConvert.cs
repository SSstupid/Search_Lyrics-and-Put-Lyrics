using System;
using System.Globalization;
using System.Windows.Data;

namespace ManageLyrics;

/// <summary>
/// A converter gets multi-binding property
/// </summary>
public class MultiValueConvert : IMultiValueConverter
{
    /// <summary>
    /// Singleton instance of the converter
    /// </summary>
    public static MultiValueConvert Instance = new MultiValueConvert();
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values.Clone();
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}