
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZY.Util;

namespace CY.WEIXIN.Framework.WebApi.Utils
{
    /// <summary>
    /// 微信
    /// </summary>
    public static class WxHelper
    {
        public static string Appid = ConfigurationManager.AppSettings["MPAppId"];
        public static string AppSecrat = ConfigurationManager.AppSettings["MPAppSecret"];

        public static string CurrentUrl = ConfigurationManager.AppSettings["CurrentUrl"];
     
        /// <summary>
        /// snsapi_base方式获取Code
        /// </summary>
        private static string GetBaseCodeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri=https%3a%2f%2f" + CurrentUrl + "{1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect";
        /// <summary>
        /// snsapi_userinfo方式获取Code
        /// </summary>
        private static string GetUserinfoCodeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri=https%3a%2f%2f" + CurrentUrl + "{1}&response_type=code&scope=snsapi_userinfo&state={2}#wechat_redirect";
        /// <summary>
        /// 微信获取token URL
        /// </summary>
        public static string TokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        /// <summary>
        /// 微信授权 URL
        /// </summary>
        public static string GetTokenFormOauth2Url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
        /// <summary>
        /// 获取用户信息
        /// </summary>
        public static string GetUserInfoUrl = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";

        #region 封装用于获取Code的Url
        /// <summary>
        /// 封装用于获取Code的Url
        /// </summary>
        /// <param name="redirect_uri">要跳转的相对路径</param>
        /// <param name="type">1：snsapi_base方式，2：snsapi_userinfo</param>
        /// <returns></returns>
        public static string GetWxCodeUrl(string redirect_uri, int type)
        {
            string url = "";
            if (type == 1)
            {
                url = GetBaseCodeUrl;
            }
            else
            {
                url = GetUserinfoCodeUrl;
            }

            url = string.Format(url, Appid, redirect_uri, new Random().Next(1000, 200000).ToString());

            return url;
        }
        #endregion

        #region 通过OAuth 2.0 获取Token
        /// <summary>
        /// 通过OAuth 2.0 获取Token
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appsecret"></param>
        /// <param name="code"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static OAuth2Token GetOpenIdWithOAuth2(string code, out string error)
        {
            string msg = string.Empty;
            OAuth2Token ot = null;
            try
            {
                string url = string.Format(GetTokenFormOauth2Url, Appid, AppSecrat, code);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string json = sr.ReadToEnd();
                sr.Close();
                response.Close();
                ot = SerializeUtil.DeserializeJson<OAuth2Token>(json, true);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            error = msg;
            return ot;
        }
        #endregion

        #region 拉取用户信息
        /// <summary>
        /// 拉取用户信息
        /// </summary>
        public static WxUserInfo GetUserInfo(string access_token, string openid, out string error)
        {
            string msg = string.Empty;
            WxUserInfo userinfo = null;
            try
            {
                string url = string.Format(GetUserInfoUrl, access_token, openid);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string json = sr.ReadToEnd();
                sr.Close();
                response.Close();
                userinfo = SerializeUtil.DeserializeJson<WxUserInfo>(json, true);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            error = msg;
            return userinfo;
        }
        #endregion


    }
}
