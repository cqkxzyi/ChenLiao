using chinapaysecure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace CY.WEIXIN.Web.Helper
{
    public class ChinaPayHelper
    {
        #region 基础配置
        public static string merchantCode = "000001810292858"; //商户号

        private static string privateKeyPath = @"D:/code/CYXD/CY.ChinaPay/CY.ChinaPay/CY.ChinaPay/jiaoyi.pfx"; //私钥文件地址
        private static string privateKeyPwd = "qwe123";                    //私钥密码
        #endregion

        /// <summary>
        /// 签名，注意官方给出的签名方法，要求私钥必须是安装在服务器的，假若安装在本地测试机器上，等发布到生产环境中后会出现证书无法使用的错误
        /// </summary>
        /// <param name="param">需要加密的字符串</param>
        /// <returns></returns>
        public static string Sign(Hashtable myMap)
        {
            string param = sort(myMap, null);
            X509Certificate2 certificate = new X509Certificate2(privateKeyPath, privateKeyPwd);
            RSAParameters key = ((RSACryptoServiceProvider)certificate.PrivateKey).ExportParameters(true);
            return Convert.ToBase64String(HashAndSignBytes(Encoding.UTF8.GetBytes(param), key));
        }

        /// <summary>
        /// 构造提交表单
        /// </summary>
        /// <param name="myMap"></param>
        /// <param name="actionUrl"></param>
        /// <returns></returns>
        public static string BuildRequest(Hashtable myMap, string actionUrl)
        {
            StringBuilder sbHtml = new StringBuilder();
            sbHtml.Append("<form id='cpsubmit' name='cpsubmit' action='" + actionUrl + "' method='POST'>");
            foreach (DictionaryEntry de in myMap)
            {
                sbHtml.Append("<input type='hidden' name='" + de.Key.ToString() + "' value='" +de.Value.ToString() + "'/>");
            }
            //submit按钮控件请不要含有name属性
            sbHtml.Append("<input type='submit' value='CHINAPAY' style='display:none;'></form>");
            sbHtml.Append("<script>document.forms['cpsubmit'].submit();</script>");
            return sbHtml.ToString();
        }

        /// <summary>
        /// 构造提交表单
        /// </summary>
        /// <param name="myMap"></param>
        /// <param name="actionUrl"></param>
        /// <returns></returns>
        public static string BuildParaStr(Hashtable myMap)
        {
            List<string> lstParam = new List<string>();
         
            foreach (DictionaryEntry de in myMap)
            {
                lstParam.Add(de.Key.ToString() + "=" + System.Web.HttpUtility.UrlEncode(de.Value.ToString(), Encoding.UTF8) );
            }
            
            return lstParam.Aggregate((a,b)=>a+"&"+b);
        }


        /// <summary>
        /// 构造提交表单
        /// </summary>
        /// <param name="myMap"></param>
        /// <param name="actionUrl"></param>
        /// <returns></returns>
        public static string BuildParaStr2(Hashtable myMap)
        {
            List<string> lstParam = new List<string>();

            foreach (DictionaryEntry de in myMap)
            {
                lstParam.Add(de.Key.ToString() + "=" + de.Value.ToString());
            }

            return lstParam.Aggregate((a, b) => a + "&" + b);
        }

        /// <summary>
        /// 调用远程Restful服务
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="param">参数</param>
        /// <param name="time">超时时间</param>
        /// <returns></returns>
        public static string Post(string url, string param, int time = 60000)
        {
            Uri address = new Uri(url);
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8"; //"application/x-www-form-urlencoded";
            request.Timeout = time;
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(param == null ? "" : param);
            request.ContentLength = byteData.Length;

            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }
            string result = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadToEnd();
            }
            return (result);
        }

        /// <summary>
        /// 银联应答参数转换为哈希表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Hashtable Str2HashMap(string param)
        {
            string[] kv = param.Split('&');
            Hashtable map = new Hashtable();
            foreach (string str in kv)
            {
                string[] temp = str.Split('=');
                if (temp != null && temp.Length >= 2)
                {
                    string sValue = HttpUtility.UrlDecode(temp[1], Encoding.UTF8);
                    string sValue2 = HttpUtility.UrlDecode(sValue, Encoding.UTF8);
                    map.Add(temp[0],sValue2.Replace(" ","+"));
                }
            }
            return map;
        }

        /// <summary>
        /// 银联应答参数转换为哈希表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Hashtable Str2HashMap2(string param)
        {
            string[] kv = param.Split('&');
            Hashtable map = new Hashtable();
            foreach (string str in kv)
            {
                string[] temp = str.Split('=');
                if (temp != null && temp.Length >= 2)
                {
                    map.Add(temp[0], temp[1]);
                }
            }
            return map;
        }

        #region 以下方法ChinaPay
        private static byte[] HashAndSignBytes(byte[] DataToSign, RSAParameters Key)
        {
            try
            {
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.ImportParameters(Key);
                return provider.SignData(DataToSign, new SHA512CryptoServiceProvider());
            }
            catch (CryptographicException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public static string sort(Hashtable paramHashTable, string[] invalidList)
        {
            IDictionaryEnumerator enumerator = paramHashTable.GetEnumerator();
            ArrayList list = new ArrayList();
            while (enumerator.MoveNext())
            {
                string str = enumerator.Key.ToString();
                enumerator.Value.ToString();
                if (((invalidList == null) || (invalidList.Length <= 0)) || !invalidList.Contains<string>(str))
                {
                    list.Add(str);
                }
            }
            IComparer comparer = new myReverserClass();
            list.Sort(comparer);
            string str2 = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                string str3 = list[i].ToString();
                string str4 = paramHashTable[str3].ToString();
                if (i == (list.Count - 1))
                {
                    str2 = str2 + str3 + "=" + str4;
                }
                else
                {
                    string str5 = str2;
                    str2 = str5 + str3 + "=" + str4 + "&";
                }
            }
            StringBuilder builder = new StringBuilder(str2);
            return builder.ToString();
        }
        #endregion
    }
}