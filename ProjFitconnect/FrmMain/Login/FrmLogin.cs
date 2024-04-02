using FrmMain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjGym
{
    //宣告一個委派作為[登入頁面]表單的事件
    public delegate void Dlogin(tIdentity m);
    public partial class FrmLogin : Form
    {
        private DialogResult _isOK;
        public DialogResult isOK{ get { return _isOK; } set { _isOK = value; } }
        //紀錄是否能關閉[登入頁面]
        bool _isClosed = true;
        //紀錄登入次數
        int loginTimes = 0;
        //宣告一個資料型別為Dlogin、名稱為afterLogin的事件
        public event Dlogin afterLogin;
        public tIdentity auth { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
            //將[登入失敗提示]設為空字串(讓畫面上看不到)

            SetRoundButton(btn_Cancel, 55);
            SetRoundButton(btn_Login, 55);
            SetRoundButton(btn_Register, 55);

            lbl_ErrorLogin.Text = string.Empty;
        }
        private void SetRoundButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            btn.Region = new Region(path);
        }

        //當[使用者]按下[登入頁面]表單上的[登入]按鈕，執行以下程式碼
        private void btn_Login_Click(object sender, EventArgs e)
        {
            //取得[使用者]所輸入的帳號與密碼
            string username = this.tb_UserName.Text;
            string password = this.tb_Password.Text;
            //產生[gym資料庫實體]
            gymEntities db = new gymEntities();
            //依照[使用者]所輸入的帳號與密碼，在[gym資料庫實體]中的[Identity]資料表內進行查詢
            tIdentity m = db.tIdentity.FirstOrDefault(x => x.e_mail == username || x.phone == username && x.password == password);
            //如果成功在[gym資料庫實體]內的[Identity]資料表中找到符合帳號密碼的會員，就執行以下程式碼
            //------------------------------------------------------------------------------↓
            if (m != null)
            {
                _isOK=DialogResult.OK;
                //將[登入頁面]設為:可關閉
                _isClosed = false;
                //先前已在[主程式]表單內的[Load]方法內，註冊showinfo方法來處理afterLogin事件
                //觸發afterLogin事件
                afterLogin(m);
                //關閉[登入頁面]表單
                this.Close();
                //將程式控制權回傳(在此案例中，程式控制權會從[登入頁面]表單回傳給[主程式]表單)(待確定)
                return;
            }
            //------------------------------------------------------------------------------↑
            //否則執行以下程式碼
            //------------------------------------------------------------------------------↓
            //[嘗試登入次數]+1
            loginTimes++;
            //在[登入失敗提示]上顯示[目前錯誤次數]及[剩餘可嘗試次數]
            lbl_ErrorLogin.Text = $"帳號或密碼錯誤: 錯誤次數{loginTimes}次,剩餘錯誤次數{3 - loginTimes}次";
            //如果[嘗試登入次數]大於3次
            if (loginTimes > 3)
            {
                //將[登入頁面]設為:可關閉
                _isClosed = false;
                //結束[主程式]表單
                Application.Exit();
            }
            //------------------------------------------------------------------------------↑
        }

        //[登入表單]在關閉前，執行以下程式碼
        private void FrmCustomerLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //依照_isClosed為true/false，來代表[登入頁面]為:不可關閉/可關閉
            e.Cancel = _isClosed;
        }

        //當[使用者]按下[登入頁面]表單上的[取消]按鈕，執行以下程式碼
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //將[登入頁面]設為:可關閉
            _isClosed = false;
            //結束[主程式]表單
            Application.Exit();
        }

        //當[使用者] 按下[登入頁面]表單上的[註冊] 按鈕，執行以下程式碼
        private void btn_Register_Click(object sender, EventArgs e)
        {
            //新增一個[新增會員資料]表單
            FrmNewMemberRegister frmNewMemberRegister = new FrmNewMemberRegister();
            //在[新增會員資料]表單上，註冊savedata方法，觸發條件:當[新增會員資料]表單的[註冊]按鈕被按下時，執行savedata
            frmNewMemberRegister.savedata += this.savedata_member;
            //將[新增會員資料]表單顯示出來
            frmNewMemberRegister.ShowDialog();
            //如果[新增會員資料]表單的result屬性為DialogResult.No
            if (frmNewMemberRegister.result == DialogResult.No)
                //將程式控制權回傳(在此案例中，程式控制權會從[新增會員資料]表單回傳給[登入頁面]表單)
                return;
        }

        //當[新增會員資料]表單的[註冊]按鈕被按下時，執行以下程式碼
        private void savedata_member(FrmNewMemberRegister frm)//frm為傳回的[新增會員資料]表單(使用者已輸入資訊)
        {
            //產生[gym資料庫實體]
            gymEntities db = new gymEntities();
            //產生[Identity]表單物件
            tIdentity member = new tIdentity();
            //將frm的性別名稱轉換為性別ID
            tgender_Table g = db.tgender_Table.FirstOrDefault(x => x.gender_text.Equals(frm.gender));
            //設定新會員資料(名稱、身分ID、性別ID、電話、地址、生日、電郵、密碼、照片檔案名稱)
            member.name = frm.name;
            //因為此為[新增會員資料]表單，因此身分ID必為1(會員)
            member.role_id = 1;
            member.gender_id = g.gender_id;
            member.phone = frm.phone;
            member.address = frm.address;
            member.birthday = DateTime.Parse(frm.birth);
            member.e_mail = frm.mail;
            member.password = frm.password;
            member.photo = frm.file;
            //將新會員資料新增至[gym資料庫實體]
            db.tIdentity.Add(member);
            //存回資料庫
            db.SaveChanges();
            MessageBox.Show("註冊成功，請使用電話/信箱 + 密碼登入");
        }
        private void coach_signin(object sender, EventArgs e)
        {
            FrmNewCoachRegister frmNewCoachRegister = new FrmNewCoachRegister();
            frmNewCoachRegister.savedata += this.savedata_coach;
            //將[新增會員資料]表單顯示出來
            frmNewCoachRegister.ShowDialog();
            //如果[新增會員資料]表單的result屬性為DialogResult.No
            if (frmNewCoachRegister.result == DialogResult.No)
                //將程式控制權回傳(在此案例中，程式控制權會從[新增會員資料]表單回傳給[登入頁面]表單)
                return;
        }
        private void savedata_coach(FrmNewCoachRegister frm)
        {
            //產生[gym資料庫實體]
            gymEntities db = new gymEntities();
            //產生[Identity]表單物件
            tIdentity coach = new tIdentity();
            
            //將frm的性別名稱轉換為性別ID
            tgender_Table g = db.tgender_Table.FirstOrDefault(x => x.gender_text.Equals(frm.gender));
            //設定新會員資料(名稱、身分ID、性別ID、電話、地址、生日、電郵、密碼、照片檔案名稱)
            coach.name = frm.name;
            //因為此為[新增會員資料]表單，因此身分ID必為1(會員)
            coach.role_id = 2;
            coach.gender_id = g.gender_id;
            coach.phone = frm.phone;
            coach.address = frm.address;
            coach.birthday = DateTime.Parse(frm.birth);
            coach.e_mail = frm.mail;
            coach.password = frm.password;
            coach.photo = frm.file;
            //將新會員資料新增至[gym資料庫實體]
            db.tIdentity.Add(coach);
            
            tcoach_info_id coach_i = new tcoach_info_id();
            coach_i.coach_id = coach.id;
            coach_i.coach_intro = frm.intro;
            db.tcoach_info_id.Add(coach_i);

            foreach (var text in frm.list)
            {
                tcoach_expert coach_e = new tcoach_expert();
                coach_e.coach_id = coach.id;
                tclasses c = db.tclasses.FirstOrDefault(x => x.class_name == text);
                coach_e.class_id = c.class_id;
                db.tcoach_expert.Add(coach_e);
            }
            //存回資料庫
            db.SaveChanges();
            MessageBox.Show("註冊教練成功，請使用電話/信箱 + 密碼登入\n" + "若要開課，請等待管理員審核");
        }
    }
}
