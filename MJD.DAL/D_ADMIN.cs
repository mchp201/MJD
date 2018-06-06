using System;
using System.Collections.Generic;
using System.Data;
using MJD.MODEL;

namespace MJD.DAL
{
    public class D_ADMIN
    {
        private string procName = "`MJD`.`PADMIN`";
        public MJD.COMMON.MySqlRtMsg Add(M_ADMIN model){

            List<MJD.COMMON.MySqlPara> pArr = new List<MJD.COMMON.MySqlPara>();
            pArr.Add(new MJD.COMMON.MySqlPara("T",  ParameterDirection.Input, DbType.String, "TADMIN_ADD"));
            pArr.Add(new MJD.COMMON.MySqlPara("ID", ParameterDirection.Input, DbType.Int32, model.ID));
            pArr.Add(new MJD.COMMON.MySqlPara("RID", ParameterDirection.Input, DbType.Int32, model.RID));
            pArr.Add(new MJD.COMMON.MySqlPara("Name", ParameterDirection.Input, DbType.String, model.Name));
            pArr.Add(new MJD.COMMON.MySqlPara("TeleNum", ParameterDirection.Input, DbType.String, model.TeleNum));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateTime", ParameterDirection.Input, DbType.Int64, model.CreateTime));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateIP", ParameterDirection.Input, DbType.String, model.CreateIP));
            pArr.Add(new MJD.COMMON.MySqlPara("Status", ParameterDirection.Input, DbType.Int32, model.Status));
            
            pArr.Add(new MJD.COMMON.MySqlPara("pageSize", ParameterDirection.InputOutput, DbType.Int32, model.pageSize));
            pArr.Add(new MJD.COMMON.MySqlPara("currentPage", ParameterDirection.InputOutput, DbType.Int32, model.currentPage));
            return MJD.COMMON.MYSQLHELPER.ExecuteNonQueryProcedure(procName, pArr.ToArray());
        }

        public DataSet GetAll(M_ADMIN model, ref MJD.COMMON.MySqlRtMsg rtObj){

            List<MJD.COMMON.MySqlPara> pArr = new List<MJD.COMMON.MySqlPara>();
            pArr.Add(new MJD.COMMON.MySqlPara("T",  ParameterDirection.Input, DbType.String, "TADMIN_GETALL"));
            pArr.Add(new MJD.COMMON.MySqlPara("ID", ParameterDirection.Input, DbType.Int32, model.ID));
            pArr.Add(new MJD.COMMON.MySqlPara("RID", ParameterDirection.Input, DbType.Int32, model.RID));
            pArr.Add(new MJD.COMMON.MySqlPara("Name", ParameterDirection.Input, DbType.String, model.Name));
            pArr.Add(new MJD.COMMON.MySqlPara("TeleNum", ParameterDirection.Input, DbType.String, model.TeleNum));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateTime", ParameterDirection.Input, DbType.Int64, model.CreateTime));
            pArr.Add(new MJD.COMMON.MySqlPara("CreateIP", ParameterDirection.Input, DbType.String, model.CreateIP));
            pArr.Add(new MJD.COMMON.MySqlPara("Status", ParameterDirection.Input, DbType.Int32, model.Status));

            return MJD.COMMON.MYSQLHELPER.ExecuteQueryProcedure(procName, ref rtObj, pArr.ToArray());
        }

        public DataSet GetPagination(M_ADMIN model, ref MJD.COMMON.MySqlRtMsg rtObj){

            List<MJD.COMMON.MySqlPara> pArr = new List<MJD.COMMON.MySqlPara>();
            pArr.Add(new MJD.COMMON.MySqlPara("T",  ParameterDirection.Input, DbType.String, "TADMIN_PAGINATION"));
            pArr.Add(new MJD.COMMON.MySqlPara("ID", ParameterDirection.Input, DbType.Int32, model.ID));
            pArr.Add(new MJD.COMMON.MySqlPara("RID", ParameterDirection.Input, DbType.Int32, model.RID));
            pArr.Add(new MJD.COMMON.MySqlPara("Name", ParameterDirection.Input, DbType.String, model.Name));
            pArr.Add(new MJD.COMMON.MySqlPara("TeleNum", ParameterDirection.Input, DbType.String, model.TeleNum));
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
