namespace LyricsSave
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ArtistText = new System.Windows.Forms.TextBox();
            this.SearchB = new System.Windows.Forms.Button();
            this.LyricsText = new System.Windows.Forms.TextBox();
            this.SaveB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SongView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TitleLa = new System.Windows.Forms.Label();
            this.ArtistLa = new System.Windows.Forms.Label();
            this.LyLIstCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleText = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ContactStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArtistText
            // 
            this.ArtistText.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ArtistText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistText.Location = new System.Drawing.Point(59, 20);
            this.ArtistText.Name = "ArtistText";
            this.ArtistText.Size = new System.Drawing.Size(132, 24);
            this.ArtistText.TabIndex = 0;
            this.ArtistText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SerachSong_KeyDown);
            // 
            // SearchB
            // 
            this.SearchB.Location = new System.Drawing.Point(409, 20);
            this.SearchB.Name = "SearchB";
            this.SearchB.Size = new System.Drawing.Size(89, 24);
            this.SearchB.TabIndex = 2;
            this.SearchB.Text = "Search";
            this.SearchB.UseVisualStyleBackColor = true;
            this.SearchB.Click += new System.EventHandler(this.SearchB_Click);
            // 
            // LyricsText
            // 
            this.LyricsText.BackColor = System.Drawing.SystemColors.HighlightText;
            this.LyricsText.Location = new System.Drawing.Point(508, 101);
            this.LyricsText.Multiline = true;
            this.LyricsText.Name = "LyricsText";
            this.LyricsText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LyricsText.Size = new System.Drawing.Size(405, 317);
            this.LyricsText.TabIndex = 6;
            // 
            // SaveB
            // 
            this.SaveB.Location = new System.Drawing.Point(274, 378);
            this.SaveB.Name = "SaveB";
            this.SaveB.Size = new System.Drawing.Size(89, 35);
            this.SaveB.TabIndex = 3;
            this.SaveB.Text = "Save";
            this.SaveB.UseVisualStyleBackColor = true;
            this.SaveB.Click += new System.EventHandler(this.SaveB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path";
            // 
            // DownloadPath
            // 
            this.DownloadPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadPath.Location = new System.Drawing.Point(11, 64);
            this.DownloadPath.Multiline = true;
            this.DownloadPath.Name = "DownloadPath";
            this.DownloadPath.Size = new System.Drawing.Size(315, 33);
            this.DownloadPath.TabIndex = 5;
            this.DownloadPath.Text = "Please select a path";
            this.DownloadPath.Click += new System.EventHandler(this.Path_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(824, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "PutLyrics";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.PutLyrics);
            // 
            // SongView
            // 
            this.SongView.AllowDrop = true;
            this.SongView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.SongView.HideSelection = false;
            this.SongView.Location = new System.Drawing.Point(11, 101);
            this.SongView.Name = "SongView";
            this.SongView.Size = new System.Drawing.Size(487, 261);
            this.SongView.TabIndex = 7;
            this.SongView.UseCompatibleStateImageBehavior = false;
            this.SongView.Click += new System.EventHandler(this.SongView_Click);
            this.SongView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.SongView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.SongView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SongView_KeyDown);
            this.SongView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView_MouseMove);
            this.SongView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Music Name";
            this.columnHeader1.Width = 300;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(141, 378);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(89, 35);
            this.Delete.TabIndex = 9;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CheckBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.TitleLa);
            this.panel1.Controls.Add(this.ArtistLa);
            this.panel1.Controls.Add(this.LyLIstCombo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TitleText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LyricsText);
            this.panel1.Controls.Add(this.SongView);
            this.panel1.Controls.Add(this.SaveB);
            this.panel1.Controls.Add(this.SearchB);
            this.panel1.Controls.Add(this.ArtistText);
            this.panel1.Controls.Add(this.DownloadPath);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 428);
            this.panel1.TabIndex = 10;
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(510, 65);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(117, 21);
            this.CheckBox1.TabIndex = 15;
            this.CheckBox1.Text = "Remove Time";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Result";
            // 
            // TitleLa
            // 
            this.TitleLa.AutoSize = true;
            this.TitleLa.Location = new System.Drawing.Point(791, 65);
            this.TitleLa.Name = "TitleLa";
            this.TitleLa.Size = new System.Drawing.Size(43, 17);
            this.TitleLa.TabIndex = 13;
            this.TitleLa.Text = "Tilte :";
            // 
            // ArtistLa
            // 
            this.ArtistLa.AutoSize = true;
            this.ArtistLa.Location = new System.Drawing.Point(659, 65);
            this.ArtistLa.Name = "ArtistLa";
            this.ArtistLa.Size = new System.Drawing.Size(48, 17);
            this.ArtistLa.TabIndex = 12;
            this.ArtistLa.Text = "Artist :";
            // 
            // LyLIstCombo
            // 
            this.LyLIstCombo.FormattingEnabled = true;
            this.LyLIstCombo.Location = new System.Drawing.Point(508, 20);
            this.LyLIstCombo.Name = "LyLIstCombo";
            this.LyLIstCombo.Size = new System.Drawing.Size(310, 24);
            this.LyLIstCombo.TabIndex = 3;
            this.LyLIstCombo.SelectedIndexChanged += new System.EventHandler(this.LyLIstCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Artist";
            // 
            // TitleText
            // 
            this.TitleText.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.TitleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleText.Location = new System.Drawing.Point(241, 20);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(162, 24);
            this.TitleText.TabIndex = 1;
            this.TitleText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SerachSong_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContactStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(937, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ContactStripMenuItem
            // 
            this.ContactStripMenuItem.Name = "ContactStripMenuItem";
            this.ContactStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.ContactStripMenuItem.Text = "Contact";
            this.ContactStripMenuItem.Click += new System.EventHandler(this.Contact_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SSstupid_LyricsManager";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ArtistText;
        private System.Windows.Forms.Button SearchB;
        private System.Windows.Forms.Button SaveB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DownloadPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView SongView;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ContactStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TitleText;
        private System.Windows.Forms.ComboBox LyLIstCombo;
        private System.Windows.Forms.Label TitleLa;
        private System.Windows.Forms.Label ArtistLa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CheckBox1;
        private System.Windows.Forms.TextBox LyricsText;
    }
}

