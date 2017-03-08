using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace MusicStore.Filters
{
    /// <summary>
    /// 自定义动作和结果过滤器+注解特性
    /// 既可以在全局过滤器中进行注册 又可以标记在方法或者类上
    /// ActionFilterAttribute继承FilterAttibute,实现IActionFilter and IResultFilter
    /// 实现访问日志记录等功能
    /// </summary>
    public class ActionAndResultFilterAttribute:ActionFilterAttribute
    {
        private readonly ThreadLocal<Stopwatch> actionStopwatch = new ThreadLocal<Stopwatch>(()=>new Stopwatch());
        //private readonly ILog logger = LogManager.GetLogger(typeof(ActionAndResultFilterAttribute));
        private readonly ILog logger = LogManager.GetLogger("ActionAndResultFilterAttribute");
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            actionStopwatch.Value.Start();
            logActionStartDateTime();
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            actionStopwatch.Value.Stop();
            logActionEndDateTime(actionStopwatch.Value);
            base.OnActionExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            logRenderStartTime();
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            logRenderEndTime();
            base.OnResultExecuted(filterContext);
        }
        

        private void logActionStartDateTime()
        {
           string virtualPath=HttpContext.Current.Request.ApplicationPath;
           logger.Info(string.Format("->  "+virtualPath));
        }
        private void logActionEndDateTime(Stopwatch watch)
        {
            string virtualPath = HttpContext.Current.Request.ApplicationPath;
            logger.Info(string.Format(string.Format("{0}-> count:{1}s", virtualPath, watch.ElapsedTicks)));
        }
        private void logRenderStartTime()
        {
            string virtualPath = HttpContext.Current.Request.ApplicationPath;
            logger.Info(string.Format("sr"+virtualPath));
        }
        private void logRenderEndTime()
        {
            string virtualPath = HttpContext.Current.Request.ApplicationPath;
            logger.Info(string.Format("er" + virtualPath));
        }

    }
}