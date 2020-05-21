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

        #region ϵͳ�쳣����
        /// <summary>
        /// ϵͳ�쳣����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            //if (exception == null || exception.Message.Contains("δ�ҵ�·��") || exception.Message.Contains("�ļ�������"))
            //{
            //    return;
            //}

            //���쳣��¼���ļ�
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

        //    //���쳣��¼���ļ�
        //    LogWriter.Write(filterContext.Exception);
        //    BaseController.WriteExceptionToFile(filterContext.Exception);

        //    //// ����쳣�Ѵ���
        //    //filterContext.ExceptionHandled = true;
        //    //// ��ת������ҳ
        //    //filterContext.Result = new RedirectResult(Url.Action("Error", "Shared"));

        //}
        #endregion
    }
}
