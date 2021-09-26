using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
//using ListViewTool;

namespace LyricsSave
{
    public partial class Form1 : Form
    {
        //ListViewTool.ListViewFunction abc = new ListViewTool.ListViewFunction();// Lib
        ListViewFunction List = new ListViewFunction();
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(535, 395);
            panel1.Dock = DockStyle.Left;
            panel1.Show();
            Delete.Hide();
            button1.Hide();
            LyricsView.Hide();

            List.ListViewSet(SongView);
            List.ListViewSet(LyricsView);
        }

        #region SearchLyrics()
        public void SearchLyrics()
        {
            try
            {
                if (!(String.IsNullOrWhiteSpace(SerachSong.Text) || SerachSong.Text == "Please enter a search term."))
                {
                    //using (IWebDriver driver = new ChromeDriver()) // 심각한 속도저하....
                    IWebDriver driver = new ChromeDriver();
                    driver.Url = "https://google.co.kr";
                    driver.Manage().Window.Maximize();

                    Thread.Sleep(300);
                    driver.FindElement(By.Name("q")).SendKeys(SerachSong.Text + " Lyrics");

                    Thread.Sleep(300);
                    driver.FindElement(By.Name("btnK")).Click();
                    Thread.Sleep(400);
                    driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div[1]/div/div[2]/div/div/div/div/div/div[2]/div[2]/div/g-raised-button/div")).Click();

                    Thread.Sleep(300);
                    var FIndLyrics = driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div[1]/div/div[2]/div/div/div/div/div"));
                    LyricsText.Text = FIndLyrics.Text;

                    Thread.Sleep(100);
                    driver.Close();
                    driver.Quit();
                }
                else
                {
                    MessageBox.Show("Please enter the music.");
                }
            }
            catch (Exception ex)
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

        private void LyricsPutIn(string SongPath, string LyricsPath)
        {
            try
            {
                using (var file = TagLib.File.Create(SongPath))
                { 
                    String Lyrics = System.IO.File.ReadAllText(LyricsPath);
                    file.Tag.Lyrics = Lyrics;
                    file.Save();
                }
            }
            catch (Exception e) { }
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
            else if (String.IsNullOrWhiteSpace(Path.Text) || Path.Text == "Please select a path")
            {
                string FindUser = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
                Path.Text = (FindUser + @"\Downloads");
            }
           
            string x = Path.Text + @"\" + SerachSong.Text + ".txt";
            File.WriteAllText(x, LyricsText.Text);
        }

        private void SerachSong_Click(object sender, EventArgs e)
        {
            if (SerachSong.Text == "Please enter a search term.")
                SerachSong.Text = null;
        }

        private void Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            Path.Text = dialog.SelectedPath;
        }

        private void PutLyrics(object sender, EventArgs e)
        {
            int i = 0;
            foreach (ListViewItem item1 in SongView.Items)
            {
                ListViewItem item2 = LyricsView.Items[i];
                LyricsPutIn(item1.SubItems[0].Text, item2.SubItems[0].Text);
                i++;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (SongView.SelectedItems.Count > 0)
            {
                for (int i = SongView.SelectedItems.Count - 1; i >= 0; i--) 
                {
                    SongView.SelectedItems[i].Remove();
                }
                SongView.Update();
            }
            else if(LyricsView.SelectedItems.Count > 0)
            {
                for (int i = LyricsView.SelectedItems.Count - 1; i >= 0; i--)
                {
                    LyricsView.SelectedItems[0].Remove();
                }
                LyricsView.Update();
            }
        }

        private void SongView_Click(object sender, EventArgs e)
        {
            if (LyricsView.SelectedItems.Count > 0)
            {
                LyricsView.SelectedIndices.Clear();
            }
            if (SongView.SelectedItems.Count > 0) 
            { 
                var file = TagLib.File.Create(SongView.SelectedItems[0].SubItems[0].Text);
                SerachSong.Text = (file.Tag.Title + " " + file.Tag.FirstPerformer);
            }
        }

        private void LyricsView_Click(object sender, EventArgs e)
        {
            if(SongView.SelectedItems.Count > 0)
            {
                SongView.SelectedIndices.Clear();
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
        private void searchLyricsToolStripMenuItem_Click(object sender, EventArgs e) //need to improve the design.
        {
            Path.Show();
            SearchB.Show();
            label1.Show();
            SaveB.Show();
            Delete.Hide();
            button1.Hide();
            LyricsText.Show();
            LyricsView.Hide();
        }

        private void putLyricsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Path.Hide();
            SearchB.Hide();
            label1.Hide();
            SaveB.Hide();
            Delete.Show();
            button1.Show();
            LyricsText.Hide();
            LyricsView.Show();
        }
    }
}