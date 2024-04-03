﻿using FrmMain;
using mid_Coonect.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revised_V1._1
{
    public partial class FrmFindCoach : Form
    {
        public FrmFindCoach()
        {
            InitializeComponent();
        }
        private bool _ischeck = true; 
        private void CheckBoxOxygenSelected(int n)
        {
            gymEntities db = new gymEntities();
            var query = from i in db.tIdentity
                        join c in db.tcoach_info_id on i.id equals c.coach_id
                        join ce in db.tcoach_expert on i.id equals ce.coach_id into expertGroup
                        from expert in expertGroup.DefaultIfEmpty()
                        join cs in db.tclasses on expert.class_id equals cs.class_id into expertiseGroup
                        from expertise in expertiseGroup.DefaultIfEmpty()
                        where expertise.class_sort1_id==n
                        select new { Identity = i, CoachInfo = c, Expertise = expertise }; 
            foreach (var item in query)
            {
                CoachBox cb = new CoachBox();
                cb.Width = flowLayoutPanel1.Width / 2;
                cb.Height = 200;
                cb.Identity = item.Identity;
                cb.cid = item.CoachInfo;
                cb.cst = item.Expertise;
                flowLayoutPanel1.Controls.Add(cb);
            }
        }
        private void CheckBoxGenderSelected(int g)
        { 
            gymEntities db = new gymEntities();
            var query = from i in db.tIdentity
                        join c in db.tcoach_info_id on i.id equals c.coach_id
                        join ce in db.tcoach_expert on i.id equals ce.coach_id into expertGroup
                        from expert in expertGroup.DefaultIfEmpty()
                        join cs in db.tclasses on expert.class_id equals cs.class_id into expertiseGroup
                        from expertise in expertiseGroup.DefaultIfEmpty()
                        where i.gender_id==g
                        select new { Identity = i, CoachInfo = c, Expertise = expertise };

            foreach (var item in query)
            {
                CoachBox cb = new CoachBox();
                cb.Width = flowLayoutPanel1.Width / 2;
                cb.Height = 200;
                cb.Identity = item.Identity;
                cb.cid = item.CoachInfo;
                cb.cst = item.Expertise;
                cb.learnMore += this.LearnMore;
                if (flowLayoutPanel1.Controls.Equals(cb)) return;
                flowLayoutPanel1.Controls.Add(cb);
            }
        }

        private void LearnMore(CoachBox p)
        {
            gymEntities db=new gymEntities();
            tIdentity pid = db.tIdentity.FirstOrDefault(x => x.id == p.Identity.id);
            if (pid == null) return;
            tcoach_info_id cid = db.tcoach_info_id.FirstOrDefault(y=>y.coach_id==p.cid.coach_id);
            if (cid == null) return;
            tclasses cl = db.tclasses.FirstOrDefault(z=>z.class_id==p.cst.class_id);
            if (cl == null) return;
            FrmCoachInfo f = new FrmCoachInfo
            {pid = pid, cid = cid, cl = cl,}; 
            f.Show();
        }

        private void UndoGender(int g)
        {
            // Remove all CoachBox controls with matching gender_id
            for (int i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                if (flowLayoutPanel1.Controls[i] is CoachBox cb && cb.Identity.gender_id == g)
                {
                    flowLayoutPanel1.Controls.Remove(cb);
                    cb.Dispose();
                }
            }
        }
        private void UndoOxygen(int g)
        {
            for (int i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                if (flowLayoutPanel1.Controls[i] is CoachBox cb && cb.cst.class_sort1_id == g)
                {
                    flowLayoutPanel1.Controls.Remove(cb);
                    cb.Dispose();
                }
            }
        }
        private void CreateClasssortCheckBox()
        {
            gymEntities db = new gymEntities();
            var classsort = from cs in db.tclasses
                            select cs;
            this.dataGridView1.DataSource = classsort.ToList();
            foreach (var r in classsort)
            {
                CheckBox cb = new CheckBox();
                cb.Text = r.class_name;
                cb.Tag = r.class_name;
                cb.CheckStateChanged += Cb_CheckStateChanged; 
                flowLayoutPanel2.Controls.Add(cb);
            }
        }

        private void Cb_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                string s = chk.Tag.ToString();
                gymEntities db = new gymEntities();
                var query = from i in db.tIdentity
                            join c in db.tcoach_info_id on i.id equals c.coach_id
                            join ce in db.tcoach_expert on i.id equals ce.coach_id into expertGroup
                            from expert in expertGroup.DefaultIfEmpty()
                            join cs in db.tclasses on expert.class_id equals cs.class_id into expertiseGroup
                            from expertise in expertiseGroup.DefaultIfEmpty()
                            where expertise.class_name.Equals(s)
                            select new { Identity = i, CoachInfo = c, Expertise = expertise };

                foreach (var item in query)
                {
                    CoachBox cb = new CoachBox();
                    cb.Width = flowLayoutPanel1.Width / 2;
                    cb.Height = 200;
                    cb.Identity = item.Identity;
                    cb.cid = item.CoachInfo;
                    cb.cst = item.Expertise;
                    flowLayoutPanel1.Controls.Add(cb);
                }
            }
            else {
                for (int i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
                {
                    if (flowLayoutPanel1.Controls[i] is CoachBox cb && cb.cst.class_name.Equals(chk.Tag.ToString()))
                    {
                        flowLayoutPanel1.Controls.Remove(cb);
                        cb.Dispose();
                    }
                }
            }
        }

        private void ShowAllCoachList()
        { 
            gymEntities db = new gymEntities(); 
            var query = from i in db.tIdentity
                        join c in db.tcoach_info_id on i.id equals c.coach_id
                        join ce in db.tcoach_expert on i.id equals ce.coach_id into expertGroup
                        from expert in expertGroup.DefaultIfEmpty()
                        join cs in db.tclasses on expert.class_id equals cs.class_id into expertiseGroup
                        from expertise in expertiseGroup.DefaultIfEmpty()
                        where i.role_id == 2
                        select new { Identity = i, CoachInfo = c, Expertise = expertise };

            foreach (var item in query)
            {
                CoachBox cb = new CoachBox();
                cb.Width = flowLayoutPanel1.Width / 2;
                cb.Height = 200;
                cb.Identity = item.Identity;
                cb.cid = item.CoachInfo;
                cb.cst = item.Expertise;
                flowLayoutPanel1.Controls.Add(cb);
            } 
        }
        private void FrmFindCoach_Load(object sender, EventArgs e)
        {
            //CreateClasssortCheckBox();
            //ShowAllCoachList();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            int g = 1;
            if (checkBox1.Checked) { CheckBoxGenderSelected(g); }
            else UndoGender(g); 
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            int g = 2;
            if (checkBox2.Checked){ CheckBoxGenderSelected(g); }
            else { UndoGender(g); }
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            int g = 3;
            if(checkBox3.Checked) CheckBoxGenderSelected(g);
            else UndoGender(g);
        }

        private void checkBox6_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)ShowAllCoachList();else this.flowLayoutPanel1.Controls.Clear();
        }

        private void checkBox4_CheckStateChanged(object sender, EventArgs e)
        {
            int n = 1;
            if (checkBox4.Checked) CheckBoxOxygenSelected(n);
            else UndoOxygen(n);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            int n = 2;
            if (checkBox5.Checked) CheckBoxOxygenSelected(n);
            else UndoOxygen(n);
        }

        private void checkBox7_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked){ CreateClasssortCheckBox(); flowLayoutPanel2.Visible = true; }
            else flowLayoutPanel2.Visible = false;
        } 
    }
}
