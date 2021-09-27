using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JLyrics;
using System.Threading;
using System.IO;
using System.Web;


namespace Https_Lyrics
{
    public partial class Form1 : Form
    {
        private Lyrics fJL = new Lyrics();
        private List<LyricBasicInfo> fLyricSearchInfoList;
        public Form1()
        {
            InitializeComponent();      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CBList.Items.Clear(); //콤보박스
            this.CBList.Text = "";
            this.LyCount.Text = "검색 갯수 : ";  // 검색수 라벨
            this.TitLa.Text = "Title : ";
            this.ArtLa.Text = "Artist : ";
            this.textBox3.Clear();  //가사보는 곳
            //fLyricSearchInfoList 클래스 리스트
            fLyricSearchInfoList = fJL.GetLyricsSearch(this.ArText.Text, this.TiText.Text);// 가수와노래 검색어
            if (fLyricSearchInfoList != null)
            {
                LyCount.Text = "검색 갯수 : " + Convert.ToString(fLyricSearchInfoList.Count);
                for (int i = 0; i < fLyricSearchInfoList.Count; i++)
                {
                    this.CBList.Items.Add(fLyricSearchInfoList[i].Title + "-" + fLyricSearchInfoList[i].Artist + "[" + fLyricSearchInfoList[i].Album + "]");
                }
            }
            else
            {
                LyCount.Text = "검색 갯수 : 0";
            }
        }

        private void CBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fLyricSearchInfoList != null)
            {
                if (fLyricSearchInfoList.Count > 0)
                {
                    LyricInfo xLyricInfo = fJL.GetLyricsFromID(fLyricSearchInfoList[CBList.SelectedIndex].LyricID);
                    if (xLyricInfo != null)
                    {
                        this.TitLa.Text = "Title : " + xLyricInfo.Title;
                        this.ArtLa.Text = "Artist : " + xLyricInfo.Artist;
                        this.textBox3.Text = xLyricInfo.Lyric; // 가사창
                    }

                }
            }
        }
    }
}
