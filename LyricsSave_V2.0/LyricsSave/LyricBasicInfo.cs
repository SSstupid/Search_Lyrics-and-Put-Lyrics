using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsSave
{
    public class LyricBasicInfo
    {
        public int LyricID;
        public string Title;
        public string Artist;
        public string Album;
    }
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
}
