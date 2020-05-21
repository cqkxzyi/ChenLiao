using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CY.WEIXIN.Web.Helper
{
    public class BillNo
    {

        public static object _lock = new object();
        public static int count = 1;
        public static string CreateBillNo()
        {
            lock (_lock)
            {
                if (count >= 10000)
                {
                    count = 1;
                }
                var number = "P" + DateTime.Now.ToString("yyMMddHHmmss") + count.ToString("0000");
                count++;
                return number;
            }
        }
    }
}