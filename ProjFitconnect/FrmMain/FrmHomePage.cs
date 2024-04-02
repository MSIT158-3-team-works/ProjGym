using FrmMain;
using Revised_V1._1;
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
    public partial class FrmHomePage : Form
    {
        public tIdentity identity { get; set; }

        Label lblWelcome;

        public FrmHomePage()
        {
            InitializeComponent();
            splitContainer1.SplitterWidth = 3;
            //OpenLoginForm(); 

        }
        private void closeCurrentForm()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }
        private void OpenLoginForm()
        {
            FrmLogin loginForm = new FrmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                FrmMain courseForm = new FrmMain();
                courseForm.MdiParent = this;
                courseForm.Show();
            }
            else
            {
                Application.Exit(); // 如果取消登入，關閉應用程式
            }
        } 

        private void 首頁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showmain();
            
            
        }

        private void 修改會員資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeCurrentForm();
            //todo:0
            lbl_Info.Visible = false;
            this.splitContainer1.Panel2.Controls.Clear();
            FrmEditMemberRegister editMemberRegister = new FrmEditMemberRegister();
            editMemberRegister.identity= this.identity;
            editMemberRegister.afterEdit += this.showinfo;
            editMemberRegister.TopLevel = false;
            editMemberRegister.FormBorderStyle = FormBorderStyle.None;

            editMemberRegister.Visible= true;
            editMemberRegister.Dock = DockStyle.Fill;
            editMemberRegister.StartPosition = FormStartPosition.CenterParent;
            editMemberRegister.MdiParent = this;
            this.splitContainer1.Panel2.Controls.Add(editMemberRegister);
            editMemberRegister.Show();
            

        }

        private void showinfo(tIdentity m)
        {
            this.identity = m;
            lbl_Info.Visible = false;

            if (m.role_id == 1)
                info_member(m);
            if (m.role_id == 2)
                info_coach(m);
            if (m.role_id == 3)
                info_admin(m);
        }

        private void info_member(tIdentity m)
        {
            this.教練中心ToolStripMenuItem.Visible = false;
            this.管理者中心ToolStripMenuItem.Visible = false;

            Label lblWelcome = new Label();
            lblWelcome.Text = "歡迎，會員 " + m.name + " 登入";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Font = new Font("微軟正黑體", 20, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Blue;
            lblWelcome.AutoSize = true; // 啟用自動調整大小
            lblWelcome.MaximumSize = new Size(this.splitContainer1.Panel2.Width, 0);

            int x = (splitContainer1.Panel2.Width - lblWelcome.Width) / 2;
            int y = (splitContainer1.Panel2.Height - lblWelcome.Height) / 2;
            lblWelcome.Location = new Point(x, y);

            this.splitContainer1.Panel2.Controls.Add(lblWelcome);

            this.Text = "歡迎登入 ： " + m.name;
        }

        private void info_coach(tIdentity m)
        {
            this.會員中心ToolStripMenuItem.Visible = false;
            this.管理者中心ToolStripMenuItem.Visible = false;

            lblWelcome = new Label();
            lblWelcome.Text = "歡迎，教練 " + m.name + " 登入";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Font = new Font("微軟正黑體", 20, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Blue;
            lblWelcome.AutoSize = true; // 啟用自動調整大小
            lblWelcome.MaximumSize = new Size(this.splitContainer1.Panel2.Width, 0);

            int x = (splitContainer1.Panel2.Width - lblWelcome.Width) / 2;
            int y = (splitContainer1.Panel2.Height - lblWelcome.Height) / 2;
            lblWelcome.Location = new Point(x, y);

            this.splitContainer1.Panel2.Controls.Add(lblWelcome);

            this.Text = "歡迎登入 ： " + m.name;
        }

        private void info_admin(tIdentity m)
        {
            Label lblWelcome = new Label();
            lblWelcome.Text = "歡迎登入： " + m.name;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Font = new Font("微軟正黑體", 20, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Blue;
            lblWelcome.AutoSize = true; // 啟用自動調整大小
            lblWelcome.MaximumSize = new Size(this.splitContainer1.Panel2.Width, 0);

            int x = (splitContainer1.Panel2.Width - lblWelcome.Width) / 2;
            int y = (splitContainer1.Panel2.Height - lblWelcome.Height) / 2;
            lblWelcome.Location = new Point(x, y);

            this.splitContainer1.Panel2.Controls.Add(lblWelcome);

            this.Text = "歡迎登入 ： " + m.name;
        }

        private void 常見問題ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmFAQ fAQ = new FrmFAQ();
            fAQ.TopLevel = false;
            fAQ.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(fAQ);
            fAQ.Show();
        }

        private void FrmHomePage_Load_1(object sender, EventArgs e)
        {
            this.Visible = false; 
            MainLog();
            showinfo(this.identity);
        }

        private void MainLog()
        {
            //this.splitContainer1.Panel2.Controls.Clear();
            lbl_Info.Text = string.Empty;
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.afterLogin += this.showinfo;
            frmLogin.ShowDialog();
            if (frmLogin.isOK != DialogResult.OK) return;
            this.Visible = true;
        }

        private void 新增管理者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewAdminRegister frm = new FrmNewAdminRegister();
            frm.savedata += FrmAdmin_register;
            //將[新增會員資料]表單顯示出來
            frm.ShowDialog();
            //如果[新增會員資料]表單的result屬性為DialogResult.No
            if (frm.result == DialogResult.No)
                //將程式控制權回傳(在此案例中，程式控制權會從[新增會員資料]表單回傳給[登入頁面]表單)
                return;
        }

        private void FrmAdmin_register(FrmNewAdminRegister frm)
        {
            //產生[gym資料庫實體]
            gymEntities db = new gymEntities();
            //產生[Identity]表單物件
            tIdentity admin = new tIdentity();
            //設定新會員資料(名稱、身分ID、性別ID、電話、地址、生日、電郵、密碼、照片檔案名稱)
            int admin_count = db.tIdentity.Count(x => x.role_id.Equals(3)) + 1;
            admin.role_id = 3;
            admin.name = $"Admin {admin_count}";
            admin.phone = frm.phone;
            admin.e_mail = "x";
            admin.password = frm.password;
            admin.photo = "x";
            admin.birthday = DateTime.Now;
            admin.address = "x";
            admin.gender_id = 3;
            //將新會員資料新增至[gym資料庫實體]
            db.tIdentity.Add(admin);
            //存回資料庫
            db.SaveChanges();
            MessageBox.Show("新增管理員完成");
        }

        private void 會員登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutevent();
            MainLog();
        }

        private void 帳號登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logoutevent();
            MainLog();
        }

        private void logoutevent()
        {
            DialogResult Logout = MessageBox.Show("確定要登出？", "", MessageBoxButtons.OKCancel);
            if (Logout == DialogResult.Yes)
            {
                this.identity = null;
                this.lblWelcome = null;
                showmain();
                return;
            }   
        }

        private void showmain()
        {
            this.splitContainer1.Panel2.Controls.Clear();
            Frm_首頁 mm = new Frm_首頁();
            mm.TopLevel = false;
            mm.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(mm);
            mm.Show();
        }

        private void 已預約課程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmClassReserved f = new FrmClassReserved();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 找教練ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmFindCoach f = new FrmFindCoach();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void yOUTUBEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        private void 修改教練資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmEditCoachRegister f = new FrmEditCoachRegister();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }

        private void 找商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            FrmProducts f = new FrmProducts();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.splitContainer1.Panel2.Controls.Add(f);
            f.Show();
        }
    }
}
