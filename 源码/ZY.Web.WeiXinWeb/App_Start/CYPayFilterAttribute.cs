
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CY.WEIXIN.Web.App_Start
{
    public class CYPayFilterAttribute : ActionFilterAttribute
    {
       

        /// <summary>
        /// 在Action方法之前调用
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cyRedirct = filterContext.HttpContext.Request.Path;


            base.OnActionExecuting(filterContext);
        }
    }
}