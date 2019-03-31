using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Shadowsocks.Bayoujs.Service
{
    public interface IBayouServer : IDenpendency { }
    public class BayouServer: IBayouServer
    {

        //URI
        public const string URI_LOGIN= "/game-client/login"; //登录
        public string BASE_URL = "http://bayoujs.com";



        private RestClient bayou = null;

        public BayouServer()
        {
            //asdfsaf
            bayou = new RestClient(BASE_URL);
            bayou.Timeout = 10000;//超时时间
        }


        //用户登陆
        public void Login(LoginReq loginParams, Action<IRestResponse<Res<LoginRes>>> callback) {
            var request = new RestRequest(URI_LOGIN, Method.POST);
            beanToPostParams(loginParams, request);
            bayou.ExecuteAsync(request,callback);
        }

        //获取用户信息
        public void getUserInfo(string userId, Action<IRestResponse<Res<GetUserSimpleInfoRes>>> callback) {


            IRestResponse<Res<GetUserSimpleInfoRes>> res = new RestResponse<Res<GetUserSimpleInfoRes>>();

            res.Data = new Res<GetUserSimpleInfoRes>();

            UserSimpleInfo userSimple = new UserSimpleInfo();
            userSimple.headImg = "http://bayoujs.com//favicon.ico";
            userSimple.level = "2";
            userSimple.name="手写本地测试数据";
            userSimple.timeRemaind = "100";

            res.Data.data = new GetUserSimpleInfoRes();
            res.Data.data.userSimpleInfo = userSimple;

            callback(res);

        }

        

        //-----------------------------------------------   util function
        private void beanToPostParams(object bean, RestRequest req) {
            var type = bean.GetType();
            var properties=type.GetProperties();

            foreach (System.Reflection.PropertyInfo p in properties)
            {
                req.AddParameter(p.Name, p.GetValue(bean).ToString());
            }
        }


    }

    //-----------------------------------------------------  http response
    public class Res<T> where T: BaseResData
    {
        public Int32 ret { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
    }

    public class BaseResData
    {
        public string ERROR;//普通错误
    }


    public class GetUserSimpleInfoRes : BaseResData {
        public UserSimpleInfo userSimpleInfo;
    }
    public class UserSimpleInfo{
        public string headImg;//头像url
        public string name;//名字
        public string level;//等级
        public string timeRemaind;//剩余时间 单位分钟
    }

    public class LoginRes : BaseResData
    {
        public LoginSucc succ;
    }

    public class LoginSucc
    {

    }


    //----------------------------------------------------- http request
    public class BaseReq
    {
        public string system = "windows10";
    }

    public class LoginReq : BaseReq {

        public string email { get; set; }
        public string passwd { get; set; }
    }

}
