using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace LyricsSave
{
    public partial class Form1 : Form
    {
        //IWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan 탐색시 object가 없으면 대기하는 시간.

        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(520, 300);
            panel1.Dock = DockStyle.Left;
            panel2.Dock = DockStyle.Left;
            panel1.Show();
            panel2.Hide();

            #region ShowIcon
            //prepare listview
            SongView.View = View.Details;
            SongView.Columns.Add("File name", 300); 
            LyricsView.View = View.Details;
            LyricsView.Columns.Add("File name", 300);
            // get the handle to the system image list
            NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();
            IntPtr hSysImgLst = NativeMethods.SHGetFileInfo("",
                                                            0,
                                                            ref shfi,
                                                            (uint)Marshal.SizeOf(shfi),
                                                            NativeMethods.SHGFI_SYSICONINDEX |
                                                            NativeMethods.SHGFI_SMALLICON);
            // send a message to ListView with handle to system image list
            NativeMethods.SendMessage(SongView.Handle,
                                      NativeMethods.LVM_SETIMAGELIST,
                                      NativeMethods.LVSIL_SMALL,
                                      hSysImgLst);

            NativeMethods.SendMessage(LyricsView.Handle,
                                      NativeMethods.LVM_SETIMAGELIST,
                                      NativeMethods.LVSIL_SMALL,
                                      hSysImgLst);
            #endregion
        }


        #region SearchLyrics()
        public void SearchLyrics()
        {
            if (String.IsNullOrWhiteSpace(SerachSong.Text) || SerachSong.Text == "Please enter a search term.")
            {
                MessageBox.Show("Please enter the music.");
            }
            else
            {
               /* ChromeOptions options = new ChromeOptions();
                options.AddArgument("headless");*/      //Chrom창 숨길시 에러발생

                IWebDriver driver = new ChromeDriver();

                /*var driverService = ChromeDriverService.CreateDefaultService(); //콘솔 숨기기
                driverService.HideCommandPromptWindow = true;

                var driver = new ChromeDriver(driverService, new ChromeOptions());*/

                driver.Url = "https://google.co.kr";
                driver.Manage().Window.Maximize();

                Thread.Sleep(300);
                driver.FindElement(By.Name("q")).SendKeys(SerachSong.Text + " Lyrics");

                Thread.Sleep(300);
                driver.FindElement(By.Name("btnK")).Click();
                Thread.Sleep(400);
                driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div[1]/div/div[2]/div/div/div/div/div/div[2]/div[2]/div/g-raised-button/div")).Click();

                Thread.Sleep(300);
                // if(driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div[1]/div/div[2]/div/div/div/div/div")) == true)
                var FIndLyrics = driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div[1]/div/div[2]/div/div/div/div/div"));
                LyricsText.Text = FIndLyrics.Text;

                Thread.Sleep(100);
                driver.Close();
                driver.Quit();
            }
        }
        #endregion

        #region Drag and Drop(Song, Lyrics)
        private void listView2_DragEnter(object sender, DragEventArgs e) // 드래그 앤 드랍 가능
        {
             e.Effect = DragDropEffects.Copy;
        }

        private void Lyrics_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string fileName in files)
            {
                NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();
                NativeMethods.SHGetFileInfo(fileName,
                                            0,
                                            ref shfi,
                                            (uint)Marshal.SizeOf(shfi),
                                            NativeMethods.SHGFI_SHGFI_ICON |
                                            NativeMethods.SHGFI_SHGFI_OVERLAYINDEX);
                //destroy icon object
                NativeMethods.DestroyIcon(shfi.hIcon);
                // insert item in ListView with filename and icon index
                ListViewItem it = LyricsView.Items.Add(fileName, shfi.iIcon & 0xFFFF);
                if (it != null)
                {
                    //prepare the LVITEM parameter
                    NativeMethods.LVITEM lvi = new NativeMethods.LVITEM();
                    lvi.iItem = it.Index;
                    lvi.stateMask = NativeMethods.LVIS_OVERLAYMASK;
                    uint overlayIndex = (uint)(shfi.iIcon & 0x0F000000) >> 24;
                    lvi.state = NativeMethods.INDEXTOOVERLAYMASK(overlayIndex);
                    //send the LVM_SETITEMSTATE message to enable overlay
                    NativeMethods.SendMessage(LyricsView.Handle,
                              NativeMethods.LVM_SETITEMSTATE,
                              (uint)it.Index,
                              ref lvi);
                }
            }
        }

        private void SongView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //foreach (string file in files) LyricsView.Items.Add(file);
            foreach (string fileName in files)
            {
                NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();
                NativeMethods.SHGetFileInfo(fileName,
                                            0,
                                            ref shfi,
                                            (uint)Marshal.SizeOf(shfi),
                                            NativeMethods.SHGFI_SHGFI_ICON |
                                            NativeMethods.SHGFI_SHGFI_OVERLAYINDEX);
                //destroy icon object
                NativeMethods.DestroyIcon(shfi.hIcon);
                // insert item in ListView with filename and icon index
                ListViewItem it = SongView.Items.Add(fileName, shfi.iIcon & 0xFFFF);
                if (it != null)
                {
                    //prepare the LVITEM parameter
                    NativeMethods.LVITEM lvi = new NativeMethods.LVITEM();
                    lvi.iItem = it.Index;
                    lvi.stateMask = NativeMethods.LVIS_OVERLAYMASK;
                    uint overlayIndex = (uint)(shfi.iIcon & 0x0F000000) >> 24;
                    lvi.state = NativeMethods.INDEXTOOVERLAYMASK(overlayIndex);
                    //send the LVM_SETITEMSTATE message to enable overlay
                    NativeMethods.SendMessage(SongView.Handle,
                              NativeMethods.LVM_SETITEMSTATE,
                              (uint)it.Index,
                              ref lvi);
                }
            }
        }
        #endregion

        private void PutLyrics(string SongPath, string LyricsPath)
        {
            var file = TagLib.File.Create(SongPath); // Change file path accordingly.

            String Lyrics = System.IO.File.ReadAllText(LyricsPath);
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
            if (String.IsNullOrWhiteSpace(Path.Text) || Path.Text == "Please select a path")     // 예외처리 - 저장경로
                Path.Text = (@"C:\Users\rlawo\Downloads");
            if(String.IsNullOrWhiteSpace(LyricsText.Text))      // 텍스트 예외처리
            {
                MessageBox.Show("There are no lyrics to save.");
                return;
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
                PutLyrics(item1.SubItems[0].Text, item2.SubItems[0].Text);
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
        }

        private void LyricsView_Click(object sender, EventArgs e)
        {
            if(SongView.SelectedItems.Count > 0)
            {
                SongView.SelectedIndices.Clear();
            }
        }

        private void SongView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll; //이동중 마우스 커서 십자가로 변환
            }
        }

        private void SongView_MouseUp(object sender, MouseEventArgs e) // 클래스로 사용 할 수 없읍을까....
        {                                                              //Listview 이름만 바꾸면 되는데 ;;
            bool bSamePosition = false;
            int i = 0;
            this.Cursor = Cursors.Arrow;
            ListViewItem selected = this.SongView.GetItemAt(e.X, e.Y);
            if (null != selected)
            {
                //if (SongView.SelectedItems[0].Index == 0) i = 1;
                foreach (ListViewItem l in SongView.SelectedItems)
                {
                    if (l.Index == selected.Index)
                    {
                        bSamePosition = true;
                        break;
                    }
                }
                if (!bSamePosition)
                {
                    foreach (ListViewItem l in SongView.SelectedItems)
                    {
                        if (l.Index == 0) i = 1;                    //맨밑으로 이동 불가능해서 추가
                        l.Remove();                                 //깔금한 코드가 없을까...
                        SongView.Items.Insert(selected.Index + i, l);
                    }
                }
            }
        }

        private void LyricsView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll; //이동중 마우스 커서 십자가로 변환
            }
        }

        private void LyricsView_MouseUp(object sender, MouseEventArgs e)
        {
            int i = 0;
            bool bSamePosition = false;
            this.Cursor = Cursors.Arrow;
            ListViewItem selected = this.LyricsView.GetItemAt(e.X, e.Y);
            if (null != selected)
            {
                foreach (ListViewItem l in LyricsView.SelectedItems)
                {
                    if (l.Index == selected.Index)
                    {
                        bSamePosition = true;
                        break;
                    }
                }
                if (!bSamePosition)
                {
                    foreach (ListViewItem l in LyricsView.SelectedItems)
                    {
                        if (l.Index == 0) i = 1;
                        l.Remove();
                        LyricsView.Items.Insert(selected.Index + i, l);
                    }
                }
            }
        }

        private void searchLyricsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
        }

        private void putLyricsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
        }
    }
}
