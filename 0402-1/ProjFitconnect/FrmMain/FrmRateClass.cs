using FrmMain.tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmMain
{
    public partial class FrmRateClass : Form
    {
        public tIdentity identity { get;set; }
        public FrmRateClass()
        {
            InitializeComponent();
        }

        private void FrmRateClass_Load(object sender, EventArgs e)
        {
            LoadClasses();
        }

        private void LoadClasses()
        {

            gymEntities db = new gymEntities();
            int findID = this.identity.id;
            var rateClass = from c in db.tclasses
                            join s in db.tclass_schedule on c.class_id equals s.class_id
                            join rc in db.tmember_rate_class on s.class_schedule_id equals rc.class_schedule_id
                            join cr in db.tclass_reserve on s.class_schedule_id equals cr.class_schedule_id
                            join ri in db.tIdentity on cr.member_id equals ri.id
                            join i in db.tIdentity on rc.class_schedule_id equals i.id
                            where rc.member_id == findID/*&& cr.reserve_status == true*/
                            select new { classes = c, classSchedule = s ,classReserve = cr, identity = ri, memberRateClass = rc ,iidentity = ri };// new { classes = c, classSchedule = s, identity = i, memberRateClass = rc };
            //dataGridView1.DataSource = rateClass.ToList();
            if (rateClass.ToList().Count == 0) MessageBox.Show("尚無未評價課程");
            foreach (var item in rateClass)
            {

                rateClassBox rb = new rateClassBox();

                rb.Width = flowLayoutPanel1.Width; // 2 ;
                rb.Height = 400;
                rb.c = item.classes; 
                rb.i = item.identity;
                rb.cs = item.classSchedule;
                rb.rc = item.memberRateClass;
                rb.cr = item.classReserve;
                rb.i = item.iidentity;
                rb.DRateClass += renewRate;
                flowLayoutPanel1.Controls.Add(rb);
            }
        }

        private void renewRate(rateClassBox p)
        {
            using(gymEntities db = new gymEntities()) 
            {
                //todo:2 完成將課程評價存入資料庫
                //tmember_rate_class rateclass = db.tmember_rate_class.FirstOrDefault(r=>r.member_id ==p.);
            }
        }
    }
}
