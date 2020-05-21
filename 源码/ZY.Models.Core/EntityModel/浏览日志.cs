using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace ZY.Models.EntityModel
{
    /// <summary>浏览日志</summary>
    [Serializable]
    [DataObject]
    [Description("浏览日志")]
    [BindTable("SYS_BrowsingLog", Description = "浏览日志", ConnName = "MSSQL", DbType = DatabaseType.SqlServer)]
    public partial class SysBrowsinglog : ISysBrowsinglog
    {
        #region 属性
        private Int64 _ID;
        /// <summary>主键ID</summary>
        [DisplayName("主键ID")]
        [Description("主键ID")]
        [DataObjectField(true, true, false, 19)]
        [BindColumn("ID", "主键ID", "bigint")]
        public Int64 ID { get => _ID; set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } } }

        private Int32 _BigType;
        /// <summary>大类（枚举值）</summary>
        [DisplayName("大类")]
        [Description("大类（枚举值）")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("BigType", "大类（枚举值）", "int")]
        public Int32 BigType { get => _BigType; set { if (OnPropertyChanging(__.BigType, value)) { _BigType = value; OnPropertyChanged(__.BigType); } } }

        private Int32 _SmallType;
        /// <summary>小类（枚举值）</summary>
        [DisplayName("小类")]
        [Description("小类（枚举值）")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn("SmallType", "小类（枚举值）", "int")]
        public Int32 SmallType { get => _SmallType; set { if (OnPropertyChanging(__.SmallType, value)) { _SmallType = value; OnPropertyChanged(__.SmallType); } } }

        private String _Url;
        /// <summary>链接Url</summary>
        [DisplayName("链接Url")]
        [Description("链接Url")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn("Url", "链接Url", "varchar(1000)")]
        public String Url { get => _Url; set { if (OnPropertyChanging(__.Url, value)) { _Url = value; OnPropertyChanged(__.Url); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 1000)]
        [BindColumn("Remark", "备注", "nvarchar(1000)")]
        public String Remark { get => _Remark; set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } } }

        private String _Ip;
        /// <summary>操作者IP</summary>
        [DisplayName("操作者IP")]
        [Description("操作者IP")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("Ip", "操作者IP", "nvarchar(100)")]
        public String Ip { get => _Ip; set { if (OnPropertyChanging(__.Ip, value)) { _Ip = value; OnPropertyChanged(__.Ip); } } }

        private String _Mac;
        /// <summary>操作者Mac</summary>
        [DisplayName("操作者Mac")]
        [Description("操作者Mac")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("Mac", "操作者Mac", "nvarchar(100)")]
        public String Mac { get => _Mac; set { if (OnPropertyChanging(__.Mac, value)) { _Mac = value; OnPropertyChanged(__.Mac); } } }

        private Int64 _OperationID;
        /// <summary>操作者ID</summary>
        [DisplayName("操作者ID")]
        [Description("操作者ID")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn("OperationID", "操作者ID", "bigint")]
        public Int64 OperationID { get => _OperationID; set { if (OnPropertyChanging(__.OperationID, value)) { _OperationID = value; OnPropertyChanged(__.OperationID); } } }

        private String _OperationAccountName;
        /// <summary>操作者名称</summary>
        [DisplayName("操作者名称")]
        [Description("操作者名称")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn("OperationAccountName", "操作者名称", "nvarchar(100)")]
        public String OperationAccountName { get => _OperationAccountName; set { if (OnPropertyChanging(__.OperationAccountName, value)) { _OperationAccountName = value; OnPropertyChanged(__.OperationAccountName); } } }

        private DateTime _OperationTime;
        /// <summary>操作时间</summary>
        [DisplayName("操作时间")]
        [Description("操作时间")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn("OperationTime", "操作时间", "datetime", Precision = 0, Scale = 3)]
        public DateTime OperationTime { get => _OperationTime; set { if (OnPropertyChanging(__.OperationTime, value)) { _OperationTime = value; OnPropertyChanged(__.OperationTime); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.ID: return _ID;
                    case __.BigType: return _BigType;
                    case __.SmallType: return _SmallType;
                    case __.Url: return _Url;
                    case __.Remark: return _Remark;
                    case __.Ip: return _Ip;
                    case __.Mac: return _Mac;
                    case __.OperationID: return _OperationID;
                    case __.OperationAccountName: return _OperationAccountName;
                    case __.OperationTime: return _OperationTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID: _ID = value.ToLong(); break;
                    case __.BigType: _BigType = value.ToInt(); break;
                    case __.SmallType: _SmallType = value.ToInt(); break;
                    case __.Url: _Url = Convert.ToString(value); break;
                    case __.Remark: _Remark = Convert.ToString(value); break;
                    case __.Ip: _Ip = Convert.ToString(value); break;
                    case __.Mac: _Mac = Convert.ToString(value); break;
                    case __.OperationID: _OperationID = value.ToLong(); break;
                    case __.OperationAccountName: _OperationAccountName = Convert.ToString(value); break;
                    case __.OperationTime: _OperationTime = value.ToDateTime(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得浏览日志字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>主键ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            /// <summary>大类（枚举值）</summary>
            public static readonly Field BigType = FindByName(__.BigType);

            /// <summary>小类（枚举值）</summary>
            public static readonly Field SmallType = FindByName(__.SmallType);

            /// <summary>链接Url</summary>
            public static readonly Field Url = FindByName(__.Url);

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            /// <summary>操作者IP</summary>
            public static readonly Field Ip = FindByName(__.Ip);

            /// <summary>操作者Mac</summary>
            public static readonly Field Mac = FindByName(__.Mac);

            /// <summary>操作者ID</summary>
            public static readonly Field OperationID = FindByName(__.OperationID);

            /// <summary>操作者名称</summary>
            public static readonly Field OperationAccountName = FindByName(__.OperationAccountName);

            /// <summary>操作时间</summary>
            public static readonly Field OperationTime = FindByName(__.OperationTime);

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得浏览日志字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>主键ID</summary>
            public const String ID = "ID";

            /// <summary>大类（枚举值）</summary>
            public const String BigType = "BigType";

            /// <summary>小类（枚举值）</summary>
            public const String SmallType = "SmallType";

            /// <summary>链接Url</summary>
            public const String Url = "Url";

            /// <summary>备注</summary>
            public const String Remark = "Remark";

            /// <summary>操作者IP</summary>
            public const String Ip = "Ip";

            /// <summary>操作者Mac</summary>
            public const String Mac = "Mac";

            /// <summary>操作者ID</summary>
            public const String OperationID = "OperationID";

            /// <summary>操作者名称</summary>
            public const String OperationAccountName = "OperationAccountName";

            /// <summary>操作时间</summary>
            public const String OperationTime = "OperationTime";
        }
        #endregion
    }

    /// <summary>浏览日志接口</summary>
    public partial interface ISysBrowsinglog
    {
        #region 属性
        /// <summary>主键ID</summary>
        Int64 ID { get; set; }

        /// <summary>大类（枚举值）</summary>
        Int32 BigType { get; set; }

        /// <summary>小类（枚举值）</summary>
        Int32 SmallType { get; set; }

        /// <summary>链接Url</summary>
        String Url { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>操作者IP</summary>
        String Ip { get; set; }

        /// <summary>操作者Mac</summary>
        String Mac { get; set; }

        /// <summary>操作者ID</summary>
        Int64 OperationID { get; set; }

        /// <summary>操作者名称</summary>
        String OperationAccountName { get; set; }

        /// <summary>操作时间</summary>
        DateTime OperationTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}