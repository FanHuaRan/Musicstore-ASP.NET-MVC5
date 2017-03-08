using log4net;
using MusicStore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILog logger = LogManager.GetLogger("MvcApplication");
        protected void Application_Start()
        {
            //Code First 数据库初始化
            System.Data.Entity.Database.SetInitializer(new MusicStore.EntityContext.SampleData());
            AreaRegistration.RegisterAllAreas();
            //添加我们的过滤器到全局过滤器中 随后一起被注册
            GlobalFilters.Filters.Add(new ActionAndResultFilterAttribute());
            GlobalFilters.Filters.Add(new FilterExceptionAttribute());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>
        /// 处理全局错误
        /// 包括403 404 500等
        /// 因为我们用了全局异常处理器 所以500错误在此不做处理
        /// 不要问我为什么这样 因为想多学几种处理方式
        /// 自带的修改web.xml方法不喜欢！！
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if(ex is HttpException)
            {
                //不对400 403 404错误进行日志记录
                HttpException httpException=ex as HttpException;
                //错误请求错误
                if (httpException.GetHttpCode() == 400)
                {
                    Response.Redirect("/Home/BadRequest");
                }
                //未授权错误
                if (httpException.GetHttpCode() == 403)
                {
                    Response.Redirect("/Home/NoAuth");
                }
                //404错误
                if (httpException.GetHttpCode() == 404)
                {
                    Response.Redirect("/Home/NoFound");
                }

            }
         

        }
    }
}
