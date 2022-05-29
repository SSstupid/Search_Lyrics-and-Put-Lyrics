namespace ManageLyrics;

public class ListModel
{
    /// <summary>
    /// File path for save the lyric information
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// The display name of this listview list
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// The display artist of this listview list
    /// </summary>
    public string Artist { get; set; }

    /// <summary>
    /// The display title of this listview list
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The display lyrics of this listview list
    /// </summary>
    public string Lyrics { get; set; }

    /// <summary>
    /// The display artist of textbox text
    /// </summary>
    public string? TextBoxArtist { get; set; }

    /// <summary>
    /// The display title of textbox text
    /// </summary>
    public string? TextBoxTitle { get; set; }

    // public System.Windows.Media.ImageSource WindowImages { get; set; }
}