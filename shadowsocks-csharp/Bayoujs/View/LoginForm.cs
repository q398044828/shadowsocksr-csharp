using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shadowsocks.Properties;
using Shadowsocks.Bayoujs.Service;
using RestSharp;
using System.Runtime.InteropServices;

namespace Shadowsocks.Bayoujs.View
{
    public interface ILoginForm : IDenpendency { }
    
    public partial class LoginForm : Form, ILoginForm
    {
        public const string mainColorHex = "#6FD7CF";
        public IBayouServer bayou {
            set; get;
        }

        public LoginForm()
        {
            InitializeComponent();
            this.Icon = Icon.FromHandle(Resources.simple_logo.GetHicon());
            this.menuStrip1.BackColor = System.Drawing.ColorTranslator.FromHtml(mainColorHex);

        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);



        bool beginMove = false;//初始化鼠标位置
        int currentXPosition;
        int currentYPosition;

        private void login_Load(object sender, EventArgs e)
        {
          

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginReq req = new LoginReq();
            req.email = usernameTb.Text;
            req.passwd = passTb.Text;
            ((BayouServer)bayou).Login(req,(IRestResponse<Res<LoginRes>> res)=> {
                Console.WriteLine(res.Content);
                MessageBox.Show(res.Content);
            });
        }

        private void usernameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition;//根据鼠标x坐标确定窗体的左边坐标x
                this.Top += MousePosition.Y - currentYPosition;//根据鼠标的y坐标窗体的顶部，即Y坐标
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }

        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;
            }
        }

        private void X_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
