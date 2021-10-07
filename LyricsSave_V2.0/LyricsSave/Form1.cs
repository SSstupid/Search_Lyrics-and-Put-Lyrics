using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.IO;


namespace LyricsSave
{
    public partial class Form1 : Form
    {
        ListViewFunction List = new ListViewFunction();
        List<LyricBasicInfo> LyricSearchList;
        ALSongLyric Bus = new ALSongLyric();
        static string LyMemory;

        public Form1()
        {
            InitializeComponent();

            panel1.Dock = DockStyle.Left;
            List.ListViewSet(SongView);
        }

        #region SearchLyrics()
        public void SearchLyrics()
        {
            try
            {
                if (!(String.IsNullOrWhiteSpace(ArtistText.Text) && String.IsNullOrWhiteSpace(TitleText.Text)))
                {
                    LyLIstCombo.Items.Clear();
                    LyLIstCombo.Text = "";
                    TitleLa.Text = "Title : ";
                    ArtistLa.Text = "Artist : ";
                    LyricsText.Clear();  //가사보는 곳
                                         //fLyricSearchInfoList 클래스 리스트
                    LyricSearchList = Bus.GetLyricsSearch(ArtistText.Text, TitleText.Text);
                    if (LyricSearchList != null)
                    {
                        label4.Text = "Result :" + Convert.ToString(LyricSearchList.Count);
                        for (int i = 0; i < LyricSearchList.Count; i++)
                        {
                            LyLIstCombo.Items.Add(LyricSearchList[i].Title + "-" + LyricSearchList[i].Artist + "[" + LyricSearchList[i].Album + "]");
                        }
                    }
                    else
                    {
                        MessageBox.Show("no results.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the artist and the title.");
                }
            }
            catch
            {
                MessageBox.Show("failed: Check it again and try it.");
            }
        }
        #endregion

        #region Drag and Drop__ListviewAdd & Icon(Song, Lyrics)
        private void listView_DragEnter(object sender, DragEventArgs e)
        {
             e.Effect = DragDropEffects.Copy;
        }

        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var ListView = sender as ListView;
            List.GetFileInfo_Icon(files, ListView);     //ShowIcon
            
        }
        #endregion

        private void LyricsPutIn(string SongPath)
        {
                var file = TagLib.File.Create(SongPath);
                String Lyrics = LyricsText.Text;
                file.Tag.Lyrics = Lyrics;
                file.Save();
        }

        private void SearchB_Click(object sender, EventArgs e)
        {
            SearchLyrics();
        }

        private void SerachSong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                SearchLyrics();
        }

        private void SaveB_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(LyricsText.Text))
            {
                MessageBox.Show("There are no lyrics to save.");
                return;
            }
            else if (String.IsNullOrWhiteSpace(DownloadPath.Text) || DownloadPath.Text == "Please select a path")
            {
                string FindUser = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
                DownloadPath.Text = (FindUser + @"\Downloads");
            }
           
            string x = DownloadPath.Text + @"\" + ArtistText.Text + TitleText.Text + ".txt";
            File.WriteAllText(x, LyricsText.Text);
        }

        private void Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            DownloadPath.Text = dialog.SelectedPath;
        }

        private void PutLyrics(object sender, EventArgs e)
        {
            if(SongView.SelectedIndices.Count > 0)
            {
                LyricsPutIn(SongView.Items[SongView.FocusedItem.Index].SubItems[0].Text);
            }
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteLy();
        }

        public void DeleteLy()  //it will jump to ListViewFuntion-class
        {
            if (SongView.SelectedItems.Count > 0)
            {
                for (int i = SongView.SelectedItems.Count - 1; i >= 0; i--)
                {
                    SongView.SelectedItems[i].Remove();
                }
                SongView.Update();
            }
        }

        private void SongView_Click(object sender, EventArgs e)
        {
            if (SongView.SelectedItems.Count > 0) 
            {
                string SongPath = SongView.SelectedItems[0].SubItems[0].Text;
                if (System.IO.Path.GetExtension(SongPath) == ".mp3") 
                {
                    var file = TagLib.File.Create(SongPath);
                    ArtistText.Text = (file.Tag.FirstPerformer);
                    TitleText.Text = (file.Tag.Title);
                }
            }
        }

        private void listView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
            }
            else this.Cursor = Cursors.Default;
        }

        private void listView_MouseUp(object sender, MouseEventArgs e) 
        {
            var listView = sender as ListView;
            List.ListItemMove(listView, e);
        }

        private void LyLIstCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LyricsText.Clear();
            if (LyricSearchList.Count > 0)
            {
                LyricInfo LyricInfoSelected = Bus.GetLyricsFromID(LyricSearchList[LyLIstCombo.SelectedIndex].LyricID);
                LyMemory = LyricInfoSelected.Lyric;
                if (LyricInfoSelected != null)
                {
                    TitleLa.Text = "Title : " + LyricInfoSelected.Title;
                    ArtistLa.Text = "Artist : " + LyricInfoSelected.Artist;

                    if(CheckBox1.Checked == true)
                    { 
                        string[] TimeRemove = LyricInfoSelected.Lyric.Split('\n');
                        foreach (string a1 in TimeRemove)
                        {
                            if (a1.Length > 9)
                                LyricsText.Text += a1.Substring(10) + "\n";
                        }
                    }
                    else LyricsText.Text = LyricInfoSelected.Lyric;
                }
            }
        }

        private void Contact_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true && !(String.IsNullOrWhiteSpace(LyricsText.Text)))
            {
                LyricsText.Clear();
                string[] TimeRemove = LyMemory.Split('\n');
                foreach (string Text in TimeRemove)
                {
                    if (Text.Length > 9)
                        LyricsText.Text += Text.Substring(10) + "\n";
                }
            }
            else if(CheckBox1.Checked == false && !(String.IsNullOrWhiteSpace(LyricsText.Text)))
            {
                LyricsText.Text = LyMemory;
            }
        }

        private void SongView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
                DeleteLy();
        }
    }
}