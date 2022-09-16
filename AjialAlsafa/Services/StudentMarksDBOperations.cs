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
    public class StudentMarksDBOperations
    {
        private SqlConnection getConnection()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            return con;
        }

        #region  List Section
        public List<StudentMark> GetActiveStudentMarks(int schoolId,int yearId,int studentId)//EmpModel objEmp
        {

            try
            {
                //  string sql = "select t.* from StudentMarks t join  SchoolYears y on y.Id=t.yearId where y.currentStatus=1 and y.SoftDeleteState is null and schoolId=" + schoolId;
                string sql = "SELECT  sm.*,g.ArbicTitle AS SubjectName,m.ArbicTitle As MarkTypeName FROM StudentMarks sm JOIN GeneralComponents g ON sm.SubjectId = g.Id join GeneralComponents m on m.id=sm.MarkTypeId  where  sm.schoolId=" + schoolId + " and sm.yearId=" + yearId+" and sm.studentId="+studentId;
                using (var con = getConnection())
                {
                    var StudentMarks = con.Query<StudentMark>(sql).ToList();

                    return StudentMarks;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Create Section
        internal int Create(StudentMark StudentMark)
        {
            try
            {

                using (var con = getConnection())
                {
                    var termId = (int)con.Insert(StudentMark);

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
        internal bool Edit(StudentMark StudentMark)
        {
            try
            {
                // string sql = "insert into ProgramsProcedures values (@Name)";
                using (var con = getConnection())
                {
                    bool r = con.Update(StudentMark);


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
                string sql = "Update StudentMarks set SoftDeleteState=1,SoftDeleteDate=getDate(),currentStatus=0 WHERE id=@Id";
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