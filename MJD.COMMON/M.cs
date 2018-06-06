using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

namespace MJD.COMMON
{
    public class DataTableUtility
    {
        /// <summary>  
        /// 将Datatable转换为List集合  
        /// </summary>  
        /// <typeparam name="T">类型参数</typeparam>  
        /// <param name="dt">datatable表</param>  
        /// <returns></returns>  
        public static List<T> DataTableToList<T>(DataTable dt)  
        {  
            var list = new List<T>();  
            Type t = typeof(T);  
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());  
        
            foreach (DataRow item in dt.Rows)  
            {  
                T s = System.Activator.CreateInstance<T>();  
                for (int i = 0; i < dt.Columns.Count; i++)  
                {  
                    PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);  
                    if (info != null)  
                    {  
                        if (!Convert.IsDBNull(item[i]))  
                        {  
                            info.SetValue(s, item[i], null);  
                        }  
                    }  
                }  
                list.Add(s);  
            }  
            return list;  
        }  
    }

    public class Pagination
    {
        public int total{get;set;}
        public int pageSize{get;set;}
        public int currentPage{get;set;}
    }

    public class rtData
    {
        public int errCode{get;private set;}
        public string errMsg{get;private set;}
        public Object list{get;set;}
        public Pagination pagination{get;set;}

        public rtData(MySqlRtMsg msg){
            errCode = msg.errCode;
            errMsg = msg.errMsg;
        }
    }
}