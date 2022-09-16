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
    public class SchoolTermsDBOperations
    {
        private SqlConnection getConnection()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            return con;
        }

        #region  List Section
        public List<SchoolTerm> GetActiveSchoolTerms(int schoolId,int yearId)//EmpModel objEmp
        {

            try
            {
                //  string sql = "select t.* from SchoolTerms t join  SchoolYears y on y.Id=t.yearId where y.currentStatus=1 and y.SoftDeleteState is null and schoolId=" + schoolId;
                string sql = "select * from SchoolTerms  where  schoolId=" + schoolId +" and yearId="+ yearId;
                using (var con = getConnection())
                {
                    var schoolTerms = con.Query< SchoolTerm>(sql).ToList();

                    return schoolTerms;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Create Section
        internal int Create(SchoolTerm schoolTerm)
        {
            try
            {

                using (var con = getConnection())
                {
                    var termId = (int)con.Insert(schoolTerm);

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
        internal bool Edit(SchoolTerm schoolTerm)
        {
            try
            {
                // string sql = "insert into ProgramsProcedures values (@Name)";
                using (var con = getConnection())
                {
                    bool r = con.Update(schoolTerm);


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
                string sql = "Update SchoolTerm set SoftDeleteState=1,SoftDeleteDate=getDate(),currentStatus=0 WHERE id=@Id";
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