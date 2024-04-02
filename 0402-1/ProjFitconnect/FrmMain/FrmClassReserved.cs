using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMain
{
    public partial class FrmClassReserved : Form
    {
        public tIdentity identity { get; set; }
        public FrmClassReserved()
        {
            InitializeComponent();
        }

        private void FrmClassReserved_Load(object sender, EventArgs e)
        {

            gymEntities db = new gymEntities();
            int findID = this.identity.id;
            var classreserved = from c in db.tclasses
                                join s in db.tclass_schedule on c.class_id equals s.class_id
                                join t in db.ttimes_detail on s.course_time_id equals t.time_id
                                join r in db.tclass_reserve on s.class_schedule_id equals r.class_schedule_id
                                join i in db.tIdentity on r.member_id equals i.id
                                where r.member_id == findID
                                select new { classes = c ,classSchedule = s,identity = i,time = t };
            
            foreach (var item in classreserved)
            {

                reservebox rb = new reservebox();
                
                rb.Width = 1000;
                rb.Height = 180;
                rb.Location = new System.Drawing.Point( flowLayoutPanel1.Width / 2-rb.Width/2);
                rb.tc = item.classes;
                rb.i = item.identity;
                rb.ts = item.classSchedule;
                rb.td = item.time;
                flowLayoutPanel1.Controls.Add(rb);
            }

        }
    }
}
