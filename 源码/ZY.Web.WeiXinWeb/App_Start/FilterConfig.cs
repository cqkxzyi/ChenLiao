using System.Web;
using System.Web.Mvc;

namespace ZY.Web.WeiXinWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
