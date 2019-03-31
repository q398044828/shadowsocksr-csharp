using Shadowsocks.Bayoujs.Service;
using Shadowsocks.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Shadowsocks.Bayoujs.View
{
    public partial class BayouMainForm : Form, IDenpendency
    {
        public LoginForm loginForm { get; set; }
        public BayouMainForm()
        {
            InitializeComponent();
            this.Icon = Icon.FromHandle(Resources.simple_logo.GetHicon());
        }

        private void BayouMainForm_Load(object sender, EventArgs e)
        {
            
        }

        

        public void userInfoShow(object userInfo)
        {
            //MessageBox.Show("userInfo:"+userInfo.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void userHeadImg_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void loginFormBtn_Click(object sender, EventArgs e)
        {
            loginForm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
