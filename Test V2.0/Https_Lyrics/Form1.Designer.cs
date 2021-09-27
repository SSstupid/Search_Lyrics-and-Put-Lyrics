
namespace Https_Lyrics
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
            this.ArText = new System.Windows.Forms.TextBox();
            this.TiText = new System.Windows.Forms.TextBox();
            this.CBList = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LyCount = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.ArtLa = new System.Windows.Forms.Label();
            this.TitLa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ArText
            // 
            this.ArText.Location = new System.Drawing.Point(40, 57);
            this.ArText.Name = "ArText";
            this.ArText.Size = new System.Drawing.Size(96, 22);
            this.ArText.TabIndex = 0;
            // 
            // TiText
            // 
            this.TiText.Location = new System.Drawing.Point(151, 57);
            this.TiText.Name = "TiText";
            this.TiText.Size = new System.Drawing.Size(96, 22);
            this.TiText.TabIndex = 1;
            // 
            // CBList
            // 
            this.CBList.FormattingEnabled = true;
            this.CBList.Location = new System.Drawing.Point(40, 106);
            this.CBList.Name = "CBList";
            this.CBList.Size = new System.Drawing.Size(327, 24);
            this.CBList.TabIndex = 20;
            this.CBList.SelectedIndexChanged += new System.EventHandler(this.CBList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LyCount
            // 
            this.LyCount.AutoSize = true;
            this.LyCount.Location = new System.Drawing.Point(423, 140);
            this.LyCount.Name = "LyCount";
            this.LyCount.Size = new System.Drawing.Size(60, 17);
            this.LyCount.TabIndex = 21;
            this.LyCount.Text = "검색 수 : ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(40, 205);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(356, 207);
            this.textBox3.TabIndex = 22;
            // 
            // ArtLa
            // 
            this.ArtLa.AutoSize = true;
            this.ArtLa.Location = new System.Drawing.Point(76, 165);
            this.ArtLa.Name = "ArtLa";
            this.ArtLa.Size = new System.Drawing.Size(60, 17);
            this.ArtLa.TabIndex = 23;
            this.ArtLa.Text = "검색 수 : ";
            // 
            // TitLa
            // 
            this.TitLa.AutoSize = true;
            this.TitLa.Location = new System.Drawing.Point(247, 151);
            this.TitLa.Name = "TitLa";
            this.TitLa.Size = new System.Drawing.Size(60, 17);
            this.TitLa.TabIndex = 24;
            this.TitLa.Text = "검색 수 : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TitLa);
            this.Controls.Add(this.ArtLa);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.LyCount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CBList);
            this.Controls.Add(this.TiText);
            this.Controls.Add(this.ArText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ArText;
        private System.Windows.Forms.TextBox TiText;
        private System.Windows.Forms.ComboBox CBList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LyCount;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label ArtLa;
        private System.Windows.Forms.Label TitLa;
    }
}

