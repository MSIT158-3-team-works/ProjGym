using FrmMain;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gym
{
    public partial class FrmField : Form
    {
        private DialogResult _isOk;
        private tfield _field;
        private string _Field_photo = "";
        public tfield field
        {
            get
            {
                if (_field == null)
                {
                    _field = new tfield();
                }
                _field.region_id = Convert.ToInt32(fbregion.fieldValue);
                _field.floor = fbFieldFloor.fieldValue;
                _field.field_name = fbFieldName.fieldValue;
                _field.field_payment = Convert.ToDecimal(fbFieldPayment.fieldValue);
                _field.field_photo = _Field_photo;
                return _field;
            }
            set
            {
                _field = value;
                lblfID.Text = _field.field_id.ToString();
                fbregion.fieldValue = _field.region_id.ToString();
                fbFieldFloor.fieldValue = _field.floor;
                fbFieldName.fieldValue = _field.field_name;
                fbFieldPayment.fieldValue = _field.field_payment.ToString();
                _Field_photo = _field.field_photo;
                if (!string.IsNullOrEmpty(_Field_photo))
                {
                    string path = Application.StartupPath + "\\roomImages";
                    pictureBox1.Image = new Bitmap(path + "\\" + _Field_photo);
                }
            }
        }
        public DialogResult isOk
        {
            get
            {
                return _isOk;
            }
        }
        public FrmField()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.OK;
            gymEntities db = new gymEntities();
            db.tfield.Add(this.field);
            db.SaveChanges();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.Cancel;
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "場地照片|*.jpg|場地照片|*.png|場地照片|*.bmp";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            _Field_photo = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            string path = Application.StartupPath + "\\fieldImages";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            File.Copy(openFileDialog1.FileName, path + "\\" + _Field_photo);
            pictureBox1.Image = new Bitmap(path + "\\" + _Field_photo);
        }
    }
}
