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
    public class SubjectTeacherDBOperations
    {
        private SqlConnection getConnection()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            return con;
        }

        #region  List Section
        public IEnumerable GetAllsubjectTeachers(int schoolId, int gradeId,int classId,int termId )//EmpModel objEmp
        {

            try
            {
                string sql = "SELECT        a.Name AS teacherName, a.Id AS accountId, s.ArbicTitle AS subjectName, s.Id AS subjectId"+
                             " FROM Accounts a INNER JOIN  SubjectTeachers st ON a.Id = st.AccountId INNER JOIN GeneralComponents s ON st.SubjectId = s.Id "+
                            " where st.classId = "+classId+" and gradeId = "+ gradeId+" and termid = "+termId+
                      " union"+
                            " SELECT '' AS teacherName, 0 AS accountId, s.ArbicTitle AS subjectName, s.Id AS subjectId"+
                            " FROM   GeneralComponents s WHERE s.ComponentTypeId = 7  and s.id not in (SELECT subjectId FROM SubjectTeachers WHERE classId = "+classId+" and gradeId = "+gradeId+" and termid = "+termId+")" ;
                using (var con = getConnection())
                {
                    var subjectTeachers = con.Query(sql).ToList();

                    return subjectTeachers;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Create Section
        internal int Create(SubjectTeacher subjectTeacher)
        {
            try
            {

                using (var con = getConnection())
                {
                    var accountId = (int)con.Insert(subjectTeacher);

                    return accountId;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Edit Section
        internal bool Edit(SubjectTeacher subjectTeacher)
        {
            try
            {
                // string sql = "insert into ProgramsProcedures values (@Name)";
                using (var con = getConnection())
                {
                    bool r = con.Update(subjectTeacher);


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
                string sql = "Update subjectTeachers set SoftDeleteState=1,SoftDeleteDate=getDate() WHERE id=@Id";
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