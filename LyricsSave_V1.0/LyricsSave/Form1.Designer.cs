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
            this.SerachSong = new System.Windows.Forms.TextBox();
            this.SearchB = new System.Windows.Forms.Button();
            this.LyricsText = new System.Windows.Forms.TextBox();
            this.SaveB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SongView = new System.Windows.Forms.ListView();
            this.LyricsView = new System.Windows.Forms.ListView();
            this.Delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.searchLyricsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putLyricsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SerachSong
            // 
            this.SerachSong.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.SerachSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerachSong.Location = new System.Drawing.Point(12, 31);
            this.SerachSong.Multiline = true;
            this.SerachSong.Name = "SerachSong";
            this.SerachSong.Size = new System.Drawing.Size(292, 34);
            this.SerachSong.TabIndex = 0;
            this.SerachSong.Text = "Please enter a search term.";
            this.SerachSong.Click += new System.EventHandler(this.SerachSong_Click);
            this.SerachSong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SerachSong_KeyDown);
            // 
            // SearchB
            // 
            this.SearchB.Location = new System.Drawing.Point(43, 261);
            this.SearchB.Name = "SearchB";
            this.SearchB.Size = new System.Drawing.Size(89, 35);
            this.SearchB.TabIndex = 1;
            this.SearchB.Text = "Search";
            this.SearchB.UseVisualStyleBackColor = true;
            this.SearchB.Click += new System.EventHandler(this.SearchB_Click);
            // 
            // LyricsText
            // 
            this.LyricsText.BackColor = System.Drawing.SystemColors.HighlightText;
            this.LyricsText.Location = new System.Drawing.Point(329, 12);
            this.LyricsText.Multiline = true;
            this.LyricsText.Name = "LyricsText";
            this.LyricsText.ReadOnly = true;
            this.LyricsText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LyricsText.Size = new System.Drawing.Size(346, 312);
            this.LyricsText.TabIndex = 2;
            // 
            // SaveB
            // 
            this.SaveB.Location = new System.Drawing.Point(165, 261);
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
            this.label1.Location = new System.Drawing.Point(9, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path";
            // 
            // Path
            // 
            this.Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Path.Location = new System.Drawing.Point(9, 109);
            this.Path.Multiline = true;
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(295, 33);
            this.Path.TabIndex = 5;
            this.Path.Text = "Please select a path";
            this.Path.Click += new System.EventHandler(this.Path_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "PutLyrics";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.PutLyrics);
            // 
            // SongView
            // 
            this.SongView.AllowDrop = true;
            this.SongView.HideSelection = false;
            this.SongView.Location = new System.Drawing.Point(23, 6);
            this.SongView.Name = "SongView";
            this.SongView.Size = new System.Drawing.Size(305, 271);
            this.SongView.TabIndex = 7;
            this.SongView.UseCompatibleStateImageBehavior = false;
            this.SongView.Click += new System.EventHandler(this.SongView_Click);
            this.SongView.DragDrop += new System.Windows.Forms.DragEventHandler(this.SongView_DragDrop);
            this.SongView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView2_DragEnter);
            this.SongView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SongView_MouseMove);
            this.SongView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SongView_MouseUp);
            // 
            // LyricsView
            // 
            this.LyricsView.AllowDrop = true;
            this.LyricsView.HideSelection = false;
            this.LyricsView.Location = new System.Drawing.Point(350, 6);
            this.LyricsView.Name = "LyricsView";
            this.LyricsView.Size = new System.Drawing.Size(326, 271);
            this.LyricsView.TabIndex = 8;
            this.LyricsView.UseCompatibleStateImageBehavior = false;
            this.LyricsView.Click += new System.EventHandler(this.LyricsView_Click);
            this.LyricsView.DragDrop += new System.Windows.Forms.DragEventHandler(this.Lyrics_DragDrop);
            this.LyricsView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView2_DragEnter);
            this.LyricsView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LyricsView_MouseMove);
            this.LyricsView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LyricsView_MouseUp);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(111, 293);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(89, 35);
            this.Delete.TabIndex = 9;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Path);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SaveB);
            this.panel1.Controls.Add(this.LyricsText);
            this.panel1.Controls.Add(this.SearchB);
            this.panel1.Controls.Add(this.SerachSong);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 340);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Delete);
            this.panel2.Controls.Add(this.LyricsView);
            this.panel2.Controls.Add(this.SongView);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 381);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 340);
            this.panel2.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchLyricsToolStripMenuItem,
            this.putLyricsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(977, 30);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // searchLyricsToolStripMenuItem
            // 
            this.searchLyricsToolStripMenuItem.Name = "searchLyricsToolStripMenuItem";
            this.searchLyricsToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.searchLyricsToolStripMenuItem.Text = "Search_Lyrics";
            this.searchLyricsToolStripMenuItem.Click += new System.EventHandler(this.searchLyricsToolStripMenuItem_Click);
            // 
            // putLyricsToolStripMenuItem
            // 
            this.putLyricsToolStripMenuItem.Name = "putLyricsToolStripMenuItem";
            this.putLyricsToolStripMenuItem.Size = new System.Drawing.Size(88, 26);
            this.putLyricsToolStripMenuItem.Text = "Put_Lyrics";
            this.putLyricsToolStripMenuItem.Click += new System.EventHandler(this.putLyricsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 724);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SSstupid_LyricsManager";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SerachSong;
        private System.Windows.Forms.Button SearchB;
        private System.Windows.Forms.TextBox LyricsText;
        private System.Windows.Forms.Button SaveB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView SongView;
        private System.Windows.Forms.ListView LyricsView;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem searchLyricsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putLyricsToolStripMenuItem;
    }
}

