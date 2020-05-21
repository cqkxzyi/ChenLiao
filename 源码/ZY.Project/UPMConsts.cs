using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CY.UPM.ProjectComm
{
    /// <summary>
    /// 本系统所有常量
    /// </summary>
    public static class UPMConsts
    {
        #region 权限码*********************

        #region 菜单权限管理
        /// <summary>
        /// 菜单权限管理
        /// </summary>
        public class ModuleManage
        {
            public const string Manage = "ModuleManage";
            public const string ModuleManage_Search = "ModuleManage_Search";
            public const string ModuleManage_Add = "ModuleManage_Add";
            public const string ModuleManage_Edit = "ModuleManage_Edit";
            public const string ModuleManage_Delete = "ModuleManage_Delete";
        }
        #endregion

        #region 用户管理
        /// <summary>
        /// 用户管理
        /// </summary>
        public class UsersManage
        {
            public const string Manage = "UsersManage";
            public const string UsersManage_Search = "UsersManage_Search";
            public const string UsersManage_Detail = "UsersManage_Detail";
            public const string UsersManage_Add = "UsersManage_Add";
            public const string UsersManage_Edit = "UsersManage_Edit";
            public const string UsersManage_Delete = "UsersManage_Delete";
            public const string UsersManage_PwdChange = "UsersManage_PwdChange";
            public const string UsersManage_Permission = "UsersManage_Permission";
        }
        #endregion

        #region 客户管理
        /// <summary>
        /// 客户管理
        /// </summary>
        public class CustomerInfoManage
        {
            public const string Manage = "CustomerInfoManage";
            public const string CustomerInfoManage_Search = "CustomerInfoManage_Search";
            public const string CustomerInfoManage_Detail = "CustomerInfoManage_Detail";
            public const string CustomerInfoManage_Add = "CustomerInfoManage_Add";
            public const string CustomerInfoManage_Edit = "CustomerInfoManage_Edit";
            public const string CustomerInfoManage_Delete = "CustomerInfoManage_Delete";
        }
        #endregion

        #region 客户征信管理
        /// <summary>
        /// 客户征信管理
        /// </summary>
        public class UserCreditManage
        {
            public const string Manage = "UserCreditManage";
            public const string UserCreditManage_Search = "UserCreditManage_Search";
            public const string UserCreditManage_Detail = "UserCreditManage_Detail";
            public const string UserCreditManage_Add = "UserCreditManage_Add";
            public const string UserCreditManage_Edit = "UserCreditManage_Edit";
            public const string UserCreditManage_Delete = "UserCreditManage_Delete";
        }
        #endregion

        #region 客户资产管理
        /// <summary>
        /// 客户资产管理
        /// </summary>
        public class UserAssetManage
        {
            public const string Manage = "UserAssetManage";
            public const string UserAssetManage_Search = "UserAssetManage_Search";
            public const string UserAssetManage_Detail = "UserAssetManage_Detail";
            public const string UserAssetManage_Add = "UserAssetManage_Add";
            public const string UserAssetManage_Edit = "UserAssetManage_Edit";
            public const string UserAssetManage_Delete = "UserAssetManage_Delete";
        }
        #endregion

        #region 银行卡管理
        /// <summary>
        /// 银行卡管理
        /// </summary>
        public class BankCardManage
        {
            public const string Manage = "BankCardManage";
            public const string BankCardManage_Search = "BankCardManage_Search";
            public const string BankCardManage_Detail = "BankCardManage_Detail";
            public const string BankCardManage_Add = "BankCardManage_Add";
            public const string BankCardManage_Edit = "BankCardManage_Edit";
            public const string BankCardManage_Delete = "BankCardManage_Delete";
        }
        #endregion

        #region 角色管理
        /// <summary>
        /// 角色管理
        /// </summary>
        public class RolesManage
        {
            public const string Manage = "RoleManage";
            public const string RolesManage_Search = "RolesManage_Search";
            public const string RolesManage_Add = "RolesManage_Add";
            public const string RolesManage_Edit = "RolesManage_Edit";
            public const string RolesManage_Delete = "RolesManage_Delete";
            public const string RolesManage_Permission = "RolesManage_Permission";
            public const string RolesManage_UserSearch = "RolesManage_UserSearch";
            public const string RolesManage_UserAdd = "RolesManage_UserAdd";
            public const string RolesManage_UserDelete = "RolesManage_UserDelete";
            public const string RolesManage_UserDeleteAll = "RolesManage_UserDeleteAll";
        }
        #endregion

        #region 系统参数操作权限
        /// <summary>
        /// 系统参数管理
        /// </summary>
        public class SysConfigManage
        {
            /// <summary>
            /// 管理系统参数
            /// </summary>
            public const string Manage = "SysConfigManage";
            /// <summary>
            /// 查询系统参数
            /// </summary>
            public const string SysConfigManage_Search = "SysConfigManage_Search";
            /// <summary>
            /// 新增系统参数
            /// </summary>
            public const string SysConfigManage_Add = "SysConfigManage_Add";
            /// <summary>
            /// 编辑系统参数
            /// </summary>
            public const string SysConfigManage_Edit = "SysConfigManage_Edit";
            /// <summary>
            /// 删除系统参数
            /// </summary>
            public const string SysConfigManage_Delete = "SysConfigManage_Delete";
        }
        #endregion 系统参数

        #region 数据字典操作权限
        /// <summary>
        /// 数据字典管理
        /// </summary>
        public class DataDictionaryManage
        {
            /// <summary>
            /// 管理数据字典
            /// </summary>
            public const string Manage = "DataDictionaryManage";
            /// <summary>
            /// 查询数据字典
            /// </summary>
            public const string DataDictionaryManage_Search = "DataDictionaryManage_Search";
            /// <summary>
            /// 新增数据字典
            /// </summary>
            public const string DataDictionaryManage_Add = "DataDictionaryManage_Add";
            /// <summary>
            /// 编辑数据字典
            /// </summary>
            public const string DataDictionaryManage_Edit = "DataDictionaryManage_Edit";
            /// <summary>
            /// 删除数据字典
            /// </summary>
            public const string DataDictionaryManage_Delete = "DataDictionaryManage_Delete";
        }
        #endregion

        #region 登录日志操作权限
        /// <summary>
        /// 登录日志权限管理
        /// </summary>
        public class LoginLogManage
        {
            /// <summary>
            /// 管理
            /// </summary>
            public const string Manage = "LoginLogManage";
            /// <summary>
            /// 查询
            /// </summary>
            public const string LoginLogManage_Search = "LoginLogManage_Search";
        }
        #endregion

        #region 操作日志操作权限
        /// <summary>
        /// 操作日志操作权限
        /// </summary>
        public class OperationLogManage
        {
            /// <summary>
            /// 管理
            /// </summary>
            public const string Manage = "OperationLogManage";
            /// <summary>
            /// 查询
            /// </summary>
            public const string OperationLogManage_Search = "OperationLogManage_Search";
        }
        #endregion

        #endregion



        #region 日志说明文本
        /// <summary>
        /// 日志说明文本
        /// </summary>
        public class UserOperationLogInfo
        {
            /// <summary>
            /// 普通操作
            /// </summary>
            public const string LS_CommonOperation = "用户【{0}】{1}【{2}】：ID为【{3}】，名称为【{4}】";

            /// <summary>
            /// 普通操作 信息为空
            /// </summary>
            public const string LS_CommonOperation_NoInfo = "用户【{0}】{1}【{2}】：ID为【{3}】";

            /// <summary>
            /// 为父对象进行某种操作
            /// </summary>
            public const string LS_RelationOperationLog = "用户【{0}】为{1}【{2}】{3}{4}：{5}";
        }
        #endregion


    }
}
