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
    public partial class FrmCoachScheduleView : Form
    {
        
        public FrmCoachScheduleView()
        {
            InitializeComponent();
        }
        private void queryAll()
        {
            FrmMain frmMain = this.MdiParent as FrmMain;

            gymEntities db = new gymEntities();
            var schedules = from s in db.tclass_schedule
                            where s.coach_id == frmMain.member.id
                            select new
                            {
                                
                                ClassName = s.tclasses.class_name,
                                Field =s.tfield.field_name,
                                Date =s.course_date,
                                Time =s.ttimes_detail.time_name,
                                MaxStudent = s.Max_student,
                                ClassStatus =s.tclass_status_detail.class_status_discribe,
                                Payment =s.class_payment

                            };
            dataGridView1.DataSource = schedules.ToList();
            resetGridStyle();


        }
        private void resetGridStyle()
        {
            dataGridView1.Columns[0].HeaderText = "課程名稱";
            dataGridView1.Columns[1].HeaderText = "上課地點";
            dataGridView1.Columns[2].HeaderText = "上課日期";
            dataGridView1.Columns[3].HeaderText = "上課時段";
            dataGridView1.Columns[4].HeaderText = "學生上限";
            dataGridView1.Columns[5].HeaderText = "開課狀態";
            dataGridView1.Columns[6].HeaderText = "價格";
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 80;

            bool isColorChanged = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                isColorChanged = !isColorChanged;
                r.DefaultCellStyle.BackColor = Color.FromArgb(229, 229, 229);
                if (isColorChanged)
                    r.DefaultCellStyle.BackColor = Color.White;
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 12);
            }

        }

        private void FrmCoachScheduleEdit_Load(object sender, EventArgs e)
        {
            queryAll();
        }

        private void FrmCoachScheduleEdit_Activated(object sender, EventArgs e)
        {
            resetGridStyle();
        }
    }
}
