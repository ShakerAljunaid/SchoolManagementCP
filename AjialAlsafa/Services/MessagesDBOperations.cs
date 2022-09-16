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
    public class MessagesDBOperations
    {
        private SqlConnection getConnection()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            return con;
        }

        #region  List Section
        public List<Message> GetActiveMessage(int schoolId, int yearId, int gradeId)//EmpModel objEmp
        {

            try
            {
                //  string sql = "select t.* from Message t join  SchoolYears y on y.Id=t.yearId where y.currentStatus=1 and y.SoftDeleteState is null and schoolId=" + schoolId;
                string sql = "SELECT  * from messages  where  schoolId=" + schoolId + " and yearId=" + yearId + " and gradeId=" + gradeId;
                using (var con = getConnection())
                {
                    var Message = con.Query<Message>(sql).ToList();

                    return Message;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Message> GetMessageById(int Id)//EmpModel objEmp
        {

            try
            {
                //  string sql = "select t.* from Message t join  SchoolYears y on y.Id=t.yearId where y.currentStatus=1 and y.SoftDeleteState is null and schoolId=" + schoolId;
                string sql = "SELECT  * from messages  where  Id=" + Id;
                using (var con = getConnection())
                {
                    var Message = con.Query<Message>(sql).ToList();

                    return Message;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Create Section
        internal int Create(Message message)
        {
            try
            {

                using (var con = getConnection())
                {
                    var termId = (int)con.Insert(message);

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
        internal bool Edit(Message message)
        {
            try
            {
                // string sql = "insert into ProgramsProcedures values (@Name)";
                using (var con = getConnection())
                {
                    bool r = con.Update(message);


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
                string sql = "Update Message set SoftDeleteState=1,SoftDeleteDate=getDate(),currentStatus=0 WHERE id=@Id";
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