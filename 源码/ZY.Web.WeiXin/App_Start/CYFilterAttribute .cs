using CY.WEIXIN.Util;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CY.WEIXIN.Web.App_Start
{
    public class CYFilterAttribute : ActionFilterAttribute
    {
        private ILog log = LogManager.GetLogger(typeof(CYFilterAttribute));

        /// <summary>
        /// 在Action方法之前调用
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var cyRedirct = filterContext.HttpContext.Request.Path;
                var user = filterContext.HttpContext.Session["admin"];
                if (user == null)
                {
                    var loginInfo = filterContext.HttpContext.Request.Cookies["LoginInfo"];
                    if (loginInfo != null)
                    {
                        var openid = loginInfo["openid"];
                        log.Info(openid);

                        var dbUser = Bussiness.UPM.UPMAppApiBLL.GetUserByOpenid(openid);
                        if (dbUser != null)
                        {
                            filterContext.HttpContext.Session["admin"] = dbUser;
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult("/login/index?cyredirct=" + cyRedirct);
                        }

                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("/login/index?cyredirct=" + cyRedirct);
                    }

                }
                base.OnActionExecuting(filterContext);

            }
            catch (Exception ex)
            {
                LogWriter.WriteError(ex, "/Error/");
            }
        }
    }
}