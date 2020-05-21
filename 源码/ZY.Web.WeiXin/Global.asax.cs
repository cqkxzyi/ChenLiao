using CY.WEIXIN.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        #region 系统异常处理
        /// <summary>
        /// 系统异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            //if (exception == null || exception.Message.Contains("未找到路径") || exception.Message.Contains("文件不存在"))
            //{
            //    return;
            //}

            //将异常记录到文件
            LogWriter.WriteError(exception,"/Error");

            Response.Clear();

            //HttpException httpException = exception as HttpException;
            //RouteData routeData = new RouteData();
            //routeData.Values.Add("controller", "MyError");
            //routeData.Values.Add("action", "Error01");
            //routeData.Values.Add("errorStr", exception.Message);
            Server.ClearError();

        }

        //protected override void OnException(ExceptionContext filterContext)
        //{

        //    //将异常记录到文件
        //    LogWriter.Write(filterContext.Exception);
        //    BaseController.WriteExceptionToFile(filterContext.Exception);

        //    //// 标记异常已处理
        //    //filterContext.ExceptionHandled = true;
        //    //// 跳转到错误页
        //    //filterContext.Result = new RedirectResult(Url.Action("Error", "Shared"));

        //}
        #endregion
    }
}
