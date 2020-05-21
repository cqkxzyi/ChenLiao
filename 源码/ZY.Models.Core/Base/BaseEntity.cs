using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCode;
using System.Reflection;
using System.Data;
using System.Xml.Serialization;
using ZY.Util;

namespace ZY.Models.Base
{
    public class BaseEntity<TEntity> : Entity<TEntity> where TEntity : BaseEntity<TEntity>, new()
    {

        #region 获取列表

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="whereClause">查询条件</param>
        /// <param name="orderClause">排序字段</param>
        /// <param name="selectClause">返回字段</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">每页数量</param>
        /// <returns></returns>
        public static IList<TEntity> GetList(string whereClause, string orderClause, string selectClause, int PageIndex, int PageSize)
        {
            return FindAll(whereClause, orderClause, selectClause, (PageIndex - 1) * PageSize, PageSize);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="whereClause">查询条件</param>
        /// <param name="orderClause">排序字段</param>
        /// <param name="selectClause">返回字段</param>
        /// <param name="PageIndex">页码(从1开始)</param>
        /// <param name="PageSize">每页数量</param>
        /// <param name="PageCount">总数</param>
        /// <returns></returns>
        public static IList<TEntity> GetList(string whereClause, string orderClause, string selectClause, int PageIndex, int PageSize, out int iCount)
        {
            iCount = FindCount(whereClause, "", "", 0, 0);
            return FindAll(whereClause, orderClause, selectClause, (PageIndex - 1) * PageSize, PageSize);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        public static IList<TEntity> SearchByObj(int PagerIndex, int PagerSize, ref int PageCount, ref int RecordCount, string whereSql, string orderby)
        {
            int count = 0;
            IList<TEntity> lTEntity = null;
            try
            {
                count = FindCount(whereSql, null, null, 0, 0);
                RecordCount = count;
                PageCount = GetPageCount(count, PagerSize);
                lTEntity = FindAll(whereSql, orderby, null, (PagerIndex - 1) * PagerSize, PagerSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lTEntity;
        }

        #endregion

        #region 获取总页数
        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="totalCount">总数据条数</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        protected static int GetPageCount(int totalCount, int pageSize)
        {
            if (totalCount == 0 || pageSize == 0)
            {
                return 1;
            }
            return totalCount % pageSize == 0 ? totalCount / pageSize : totalCount / pageSize + 1;
        }
        #endregion

        #region 返回正确的页码数(因为：数据库一共只有10页，而用户输入了11，此时就需要返回10为正确页码数)
        /// <summary>
        /// 返回正确的页码数(数据库只有10页，而用户输入了11，此时就需要返回10为正确页码数)
        /// </summary>
        /// <param name="countSum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static int GetPageCount(int countSum, int PageSize, int pageIndex)
        {
            int pageCount = countSum % PageSize == 0 ? countSum / PageSize : (countSum / PageSize + 1);

            //输入的页码大于最大页数时，等同于访问最后一页
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }
            return pageIndex;
        }

        /// <summary>
        /// 参数中特殊字符替换
        /// </summary>
        /// <param name="iSql"></param>
        /// <returns></returns>
        protected static String SafeSql(String iSql)
        {
            if (String.IsNullOrEmpty(iSql))
            {
                return "";
            }
            return iSql.Replace("'", "''").Replace("%", @"\%").Trim();
        }
        #endregion


        #region 判断字段是否存在某值
        /// <summary>
        /// 判断字段是否存在某值
        /// </summary>
        /// <param name="whereClause">where条件</param>
        /// <param name="sField">字段名</param>
        /// <param name="sValue">值</param>
        /// <param name="id">排除本身ID</param>
        /// <param name="sValueIsNumber">值是否是数字</param>
        /// <returns></returns>
        public static bool IsExists(string whereClause, string sField, string sValue, Int64 id = 0, bool sValueIsNumber = false)
        {
            StringBuilder sql = new StringBuilder();

            if (sValueIsNumber)
            {
                sql.Append(" and " + sField + " = " + sValue);
            }
            else
            {
                sql.Append(" and " + sField + " = '" + sValue + "'");
            }

            if (id > 0)
            {
                sql.Append(" and ID != " + id);
            }

            if (string.IsNullOrEmpty(whereClause))
            {
                whereClause = "1 = 1";
            }
            return Find(whereClause + sql.ToString()) != null;
        }

        /// <summary>
        /// 联合判断字段是否存在某值
        /// </summary>
        /// <param name="whereClause">where条件</param>
        /// <param name="sField">字段名数组</param>
        /// <param name="sValue">值数组</param>
        /// <param name="id">排除本身ID</param>
        /// <returns></returns>
        public static bool IsExists(string whereClause, string[] sField, string[] sValue, Int64 id = 0)
        {
            StringBuilder sql = new StringBuilder();

            for (int i = 0; i < sField.Count(); i++)
            {
                sql.Append(" and " + sField[i] + " = '" + sValue[i] + "'");
            }


            if (id > 0)
            {
                sql.Append(" and ID != " + id);
            }

            if (string.IsNullOrEmpty(whereClause))
            {
                whereClause = "1 = 1";
            }
            return Find(whereClause + sql.ToString()) != null;
        }

        #endregion



        #region 
        /// <summary>
        /// 递归获取数据
        /// </summary>
        /// <param name="ParentID">第一个父ID</param>
        /// <param name="Result">结果</param>
        /// <param name="lTreeSource">数据源源</param>
        /// <param name="SortFieldName">排序字段名</param>
        /// <param name="ParentFileName">父ID名</param>
        public static void TreeSort(long ParentID, List<TEntity> Result, List<TEntity> lTreeSource, string SortFieldName, string ParentFileName)
        {
            List<TEntity> lTree = new List<TEntity>();

            lTree = lTreeSource.FindAll(p => ConvertHelper.SafeCastInt(GetValue(p, ParentFileName),0) == ParentID);
            lTree.Sort(new TreeComparer(SortFieldName));
            foreach (var item in lTree)
            {
                Result.Add(item);
                lTreeSource.Remove(item);
                TreeSort(ConvertHelper.SafeCastInt(GetValue(item, "ID"),0), Result, lTreeSource, SortFieldName, ParentFileName);
            }
        }

        public static object GetValue(TEntity t, string FileName)
        {
            return t[FileName];
        }

        /// <summary>
        /// 自定义排序比较器
        /// </summary>
        public class TreeComparer : IComparer<TEntity>
        {
            /// <summary>
            /// 排序字段
            /// </summary>
            public readonly string SortFieldName;

            public TreeComparer(string sortFieldName)
            {
                this.SortFieldName = sortFieldName;
            }

            public int Compare(TEntity x, TEntity y)
            {
                int x_SortCode = ConvertHelper.SafeCastInt(GetValue(x, SortFieldName),0);
                int y_SortCode = ConvertHelper.SafeCastInt(GetValue(y, SortFieldName),0);

                if (x_SortCode > y_SortCode)
                    return 1;
                else if (x_SortCode == y_SortCode)
                    return 0;
                else
                    return -1;
            }
        }

        #endregion

        #region 将对象中的string类型的字符串过滤掉非法sql字符（‘变成’ %变成\%）一般用于查询中实体传递时
        /// <summary>
        /// 将对象中的string类型的字符串过滤掉非法sql字符（‘变成’ %变成\%）一般用于查询中实体传递时
        /// </summary>
        /// <param name="obj">实体</param>
        /// <returns>可以安全用于查询的实体</returns>
        public static TEntity SafeObjToSql(TEntity obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] infos = type.GetProperties();
            foreach (PropertyInfo info in infos)
            {

                if (info.PropertyType == typeof(string))
                {
                    if (info.CanWrite == false)
                    {
                        continue;
                    }
                    var value = info.GetValue(obj, null);
                    if (value != null)
                    {
                        if (!string.IsNullOrWhiteSpace(value.ToString()))
                        {
                            info.SetValue(obj, SafeSql(value.ToString().Trim()), null);
                        }
                    }
                }

            }
            return obj;
        }
        #endregion

        public static string ToStringForSafeSQL(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ListToString<T>(IEnumerable<T> list)
        {
            if (list.Count() == 0)
            {
                return "''";
            }
            StringBuilder ids = new StringBuilder();
            foreach (var item in list)
            {
                ids.AppendFormat("'{0}',", item);
            }
            return ids.ToString().Trim(',');
        }

        public static string SqlBuild(string TableName, string select = "*", string where = " IsDelete=0 ", string PartSqlWhere = " and 1=1 ")
        {
            string sql = string.Format("select {0} from {1} where {2} {3}", select, TableName, where, PartSqlWhere);
            return sql;
        }



    }

}
