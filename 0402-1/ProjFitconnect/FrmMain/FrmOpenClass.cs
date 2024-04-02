using FrmMain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjGym
{


    public partial class FrmOpenClass : Form
    {
        private FrmMain m;
        private DialogResult _isOk;
        private tclass_schedule _schedule;
        

        public tclass_schedule schedule
        {
            get
            {
                if (_schedule == null)
                {
                    _schedule = new tclass_schedule();
                }

                gymEntities gym = new gymEntities();
                tclasses c = gym.tclasses.FirstOrDefault(x => x.class_name == this.cbClassName.Text);
                _schedule.class_id = c.class_id;
                _schedule.coach_id = m.member.id;
                tfield f = gym.tfield.FirstOrDefault(x => x.field_name == this.cbField.Text);
                _schedule.field_id = f.field_id;
                _schedule.course_date = this.dateTimePicker1.Value;
                ttimes_detail t = gym.ttimes_detail.FirstOrDefault(x => x.time_name == this.cbTime.Text);
                _schedule.course_time_id = t.time_id;
                _schedule.Max_student = Convert.ToInt32(txtMaxStudent.Text);
                _schedule.class_payment = Convert.ToInt32(txtPrice.Text);
                _schedule.class_status_id = 2;
                return _schedule;

            }
            set
            {
                _schedule = value;

                cbClassName.SelectedValue = _schedule.class_id.ToString();
                cbField.SelectedValue = _schedule.field_id.ToString();
                dateTimePicker1.Value = _schedule.course_date;
                cbTime.SelectedValue = _schedule.course_time_id.ToString();
                txtMaxStudent.Text = _schedule.Max_student.ToString();
                txtPrice.Text = _schedule.class_payment.ToString();

            }
        }


        //public string classname { get { return this.cbClassName.SelectedItem.ToString(); } }
        //public string field { get { return this.cbField.SelectedItem.ToString(); } }
        //public string date { get { return this.dateTimePicker1.Value.ToString(); } }
        //public string time { get { return this.cbTime.SelectedItem.ToString(); } }
        //public string maxstudent { get { return this.txtMaxStudent.Text.ToString(); } }
        //public string price { get { return this.txtPrice.Text.ToString(); } }
        //public DialogResult result { get; set; }


        public DialogResult isOk
        {
            get
            {
                return _isOk;
            }
        }

        public FrmOpenClass(FrmMain m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void FrmOpenClass_Load(object sender, EventArgs e)
        {
            cbClassName.Items.Clear();
            gymEntities gym = new gymEntities();
            var classes = from c in gym.tclasses select c;
            classes.ToList().ForEach(c => { cbClassName.Items.Add(c.class_name); });

            cbField.Items.Clear();
            var field = from f in gym.tfield select f;
            field.ToList().ForEach(f => { cbField.Items.Add(f.field_name); });

            cbTime.Items.Clear();
            var times = from t in gym.ttimes_detail select t;
            times.ToList().ForEach(t => { cbTime.Items.Add(t.time_name); });
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.OK;

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.Cancel;
            Close();
        }
    }
}
