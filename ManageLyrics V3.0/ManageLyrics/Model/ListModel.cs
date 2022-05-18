using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLyrics
{
    public class ListModel
    {
        public string files { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public System.Windows.Media.ImageSource WindowImages { get; set; }
    }
}