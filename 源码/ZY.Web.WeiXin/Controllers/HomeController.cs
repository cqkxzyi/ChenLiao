using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZY.Models.EntityModel;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SysBrowsinglog log = new SysBrowsinglog()
            {
                BigType = 1,
                Ip = "127.0.0.1",
                OperationID = 123,
                OperationTime = DateTime.Now
            };
            int result = log.Save();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}