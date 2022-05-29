namespace ManageLyrics;

/// <summary>
/// List information for request lyric detail
/// </summary>
public class LyricBasicInfo
{
    public int LyricID { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }

}

/// <summary>
/// lyric detail properties
/// </summary>
public class LyricInfo : LyricBasicInfo
{
    public int StatusID;
    public string RegistDate;
    public string Lyric;
    public string RegisterName;
    public string RegisterMail;
    public string RegisterHomeURL;
    public string RegisterPhone;
    public string RegisterComment;
    public string ModifierName;
    public string ModifierMail;
    public string ModifierHomeURL;
    public string ModifierPhone;
    public string ModifierComment;
}