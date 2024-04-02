using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjGym
{
    public partial class Frm_首頁 : Form
    {
        private Timer Timer_ann;
        private int currentPosition = 0;
        private string announcementText = "歡迎來到FitConnect，您可以在首頁查看最新消息以及相關優惠訊息";
        public Frm_首頁()
        {
            InitializeComponent();
            Run_announcementText();
            splitContainer1.SplitterWidth = 3;
            SetRoundButton(button1, 40);
            SetRoundButton(button2, 40);
        }
        
        //跑馬燈
        private void Run_announcementText()
        {
            label_ann.Text = announcementText.Substring(currentPosition) + announcementText.Substring(0, currentPosition);
            Timer_ann = new Timer();
            Timer_ann.Interval = 500;
            Timer_ann.Tick += AnnTimer_Tick;
            Timer_ann.Start();
        }

        private void AnnTimer_Tick(object sender, EventArgs e)
        {
            currentPosition++;
            if (currentPosition >= announcementText.Length)
            {
                currentPosition = 0;
            }
            label_ann.Text = announcementText.Substring(currentPosition) + announcementText.Substring(0, currentPosition);
        }



        //場地picturebox圓角
        private void Frm_首頁_Load(object sender, EventArgs e)
        {
            SetPictureBoxRoundCorner(pictureBox_field, 50);
        }
        private void SetPictureBoxRoundCorner(PictureBox pb, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pb.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pb.Width - radius, pb.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pb.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            pb.Region = new Region(path);
        }
        //label圓角
        private void DrawRoundedLabel(Graphics g, System.Windows.Forms.Label lbl, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(lbl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(lbl.Width - radius, lbl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, lbl.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            lbl.Region = new Region(path);
        }
        private void Frm_首頁_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedLabel(e.Graphics, label4, 20);
            DrawRoundedLabel(e.Graphics, label6, 20);
            DrawRoundedLabel(e.Graphics, label9, 20);
            DrawRoundedLabel(e.Graphics, label20, 20);
            DrawRoundedLabel(e.Graphics, label15, 20);
            DrawRoundedLabel(e.Graphics, label4, 20);
        }

        
        private void SetRoundButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
        }

        

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //pictureBox_field.Image = System.Properties.Resources.gym1;
        }
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            //pictureBox_field.Image = Properties.Resources.gym3;
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //pictureBox_field.Image = Properties.Resources.gym4;
        }
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            //pictureBox_field.Image = Properties.Resources.gymm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmFAQ fAQ = new FrmFAQ();
            fAQ.TopLevel = false;
            fAQ.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(fAQ);
            fAQ.Show();

        }
    }

    

}
