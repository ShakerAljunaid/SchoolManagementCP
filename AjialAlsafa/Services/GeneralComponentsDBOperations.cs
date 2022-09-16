using AjialAlsafa.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Services
{
    public class GeneralComponentsDBOperations
    {
        private SqlConnection getConnection()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            return con;
        }

        #region  List Section
        public List<GeneralComponent> GetAllGeneralComponents(int typeId)//EmpModel objEmp
        {

            try
            {
                string sql = "select  * from GeneralComponents where  ComponentTypeId=" + typeId;
                using (var con = getConnection())
                {
                    var GeneralComponents = con.Query<GeneralComponent>(sql).ToList();

                    return GeneralComponents;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Create Section
        internal int Create(GeneralComponent GeneralComponent)
        {
            try
            {

                using (var con = getConnection())
                {
                    var GeneralComponentId = (int)con.Insert(GeneralComponent);

                    return GeneralComponentId;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Edit Section
        internal bool Edit(GeneralComponent GeneralComponent)
        {
            try
            {
                // string sql = "insert into ProgramsProcedures values (@Name)";
                using (var con = getConnection())
                {
                    bool r = con.Update(GeneralComponent);


                    //if (r)
                    //{
                    //    con.Insert(new TableHistory() { OperationTypeId = 2, TableName = "Audit reviews", CreatedBy = 5, RowId = auditReview.Id });
                    //    return r;

                    //}
                    return r;

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        #endregion

        #region  Delete Section
        internal int Delete(int id)
        {
            try
            {
                string sql = "Update GeneralComponents set SoftDeleteState=1,SoftDeleteDate=getDate() WHERE id=@Id";
                using (var con = getConnection())
                {
                    int r = con.Execute(sql, new { Id = id });
                    //if (r > 0)
                    //    con.Insert(new TableHistory() { OperationTypeId = 3, TableName = "AuditPrograms", CreatedBy = 5, RowId = id });
                    return r;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}