using System;
using System.Drawing;
using System.Windows.Forms;
using Shadowsocks.Properties;

namespace Shadowsocks.View
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            this.Icon = Icon.FromHandle(Resources.logo.GetHicon());
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
