using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrmMain;
using Revised_V1._1;

namespace mid_Coonect
{
    public partial class FrmClassUpdate : Form
    {
        private DialogResult _isOK;
        public DialogResult isOK { get { return _isOK; } }
        private string _imagepath;
        private tclasses _clAss;
        public tclasses clAss
        {
            get
            {
                if (_clAss == null) { _clAss = new tclasses(); }
                _clAss.class_id = Convert.ToInt32(lbID.Text);
                _clAss.class_sort1_id = Convert.ToInt32(comboBox1.Text);
                _clAss.class_sort2_id = Convert.ToInt32(comboBox2.Text);
                _clAss.limited_gender = Convert.ToInt32(comboBox3.Text);
                _clAss.class_name = txtClassName.Text;
                _clAss.class_introduction = this.txtIntroduction.Text;
                _clAss.class_photo = _imagepath;
                return _clAss;


            }
            set
            {
                _clAss = value;
                lbID.Text = _clAss.class_id.ToString();
                comboBox1.Text = _clAss.class_sort1_id.ToString();
                comboBox2.Text = _clAss.class_sort2_id.ToString();
                comboBox3.Text = _clAss.limited_gender.ToString();
                txtClassName.Text = _clAss.class_name;
                txtIntroduction.Text = _clAss.class_introduction;
                _imagepath = _clAss.class_photo;
                if (!string.IsNullOrEmpty(_imagepath))
                {
                    string path = Application.StartupPath + "\\ClassPic";
                    pictureBox1.Image = new Bitmap(path + "\\" + _imagepath);
                }
            }
        }
        public FrmClassUpdate()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "課程照片|*.jpg|課程照片|*.png";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            _imagepath = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            string path = Application.StartupPath + "\\ClassPic";
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            File.Copy(openFileDialog1.FileName, path + "\\" + _imagepath);
            this.pictureBox1.Image = new Bitmap(path + "\\" + _imagepath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isOK=DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isOK = DialogResult.OK;
            //gymEntities db = new gymEntities();  
            try
            {
                int id=Convert.ToInt32(lbID.Text);
                dbEdit(id);
            }
            catch (Exception ex) { MessageBox.Show("" + ex); }
            finally { ShowdbCalss(); }
        }
        private void ShowdbCalss() 
        {
            gymEntities db = new gymEntities();
            var classsort=from r in db.tclasses select r;
            this.dataGridView1.DataSource = classsort.ToList();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            dbSelect(1);
        }

        private void FrmClassUpdate_Load(object sender, EventArgs e)
        {
            ShowdbCalss();
        }
        private void dbSelect(int id)
        {
            gymEntities db = new gymEntities();
            tclasses classsort = db.tclasses.FirstOrDefault(x => x.class_id == id);
            if (classsort == null) return;
            this.clAss = classsort;
            lbID.Text=classsort.class_id.ToString();
            comboBox1.Text=classsort.class_sort1_id.ToString() ;
            comboBox2.Text = classsort.class_sort2_id.ToString();
            comboBox3.Text = classsort.limited_gender.ToString(); 
            txtClassName.Text=classsort.class_name;
            txtIntroduction.Text=classsort.class_introduction;
            _imagepath = classsort.class_photo;
            if (!string.IsNullOrEmpty(_imagepath))
            {
                string path = Application.StartupPath + "\\ClassPic";
                pictureBox1.Image = new Bitmap(path + "\\" + _imagepath);
            }
        }
        private void dbEdit(int id)
        {
            using(var db =new gymEntities())
            {
                var classsort = db.tclasses.FirstOrDefault(x => x.class_id == id);
                if (classsort == null) return; //this.clAss = classsort;
                classsort.class_sort1_id = Convert.ToInt32(comboBox1.Text);
                classsort.class_sort2_id = Convert.ToInt32(comboBox2.Text);
                classsort.limited_gender = Convert.ToInt32(comboBox3.Text);
                classsort.class_name = txtClassName.Text;
                classsort.class_introduction = txtIntroduction.Text;
                //MessageBox.Show(txtIntroduction.Text);
                
                if (!string.IsNullOrEmpty(_imagepath))
                {
                    string path = Application.StartupPath + "\\ClassPic";
                    pictureBox1.Image = new Bitmap(path + "\\" + _imagepath);
                }
                classsort.class_photo=_imagepath;
                MessageBox.Show(_imagepath);
                db.SaveChanges();
            } 
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            //MessageBox.Show(""+id);
            dbSelect(id);
        }
    }
}
