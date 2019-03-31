using Shadowsocks.Bayoujs.Service;
using Shadowsocks.Bayoujs.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shadowsocks.Bayoujs.Controller
{
    class MainController: IDenpendency
    {
        public BayouMainForm mainForm { get; set; }
        public LoginForm loginForm { get; set; }
        public BayouServer bs { get; set; }

        public void index() {
           //loginForm.MdiParent = mainForm;
            mainForm.Show();
            userInfoGetAndShow();
        }


        //获取用户信息并输出到页面
        public void userInfoGetAndShow()
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                bs.getUserInfo(null, (res) => {
                    mainForm.userInfoShow(res.Data);
                });
            });
        }

    }
}
