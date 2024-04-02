using FrmMain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revised_V1._1
{
    public partial class FrmCoachInfo : Form
    {
        private string _imagepath;
        private tIdentity _pid;private tcoach_info_id _cid;private tclasses _cl;
        public tIdentity pid { get { return _pid; }
            set { 
                _pid = value; 
                 labelName.Text=_pid.name ; 
                if (_pid.gender_id == 1) { labelGender.Text = "男性"; }
                if (_pid.gender_id == 2) { labelGender.Text = "女性"; }
                if (_pid.gender_id == 3) { labelGender.Text = "其他"; }
                if (!string.IsNullOrEmpty(_pid.photo))
                {
                    string path = Application.StartupPath + "\\CoachImages";
                    roundPictureBox1.Image = new Bitmap(path + "\\" + _pid.photo);
                }
            } }
        
        public tcoach_info_id cid { get { return _cid;}
            set { 
                _cid = value;
                labelLicense.Text = _cid.coach_intro;
            }
        }

        public tclasses cl { get { return _cl;}
            set {_cl=value; labelClass.Text=_cl.class_name; } }

        public FrmCoachInfo()
        {
            InitializeComponent();
        }

    }
}
