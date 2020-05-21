using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CY.WEIXIN.Web.Helper
{
    public class POST_DATA
    {
        ///C#的提交表单方式主要有两种WebClient与HttpWebRequest
        ///

        ///webClient
        ///_url:提交数据网址
        ///_data:提交数据
        public static string WC_Post(string _url, string _data)
        {
            string postString = _data;//这里即为传递的参数，可以用工具抓包分析，也可以自己分析，主要是form里面每一个name都要加进来  "arg1=a&arg2=b"
            byte[] postData = Encoding.UTF8.GetBytes(postString);//编码，尤其是汉字，事先要看下抓取网页的编码方式  
            string url = _url;//地址  
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可  
            byte[] responseData = webClient.UploadData(url, "POST", postData);//得到返回字符流  
            string srcString = Encoding.UTF8.GetString(responseData);//解码 

            return srcString;
        }
        ///

        #region
        // HttpWebRequest以及HttpWebResponse

        //自认为与上次介绍的WebClient最大的不同之处在于HttpWebRequest更灵活，也更强大，比如，HttpWebRequest支持Cookie，而WebClient就不支持，因此，如果要登录某个网站才能进行某些操作的时候，HttpWebResponse就派上用场了。

        //补充：

        //WebClient是可以操作Cookie的，因为 Cookie本质上就是个字符串，只要服务器返回的头是“SetCooie:xxx”，所以，按照返回的格式做下处理（不能原样返回，具体可以抓包分析下 格式），存起来，然后在HTTP请求头上加上“Cookie:xxx”即可

        //首先要提下Referer还有Cookie

        //Referer：就是一般在浏览器中发送Http请求时带的头信息，被广泛用来统计点击信息，即从那个点击而来，所以有些网站也会用这个性质来防盗链，很多时候如果什么图片仅限内部交流之类的，就是用了这个原理。

        //Cookie：某些网站为了辨别用户身 份、进行session跟踪而储存在用户本地终端上的数据（通常经过加密），通常大家登录的时候就要用到它，登录后，网站会储存一个Cookie的东西在 本地计算机上，然后每次访问网站时，便会把这个网站的Cookie也一并发送过去，服务器就凭借这个来确认你的身份。它是个重要信息，有些黑客也会通过盗 取Cookie的方式来侵入你的账户。
        #endregion
        public static string HWR_Post(string _url, string _referer, string _data)
        {
         
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);  //url:"POST请求的地址"
            request.CookieContainer = new CookieContainer();
            CookieContainer cookie = request.CookieContainer;//如果用不到Cookie，删去即可  
            //以下是发送的http头，随便加，其中referer挺重要的，有些网站会根据这个来反盗链  
            request.Referer = _referer;  //referer:http://localhost/index.php
            request.Accept = "Accept:text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
            request.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";
            request.UserAgent = "User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
            request.KeepAlive = true;
            //上面的http头看情况而定，但是下面俩必须加  
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            Encoding encoding = Encoding.UTF8;//根据网站的编码自定义  
            byte[] postData = encoding.GetBytes(_data);//data即为发送的数据，格式还是和上次说的一样  
            request.ContentLength = postData.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postData, 0, postData.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            //如果http头中接受gzip的话，这里就要判断是否为有压缩，有的话，直接解压缩即可  
            if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
            {
                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            }

            StreamReader streamReader = new StreamReader(responseStream, encoding);
            string retString = streamReader.ReadToEnd();

            streamReader.Close();
            responseStream.Close();

            return retString;
        }
    }
}