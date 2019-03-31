using Autofac;
using Shadowsocks.Bayoujs.Controller;
using Shadowsocks.Bayoujs.Service;
using Shadowsocks.Bayoujs.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shadowsocks.Bayoujs
{
    class BayouProgram:IDenpendency
    {
        private static IContainer container { get; set; }
        
        
        public BayouProgram()
        {
            //启用Autofac框架，ioc di 框架
            ContainerBuilder builder = new ContainerBuilder();

            //批量注册到ioc
            Type basetype = typeof(IDenpendency);//只要是继承了IDenpendency的类都被autofac框架管理
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Where(t => basetype.IsAssignableFrom(t) && t.IsClass)
            //    .AsImplementedInterfaces().InstancePerLifetimeScope().SingleInstance().PropertiesAutowired();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => basetype.IsAssignableFrom(t) && t.IsClass)
                .AsSelf().AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .SingleInstance()
                .PropertiesAutowired();
            container =builder.Build();







            //BayouMainForm loginForm = (BayouMainForm)container.Resolve<IBayouMainForm>();
            MainController a = container.Resolve<MainController>();

            a.index();
    
        
        }



        // 线程池，异步执行任务，防止阻塞UI界面
        public void threadPoolConfig() {
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5);

        }



    }


    public interface IDenpendency { }
}
