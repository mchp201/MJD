using System;
using System.Collections.Generic;
using System.Data;
using MJD.MODEL;

namespace MJD.DAL
{
    public class D_WEBADD
    {
        private string procName = "`MJD`.`PWEBADD`";
        public MJD.COMMON.MySqlRtMsg Add(M_WEBADD model){

            List<MJD.COMMON.MySqlPara> pArr = new List<MJD.COMMON.MySqlPara>();
            pArr.Add(new MJD.COMMON.MySqlPara("T",  ParameterDirection.Input, DbType.String, "TWEBADD_ADD"));
            pArr.Add(new MJD.COMMON.MySqlPara("ID", ParameterDirection.Input, DbType.Int32, model.ID));
            pArr.Add(new MJD.COMMON.MySqlPara("UName", ParameterDirection.Input, DbType.String, model.UName));
            pArr.Add(new MJD.COMMON.MySqlPara("UCardid", ParameterDirection.Input, DbType.String, model.UCardid));
            pArr.Add(new MJD.COMMON.MySqlPara("UTelenum", ParameterDirection.Input, DbType.String, model.UTelenum));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateTime", ParameterDirection.Input, DbType.Int64, model.CreateTime));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateIP", ParameterDirection.Input, DbType.String, model.CreateIP));
            pArr.Add(new MJD.COMMON.MySqlPara("Status", ParameterDirection.Input, DbType.Int32, model.Status));
            
            pArr.Add(new MJD.COMMON.MySqlPara("pageSize", ParameterDirection.InputOutput, DbType.Int32, model.pageSize));
            pArr.Add(new MJD.COMMON.MySqlPara("currentPage", ParameterDirection.InputOutput, DbType.Int32, model.currentPage));
            return MJD.COMMON.MYSQLHELPER.ExecuteNonQueryProcedure(procName, pArr.ToArray());
        }

        public DataSet GetAll(M_WEBADD model, ref MJD.COMMON.MySqlRtMsg rtObj){

            List<MJD.COMMON.MySqlPara> pArr = new List<MJD.COMMON.MySqlPara>();
            pArr.Add(new MJD.COMMON.MySqlPara("T",  ParameterDirection.Input, DbType.String, "TWEBADD_GETALL"));
            pArr.Add(new MJD.COMMON.MySqlPara("ID", ParameterDirection.Input, DbType.Int32, model.ID));
            pArr.Add(new MJD.COMMON.MySqlPara("UName", ParameterDirection.Input, DbType.String, model.UName));
            pArr.Add(new MJD.COMMON.MySqlPara("UCardid", ParameterDirection.Input, DbType.String, model.UCardid));
            pArr.Add(new MJD.COMMON.MySqlPara("UTelenum", ParameterDirection.Input, DbType.String, model.UTelenum));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateTime", ParameterDirection.Input, DbType.Int64, model.CreateTime));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateIP", ParameterDirection.Input, DbType.String, model.CreateIP));
            pArr.Add(new MJD.COMMON.MySqlPara("Status", ParameterDirection.Input, DbType.Int32, model.Status));

            return MJD.COMMON.MYSQLHELPER.ExecuteQueryProcedure(procName, ref rtObj, pArr.ToArray());
        }

        public DataSet GetPagination(M_WEBADD model, ref MJD.COMMON.MySqlRtMsg rtObj){

            List<MJD.COMMON.MySqlPara> pArr = new List<MJD.COMMON.MySqlPara>();
            pArr.Add(new MJD.COMMON.MySqlPara("T",  ParameterDirection.Input, DbType.String, "TWEBADD_PAGINATION"));
            pArr.Add(new MJD.COMMON.MySqlPara("ID", ParameterDirection.Input, DbType.Int32, model.ID));
            pArr.Add(new MJD.COMMON.MySqlPara("UName", ParameterDirection.Input, DbType.String, model.UName));
            pArr.Add(new MJD.COMMON.MySqlPara("UCardid", ParameterDirection.Input, DbType.String, model.UCardid));
            pArr.Add(new MJD.COMMON.MySqlPara("UTelenum", ParameterDirection.Input, DbType.String, model.UTelenum));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateTime", ParameterDirection.Input, DbType.Int64, model.CreateTime));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateIP", ParameterDirection.Input, DbType.String, model.CreateIP));
            pArr.Add(new MJD.COMMON.MySqlPara("Status", ParameterDirection.Input, DbType.Int32, model.Status));

            pArr.Add(new MJD.COMMON.MySqlPara("pageSize", ParameterDirection.InputOutput, DbType.Int32, model.pageSize));
            pArr.Add(new MJD.COMMON.MySqlPara("currentPage", ParameterDirection.InputOutput, DbType.Int32, model.currentPage));

            DataSet ds = MJD.COMMON.MYSQLHELPER.ExecuteQueryProcedure(procName, ref rtObj, pArr.ToArray());
            return ds;

        }
    }
}
