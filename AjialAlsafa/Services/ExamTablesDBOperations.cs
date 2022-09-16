using AjialAlsafa.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Services
{
    public class ExamTablesDBOperations
    {
        private SqlConnection getConnection()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            return con;
        }

        #region  List Section
        public List<ExamTable> GetActiveExamTables(int schoolId,int yearId,int gradeId)//EmpModel objEmp
        {

            try
            {
                //  string sql = "select t.* from ExamTables t join  SchoolYears y on y.Id=t.yearId where y.currentStatus=1 and y.SoftDeleteState is null and schoolId=" + schoolId;
                string sql = "SELECT  e.*,g.ArbicTitle AS SubjectName FROM ExamTables e JOIN GeneralComponents g ON e.SubjectId = g.Id  where  e.schoolId=" + schoolId +" and e.yearId="+ yearId+" and e.gradeId="+gradeId;
                using (var con = getConnection())
                {
                    var examTables = con.Query< ExamTable>(sql).ToList();

                    return examTables;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Create Section
        internal int Create(ExamTable examTable)
        {
            try
            {

                using (var con = getConnection())
                {
                    var termId = (int)con.Insert(examTable);

                    return termId;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Edit Section
        internal bool Edit(ExamTable examTable)
        {
            try
            {
                // string sql = "insert into ProgramsProcedures values (@Name)";
                using (var con = getConnection())
                {
                    bool r = con.Update(examTable);


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
                string sql = "Update examTables set SoftDeleteState=1,SoftDeleteDate=getDate(),currentStatus=0 WHERE id=@Id";
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