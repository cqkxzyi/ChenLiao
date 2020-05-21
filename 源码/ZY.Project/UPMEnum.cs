using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CY.UPM.ProjectComm
{
    /// <summary>
    /// 本系统所有枚举
    /// </summary>
    public class UPMEnum
    {

        #region 登录结果类型

        /// <summary>
        /// 登录结果类型
        /// </summary>
        public enum LoginResultType
        {
            /// <summary>
            /// 成功
            /// </summary>
            [Description("成功")]
            成功 = 2900001,

            /// <summary>
            /// 失败
            /// </summary>
            [Description("失败")]
            失败 = 2900002
        }

        #endregion 登录结果类型

        #region 发送验证码类型

        /// <summary>
        /// 发送验证码类型
        /// </summary>
        public enum SendMsgType
        {
            /// <summary>
            /// 密码修改
            /// </summary>
            [Description("密码修改")]
            密码修改 = 4400001,

            /// <summary>
            /// 其他
            /// </summary>
            [Description("其他")]
            其他 = 4400002
        }

        #endregion 发送验证码类型

        #region 注册来源

        /// <summary>
        /// 注册来源
        /// </summary>
        public enum RegistSource
        {
            /// <summary>
            /// 后台新增
            /// </summary>
            [Description("后台新增")]
            后台新增 = 3000001,

            /// <summary>
            /// pc端
            /// </summary>
            [Description("pc端")]
            pc端 = 3000002,

            /// <summary>
            /// 手机端
            /// </summary>
            [Description("手机端")]
            手机端 = 3000003,

            /// <summary>
            /// 官网
            /// </summary>
            [Description("官网")]
            官网 = 3000004
        }

        #endregion 注册来源

      
        #region 消息推送类型

        /// <summary>
        /// 消息推送类型
        /// </summary>
        public enum PushType
        {
            /// <summary>
            /// 所有
            /// </summary>
            [Description("所有")]
            所有 = 5000001,

            /// <summary>
            /// 手机短信
            /// </summary>
            [Description("手机短信")]
            手机短信 = 5000002,

            /// <summary>
            /// APP
            /// </summary>
            [Description("APP")]
            APP = 5000003,

            /// <summary>
            /// 微信文字
            /// </summary>
            [Description("微信文字")]
            微信文字 = 5000004,

            /// <summary>
            /// 微信图片
            /// </summary>
            [Description("微信图片")]
            微信图片 = 5000005
        }

        #endregion 消息推送类型


        #region Ajax请求执行状态枚举

        /// <summary>
        /// Ajax请求执行状态枚举（0:成功，1：未登录，2：系统错误，3：没有权限）
        /// </summary>
        public enum AjaxStatus
        {
            /// <summary>
            /// 成功
            /// </summary>
            [Description("成功")]
            Success = 0,

            /// <summary>
            /// 未登录
            /// </summary>
            [Description("未登录")]
            UnLogin = 1,

            /// <summary>
            /// 系统错误
            /// </summary>
            [Description("系统错误")]
            Error = 2,

            /// <summary>
            /// 没有权限
            /// </summary>
            [Description("没有权限")]
            NoPermission = 3
        }

        #endregion Ajax请求执行状态枚举

        #region HTTP状态码

        /// <summary>
        /// HTTP状态码
        /// SDK接口API将对每次请求返回以下错误码中的一种
        /// </summary>
        public enum HttpStatusCode
        {
            /// <summary>
            /// 执行成功!
            /// </summary>
            OK = 200,

            /// <summary>
            /// sign验证失败
            /// </summary>
            SignError = 201,

            /// <summary>
            /// 没有数据返回
            /// </summary>
            NotModified = 304,

            /// <summary>
            /// 请求数据不合法
            /// </summary>
            BadRequest = 400,

            /// <summary>
            /// 没有权限访问对应的资源
            /// </summary>
            Forbidden = 403,

            /// <summary>
            /// 请求的资源不存在
            /// </summary>
            NotFound = 404,

            /// <summary>
            /// 服务器内部错误
            /// </summary>
            InternalServerError = 500,

            /// <summary>
            /// 接口API关闭或正在升级
            /// </summary>
            BadGateway = 502,

            /// <summary>
            /// 服务端资源不可用
            /// </summary>
            ServiceUnavailable = 503,

            /// <summary>
            /// 解析响应数据出错
            /// </summary>
            MyServerError = 600
        }

        #endregion HTTP状态码

        #region 用户操作日志-业务类型

        /// <summary>
        /// 用户操作日志-业务类型
        /// </summary>
        public enum OperationObjectType
        {
            /// <summary>
            /// 所有
            /// </summary>
            [Description("所有")]
            所有 = -1,

            /// <summary>
            /// 账户管理
            /// </summary>
            [Description("账户管理")]
            账户管理 = 1,

            /// <summary>
            /// 菜单管理
            /// </summary>
            [Description("菜单管理")]
            菜单管理 = 2,

            /// <summary>
            /// 角色管理
            /// </summary>
            [Description("角色管理")]
            角色管理 = 3,

            /// <summary>
            /// 系统参数
            /// </summary>
            [Description("系统参数")]
            系统参数 = 4,

            /// <summary>
            /// 数据字典
            /// </summary>
            [Description("数据字典")]
            数据字典 = 5,

            /// <summary>
            /// 客户主表管理
            /// </summary>
            [Description("客户主表管理")]
            客户主表管理 = 6,

            /// <summary>
            /// 客户征信管理
            /// </summary>
            [Description("客户征信管理")]
            客户征信管理 = 7,

            /// <summary>
            /// 客户资产管理
            /// </summary>
            [Description("客户资产管理")]
            客户资产管理 = 8,

            /// <summary>
            /// 银行卡管理
            /// </summary>
            [Description("银行卡管理")]
            银行卡管理 = 9,

            /// <summary>
            /// 客源管理
            /// </summary>
            [Description("客源管理")]
            客源管理 = 10,

            /// <summary>
            /// 积分管理
            /// </summary>
            [Description("积分管理")]
            积分管理 = 11,

            /// <summary>
            /// 礼品管理
            /// </summary>
            [Description("礼品管理")]
            礼品管理 = 12,

            /// <summary>
            /// 兑换记录
            /// </summary>
            [Description("兑换记录")]
            兑换记录 = 13,

            /// <summary>
            /// 收入支出记录
            /// </summary>
            [Description("收入支出记录")]
            收入支出记录 = 14,

            /// <summary>
            /// 收货地址
            /// </summary>
            [Description("收货地址")]
            收货地址 = 15,

            /// <summary>
            /// 客户关系表管理
            /// </summary>
            [Description("客户关系表管理")]
            客户关系表管理 = 16

        }

        #endregion 

        #region 用户操作日志-动作类型

        /// <summary>
        /// 用户操作日志-动作类型
        /// </summary>
        public enum OperationActionType
        {
            /// <summary>
            /// 所有
            /// </summary>
            [Description("所有")]
            所有 = -1,

            /// <summary>
            /// 添加
            /// </summary>
            [Description("添加")]
            添加 = 1,

            /// <summary>
            /// 编辑
            /// </summary>
            [Description("编辑")]
            编辑 = 2,

            /// <summary>
            /// 删除
            /// </summary>
            [Description("删除")]
            删除 = 3,

            /// <summary>
            /// 分配角色
            /// </summary>
            [Description("分配角色")]
            分配角色 = 4,

            /// <summary>
            /// 分配用户
            /// </summary>
            [Description("分配用户")]
            分配用户 = 5,

            /// <summary>
            /// 分配权限
            /// </summary>
            [Description("分配权限")]
            分配权限 = 6,

            /// <summary>
            /// 审核
            /// </summary>
            [Description("审核")]
            审核 = 7,

            /// <summary>
            /// 更改状态
            /// </summary>
            [Description("更改状态")]
            更改状态 = 8,

            /// <summary>
            /// 导出
            /// </summary>
            [Description("导出")]
            导出 = 9
        }

        #endregion 用户操作日志-动作类型







        #region 根据值获取枚举描述信息

        /// <summary>
        /// 根据值获取枚举描述信息
        /// </summary>
        /// <param name="enumSubitem">枚举类</param>
        /// <param name="iValue">值</param>
        /// <returns></returns>
        public static string GetEnumDescription(Type enumSubitem, int iValue)
        {
            return GetEnumDescription(Enum.Parse(enumSubitem, iValue.ToString()));
        }

        /// <summary>
        /// 根据枚举获取描述信息
        /// </summary>
        /// <param name="enumSubitem">枚举项</param>
        /// <returns></returns>
        public static string GetEnumDescription(object enumSubitem)
        {
            FieldInfo fieldinfo = enumSubitem.GetType().GetField(enumSubitem.ToString());

            if (fieldinfo != null)
            {
                Object[] objs = fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (objs == null || objs.Length == 0)
                {
                    return enumSubitem.ToString();
                }
                else
                {
                    DescriptionAttribute da = (DescriptionAttribute)objs[0];
                    return da.Description;
                }
            }
            else
            {
                return "";
            }
        }

        #endregion 根据值获取枚举描述信息

        #region 根据枚举类型返回类型中的所有值，文本及描述

        /// <summary>
        /// 根据枚举类型返回类型中的所有值，文本及描述
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <returns></returns>
        public static List<string[]> GetEnumOption(Type type)
        {
            List<string[]> Strs = new List<string[]>();
            FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
            for (int i = 0, count = fields.Length; i < count; i++)
            {
                string[] strEnum = new string[3];
                FieldInfo field = fields[i];
                //值列
                strEnum[1] = ((int)Enum.Parse(type, field.Name)).ToString();
                //文本列赋值
                strEnum[2] = field.Name;

                object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs == null || objs.Length == 0)
                {
                    strEnum[0] = field.Name;
                }
                else
                {
                    DescriptionAttribute da = (DescriptionAttribute)objs[0];
                    strEnum[0] = da.Description;
                }

                Strs.Add(strEnum);
            }
            return Strs;
        }

        #endregion 根据枚举类型返回类型中的所有值，文本及描述




        #region 整套

        public enum RecruitingEnum
        {
            [EnumHelper.EnumDescription("全部")]
            全部 = 0,

            [EnumHelper.EnumDescription("选项A描述")]
            选项A = 1,

            [EnumHelper.EnumDescription("选项B描述")]
            选项B = 2
        }

        /// <summary>
        /// 枚举扩展附加属性
        /// </summary>
        public static class EnumHelper
        {
            #region 枚举扩展附加属性

            /// <summary>
            /// Provides a description for an enumerated type.
            /// </summary>
            [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
            public sealed class EnumDescriptionAttribute : Attribute
            {
                private string description;

                public string Description
                {
                    get { return this.description; }
                }

                /// <summary>
                /// Initializes a new instance of the class.
                /// </summary>
                /// <param name="description"></param>
                public EnumDescriptionAttribute(string description)
                    : base()
                {
                    this.description = description;
                }
            }

            #endregion 枚举扩展附加属性

            #region 获取单个枚举的描述信息

            /// <summary>
            /// 获取单个枚举的描述信息
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static string GetDescription(Enum value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                string description = value.ToString();
                FieldInfo fieldInfo = value.GetType().GetField(description);
                EnumDescriptionAttribute[] attributes =
                   (EnumDescriptionAttribute[])
                 fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    description = attributes[0].Description;
                }
                return description;
            }

            #endregion 获取单个枚举的描述信息
        }

        #endregion 整套
    }
}