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
    public class StudentsDBOperations
    {
        private SqlConnection getConnection()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            return con;
        }

        #region  List Section
        public List<Student> GetAllStudents(int schoolId)//EmpModel objEmp
        {

            try
            {
                string sql = "select  * from Students where  SchoolId=" + schoolId;
                using (var con = getConnection())
                {
                    var Students = con.Query<Student>(sql).ToList();

                    return Students;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Student> GetStudentByCode(string code)//EmpModel objEmp
        {

            try
            {
                string sql = "SELECT Top 1  a.Name, Students.Id, Students.Guid, Students.AccountId, Students.Code, Students.SchoolId, Students.TermId, Students.YearId, Students.ClassId, Students.GradeId, Students.BranchId,Students.GenderId, Students.Status, Students.Notes, Students.CreateAt, Students.CreatedBy, Students.SoftDeleteState, " +
                    "Students.SoftDeleteDate, grade.ArbicTitle AS GradeName,  Branch.ArbicTitle AS BranchName, Class.ArbicTitle AS ClassName " +
                    "FROM  Accounts a join  Students on a.Id=Students.AccountId INNER JOIN GeneralComponents AS grade ON Students.GradeId = grade.Id INNER JOIN GeneralComponents AS Branch ON Students.BranchId = Branch.Id" +
                    " INNER JOIN  GeneralComponents AS Class ON Students.ClassId = Class.Id where   code like '"+ code+"'";
                using (var con = getConnection())
                {
                    var Students = con.Query<Student>(sql).ToList();

                    return Students;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region  Create Section
        internal int Create(Student Student)
        {
            try
            {

                using (var con = getConnection())
                {
                    var StudentId = (int)con.Insert(Student);

                    return StudentId;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Edit Section
        internal bool Edit(Student Student)
        {
            try
            {
                // string sql = "insert into ProgramsProcedures values (@Name)";
                using (var con = getConnection())
                {
                    bool r = con.Update(Student);


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
        internal int DeleteStudent(int id)
        {
            try
            {
                string sql = "Update Students set SoftDeleteState=1,SoftDeleteDate=getDate() WHERE id=@Id";
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