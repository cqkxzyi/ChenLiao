using System;
using System.Configuration;

namespace CY.UPM.ProjectComm
{
    /// <summary>
    /// 本系统所有config配置
    /// </summary>
    public class UPMConfig
    {
        /// <summary>
        /// 接口是否验证sign
        /// </summary>
        public static bool IsValidateSign { get { return SafeCastBool(GetConfigValueByKey("IsValidateSign", "false"), false); } }


        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DBStr { get { return GetConfigValueByKey("DBStr", ""); } }

        /// <summary>
        /// 每页记录条数
        /// </summary>
        public static int PageSize { get { return SafeCastInt(GetConfigValueByKey("PageSize", "10")); } }

        /// <summary>
        /// 默认日志路径
        /// </summary>
        public static string LogPath { get { return GetConfigValueByKey("LogPath", "/Log"); } }

        /// <summary>
        /// 上传地址根域名（本系统未用）
        /// </summary>
        public static string UploadDomain { get { return GetConfigValueByKey("UploadDomain", ""); } }

        /// <summary>
        /// 图片上传根路径（本系统未用）
        /// </summary>
        public static string ImgUploadPath { get { return GetConfigValueByKey("ImgUploadPath", "/UploadImg/"); } }

        /// <summary>
        /// 上传服务器地址
        /// </summary>
        public static string FILE_FASTDFS_POST_SERVER_URL = GetConfigValueByKey("FILE_FASTDFS_POST_SERVER_URL", "");

        /// <summary>
        /// 服务器图片展示域名
        /// </summary>
        public static string FILE_FASTDFS_GET_URL = GetConfigValueByKey("FILE_FASTDFS_GET_URL", "");

        /// <summary>
        /// 允许上传的图片格式
        /// </summary>
        public static string UploadImageType { get { return GetConfigValueByKey("UploadImageType", "jpg,jpeg,png"); } }

        /// <summary>
        /// 图片大小(单位：kb)
        /// </summary>
        public static int ImageMaxSize { get { return SafeCastInt(GetConfigValueByKey("ImageMaxSize", "1000")); } }

        /// <summary>
        /// 临时文件上传根路径
        /// </summary>
        public static string TempFileUploadPath { get { return GetConfigValueByKey("TempFileUploadPath", "/UploadFile/TempFile/"); } }

        /// <summary>
        /// 允许上传的文件格式
        /// </summary>
        public static string UploadFileType { get { return GetConfigValueByKey("UploadFileType", "xls,xlsx,doc,docx"); } }

        /// <summary>
        /// 文件上传根路径
        /// </summary>
        public static string FileUploadPath { get { return GetConfigValueByKey("FileUploadPath", "/UploadFile/"); } }

        /// <summary>
        /// 文件大小(单位：kb)
        /// </summary>
        public static int FileMaxSize { get { return SafeCastInt(GetConfigValueByKey("FileMaxSize", "5000")); } }

        /// <summary>
        /// 超级管理员
        /// </summary>
        public static string SupAdminAccountName { get { return "admin"; } }

        /// <summary>
        /// 本站域名
        /// </summary>
        public static string CurrentUrl { get { return GetConfigValueByKey("CurrentUrl", ""); } }




        /// <summary>
        /// 微信MPAppId
        /// </summary>
        public static string MPAppId = GetConfigValueByKey("MPAppId", "");

        /// <summary>
        /// 微信MPAppSecret
        /// </summary>
        public static string MPAppSecret = GetConfigValueByKey("MPAppSecret", "");
        /// <summary>
        /// 微信MPToken
        /// </summary>
        public static string MPToken = GetConfigValueByKey("MPToken", "");


        #region 从Config中根据Key取得对应的值

        /// <summary>
        /// 从Config中根据Key取得对应的值
        /// </summary>
        /// <param name="iKey">键</param>
        /// <param name="iDefaultValue">默认值</param>
        /// <returns>值</returns>
        public static string GetConfigValueByKey(string iKey, string iDefaultValue)
        {
            try
            {
                string mValue = ConfigurationManager.AppSettings[iKey]?.ToString();
                if (string.IsNullOrEmpty(mValue))
                {
                    return iDefaultValue;
                }
                return mValue;
            }
            catch (Exception)
            {
                return iDefaultValue;
            }
        }

        #endregion 从Config中根据Key取得对应的值

        #region 转换类

        /// <summary>
        /// 将Object类型数据安全转换为Int类型数据
        /// </summary>
        /// <param name="objInt">Object类型数据</param>
        /// <returns>返回Int类型数据（转换失败，默认值为0）</returns>
        public static int SafeCastInt(object objInt)
        {
            return SafeCastInt(objInt, 0);
        }

        /// <summary>
        /// 将Object类型数据安全转换为Int类型数据
        /// </summary>
        /// <param name="objInt">Object类型数据</param>
        /// <param name="nDefault">转换失败默认值</param>
        /// <returns>返回Int类型数据</returns>
        public static int SafeCastInt(object objInt, int nDefault)
        {
            int nValue = nDefault;

            try
            {
                nValue = Int32.Parse(objInt.ToString());
            }
            catch (Exception)
            {
                nValue = nDefault;
            }

            return nValue;
        }

        /// <summary>
        /// 将Object类型数据安全转换为Bool类型数据
        /// </summary>
        /// <param name="objBool">Object类型数据</param>
        /// <param name="bDefault">转换失败默认值</param>
        /// <returns>返回Bool类型数据</returns>
        public static bool SafeCastBool(object objBool, bool bDefault)
        {
            bool bValue = bDefault;

            try
            {
                bValue = bool.Parse(objBool.ToString());
            }
            catch (Exception)
            {
                bValue = bDefault;
            }

            return bValue;
        }

        #endregion 转换类
    }
}