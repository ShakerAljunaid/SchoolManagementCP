using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AjialAlsafa.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace AjialAlsafa.Services
{
    public class AccountsDBOperations
    {
        private SqlConnection getConnection()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
            return con;
        }

        #region  List Section
        public List<Account> GetAllAccounts(int schoolId, int typeId )//EmpModel objEmp
        {

            try
            {
                string sql = "select  * from Accounts where  AccountTypeId="+typeId+ " and   SchoolId=" + schoolId;
                using (var con = getConnection())
                {
                    var accounts = con.Query<Account>(sql).ToList();
                   
                    return accounts;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Account VerifyAccount(Account account)//EmpModel objEmp
        {

            try
            {
                string sql = "select Top 1 * from Accounts where (PhoneNo like '"+account.phoneNo+ "' or UserName like '"+account.userName+"') and password='"+account.password+"'";
                using (var con = getConnection())
                {
                    var accounts = con.Query<Account>(sql).ToList();

                    return accounts[0];
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  bool CheckAccountExistence(Account account)//EmpModel objEmp
        {

            try
            {
                string sql = "select Top 1 * from Accounts where accountTypeId="+ account.accountTypeId +" and  PhoneNo like '" + account.phoneNo+"'" ;
                using (var con = getConnection())
                {
                    var accounts = con.Query<Account>(sql).ToList();
                    

                    return accounts.Count>0?false:true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Create Section
        internal int Create(Account account)
        {
            try
            {

                
                if (!CheckAccountExistence(account))
                {
                    return -1;
                }
                else
                {
                    using (var con = getConnection())
                    {
                        var accountId = (int)con.Insert(account);

                        return accountId;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        #endregion

        #region  Edit Section
        internal bool Edit(Account account)
        {
            try
            {
                // string sql = "insert into ProgramsProcedures values (@Name)";
                using (var con = getConnection())
                {
                    bool r = con.Update(account);


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
        internal int DeleteAccount(int id)
        {
            try
            {
                string sql = "Update accounts set SoftDeleteState=1,SoftDeleteDate=getDate() WHERE id=@Id";
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