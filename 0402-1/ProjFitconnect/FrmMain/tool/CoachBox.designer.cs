namespace mid_Coonect.Tools
{
    partial class CoachBox
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCoachName = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelCoachinfo = new System.Windows.Forms.Label();
            this.labelCourse = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelCoachName
            // 
            this.labelCoachName.AutoSize = true;
            this.labelCoachName.Font = new System.Drawing.Font("細明體-ExtB", 22.20561F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCoachName.Location = new System.Drawing.Point(154, 56);
            this.labelCoachName.Name = "labelCoachName";
            this.labelCoachName.Size = new System.Drawing.Size(123, 34);
            this.labelCoachName.TabIndex = 1;
            this.labelCoachName.Text = "label1";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("微軟正黑體", 12.11215F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelGender.Location = new System.Drawing.Point(156, 90);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(64, 24);
            this.labelGender.TabIndex = 2;
            this.labelGender.Text = "label1";
            // 
            // labelCoachinfo
            // 
            this.labelCoachinfo.AutoSize = true;
            this.labelCoachinfo.Font = new System.Drawing.Font("微軟正黑體", 12.11215F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCoachinfo.Location = new System.Drawing.Point(156, 114);
            this.labelCoachinfo.Name = "labelCoachinfo";
            this.labelCoachinfo.Size = new System.Drawing.Size(64, 24);
            this.labelCoachinfo.TabIndex = 2;
            this.labelCoachinfo.Text = "label2";
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.Font = new System.Drawing.Font("微軟正黑體", 12.11215F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCourse.Location = new System.Drawing.Point(156, 138);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(64, 24);
            this.labelCourse.TabIndex = 3;
            this.labelCourse.Text = "label3";
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.Yellow;
            this.button.Font = new System.Drawing.Font("微軟正黑體", 12.11215F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button.Location = new System.Drawing.Point(324, 59);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(103, 32);
            this.button.TabIndex = 4;
            this.button.Text = "詳細資訊";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button1_Click);
            // 
            // CoachBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button);
            this.Controls.Add(this.labelCourse);
            this.Controls.Add(this.labelCoachinfo);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelCoachName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CoachBox";
            this.Size = new System.Drawing.Size(430, 166);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelCoachName;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelCoachinfo;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Button button;
    }
}
