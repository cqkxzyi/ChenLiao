using CY.WEIXIN.Models.UPM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CY.WEIXIN.Web.App_Start
{


    public class BaseController : Controller
    {
        private UserModel user;
        public  UserModel BaseUser {
            get {

                var sUser= Session["admin"];
                if (sUser!=null)
                {
                    user = sUser as UserModel;
                }
                //else
                //{
                    
                //    user = new UserModel();
                //    user.MobilePhone = "18523672390";
                //    user.OpenID = "odhV602V6CTP6qy9ORVK1Qfl0YC4";
                //    user.ID = 14957;
                //    user.IsBorker = 1000001;
                //}

            
                return user;

               
            }
        }

    }

}