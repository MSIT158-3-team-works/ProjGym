using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMain.tool
{
    public delegate void DClassRate(ClassRateBox p);
    public partial class ClassRateBox : UserControl
    {
        public event DClassRate classRate;

        private tIdentity _i;
        private tmember_rate_class _rc;
        private tclass_schedule _cs;
        private tclasses _c;
        private tclass_reserve _cr;

        public tIdentity i { get {  _i.name = lblCoach.Text; return _i; } set { _i = value; lblCoach.Text = _i.name; } }
        public tmember_rate_class rc {  get { _rc.describe = txtFeedback.Text; _rc.rate = Convert.ToDecimal(txtrate); return _rc; } set { _rc = value; txtrate.Text = _rc.rate.ToString(); txtFeedback.Text = _rc.describe; } }
        public tclass_schedule cs { get { return _cs; } set { _cs = value; lblDate.Text = _cs.course_date.ToString(); } }
        public tclasses c { get { return _c; } set { _c = value; lblClassName.Text = _c.class_name; } }

        public tclass_reserve cr { get { return _cr; } set { _cr = value; } }

        public ClassRateBox()
        {
            InitializeComponent();
        }
    }
}
