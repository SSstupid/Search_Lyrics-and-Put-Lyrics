namespace ManageLyrics;

public class LyricBasicInfo
{
    public int LyricID { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }

}
#region No using this code

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

#endregion