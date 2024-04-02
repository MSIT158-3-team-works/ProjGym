namespace Gym
{
    partial class FrmField
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblfID = new System.Windows.Forms.Label();
            this.fbFieldPayment = new prjComponentDemo.usercontrol.FieldBox();
            this.fbFieldName = new prjComponentDemo.usercontrol.FieldBox();
            this.fbFieldFloor = new prjComponentDemo.usercontrol.FieldBox();
            this.fbregion = new prjComponentDemo.usercontrol.FieldBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(357, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(431, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(527, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(667, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblfID
            // 
            this.lblfID.AutoSize = true;
            this.lblfID.Location = new System.Drawing.Point(277, 34);
            this.lblfID.Name = "lblfID";
            this.lblfID.Size = new System.Drawing.Size(41, 15);
            this.lblfID.TabIndex = 6;
            this.lblfID.Text = "label1";
            this.lblfID.Visible = false;
            // 
            // fbFieldPayment
            // 
            this.fbFieldPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbFieldPayment.fieldName = "費用";
            this.fbFieldPayment.fieldValue = "";
            this.fbFieldPayment.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fbFieldPayment.Location = new System.Drawing.Point(13, 275);
            this.fbFieldPayment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fbFieldPayment.Name = "fbFieldPayment";
            this.fbFieldPayment.Size = new System.Drawing.Size(246, 79);
            this.fbFieldPayment.TabIndex = 2;
            // 
            // fbFieldName
            // 
            this.fbFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbFieldName.fieldName = "場地名";
            this.fbFieldName.fieldValue = "";
            this.fbFieldName.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fbFieldName.Location = new System.Drawing.Point(13, 190);
            this.fbFieldName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fbFieldName.Name = "fbFieldName";
            this.fbFieldName.Size = new System.Drawing.Size(246, 79);
            this.fbFieldName.TabIndex = 1;
            // 
            // fbFieldFloor
            // 
            this.fbFieldFloor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbFieldFloor.fieldName = "樓層";
            this.fbFieldFloor.fieldValue = "";
            this.fbFieldFloor.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fbFieldFloor.Location = new System.Drawing.Point(13, 105);
            this.fbFieldFloor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fbFieldFloor.Name = "fbFieldFloor";
            this.fbFieldFloor.Size = new System.Drawing.Size(246, 79);
            this.fbFieldFloor.TabIndex = 0;
            // 
            // fbregion
            // 
            this.fbregion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbregion.fieldName = "region";
            this.fbregion.fieldValue = "";
            this.fbregion.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.fbregion.Location = new System.Drawing.Point(13, 17);
            this.fbregion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fbregion.Name = "fbregion";
            this.fbregion.Size = new System.Drawing.Size(246, 79);
            this.fbregion.TabIndex = 7;
            // 
            // FrmField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fbregion);
            this.Controls.Add(this.lblfID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.fbFieldPayment);
            this.Controls.Add(this.fbFieldName);
            this.Controls.Add(this.fbFieldFloor);
            this.Name = "FrmField";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private prjComponentDemo.usercontrol.FieldBox fbFieldFloor;
        private prjComponentDemo.usercontrol.FieldBox fbFieldName;
        private prjComponentDemo.usercontrol.FieldBox fbFieldPayment;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblfID;
        private prjComponentDemo.usercontrol.FieldBox fbregion;
    }
}